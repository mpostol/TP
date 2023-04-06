//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2023, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//  by introducing yourself and telling us what you do with this community.
//_____________________________________________________________________________________________________________________________________

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TPD.AsynchronousProgramming
{
  /// <summary>
  /// Interface IProductFactory - an example of producer
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public interface IProductFactory<T>
  {
    /// <summary>
    /// Creates an product expressed as the instance of <typeparamref name="T"/>.
    /// </summary>
    /// <returns>T.</returns>
    T Create();
  }

  public class InstanceCreationCompletedEventArgs<type> : EventArgs
  {
    public type Result { get; internal set; }

    public InstanceCreationCompletedEventArgs(type instance)
    {
      Result = instance;
    }
  }

  public class Producer<T> : IDisposable
  {
    public Producer(IProductFactory<T> factory)
    {
      m_CriticalSection = new CriticalSection<T>(factory);
      m_Timer = new Timer(x => m_CriticalSection.GenerateChar(), null, 0, 200);
    }

    #region Task-based Asynchronous Pattern (TAP)

    public async Task<T> ReadKeyFromKeyboardBufferAsync()
    {
      return await Task<T>.Run(() => m_CriticalSection.ReadKeyFromKeyboardBuffer());
    }

    #endregion Task-based Asynchronous Pattern (TAP)

    #region Event-based Asynchronous Pattern (EAP)

    public event EventHandler<InstanceCreationCompletedEventArgs<T>> ReadKeyFromKeyboardBufferCompleted;

    public void EAPReadKeyFromKeyboardBufferAsync()
    {
      ThreadPool.QueueUserWorkItem(x =>
          {
            T _char = m_CriticalSection.ReadKeyFromKeyboardBuffer();
            ReadKeyFromKeyboardBufferCompleted?.Invoke(this, new InstanceCreationCompletedEventArgs<T>(_char));
          }
      );
    }

    #endregion Event-based Asynchronous Pattern (EAP)

    #region Asynchronous Programming Model  Pattern (APM)

    public IAsyncResult BeginReadKeyFromKeyboardBuffer(AsyncCallback callback, object parameter)
    {
      m_Caller = m_CriticalSection.ReadKeyFromKeyboardBuffer;
      return m_Caller.BeginInvoke(callback, parameter);
    }

    public T EndReadKeyFromKeyboardBuffer(IAsyncResult result)
    {
      return m_Caller.EndInvoke(result);
    }

    #endregion Asynchronous Programming Model  Pattern (APM)

    #region IDisposable Support

    private bool disposedValue = false; // To detect redundant calls

    protected virtual void Dispose(bool disposing)
    {
      if (disposedValue)
        return;
      if (disposing)
      {
        m_Timer.Dispose();
      }
      disposedValue = true;
    }

    // This code added to correctly implement the disposable pattern.
    public void Dispose()
    {
      // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
      Dispose(true);
    }

    #endregion IDisposable Support

    #region private

    private delegate T AsyncMethodCaller();

    private Timer m_Timer;
    private AsyncMethodCaller m_Caller;
    private CriticalSection<T> m_CriticalSection;

    private class CriticalSection<productType>
    {
      public CriticalSection(IProductFactory<productType> factory)
      {
        m_Factory = factory ?? throw new ArgumentNullException(nameof(factory));
      }

      internal void GenerateChar()
      {
        try
        {
          Monitor.Enter(this);
          m_productsBuffer.Enqueue(m_Factory.Create());
          if (m_productsBuffer.Count == 1)
            Monitor.Pulse(this);
        }
        finally
        {
          Monitor.Exit(this);
        }
      }

      internal productType ReadKeyFromKeyboardBuffer()
      {
        try
        {
          Monitor.Enter(this);
          while (m_productsBuffer.Count == 0)
            Monitor.Wait(this);
          return m_productsBuffer.Dequeue();
        }
        finally
        {
          Monitor.Exit(this);
        }
      }

      private IProductFactory<productType> m_Factory;
      private readonly Queue<productType> m_productsBuffer = new Queue<productType>();
    }

    #endregion private
  }
}