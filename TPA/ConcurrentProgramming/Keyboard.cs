
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading;
using System.Threading.Tasks;

namespace TPA.AsynchronousBehavior.ConcurrentProgramming
{
  public class Keyboard : IDisposable
  {

    public Keyboard()
    {
      m_Timer = new Timer(x => m_CriticalSection.GenerateChar(), null, 0, 200);
    }

    #region Task-based Asynchronous Pattern (TAP)
    public async Task<char> TPAReadKeyFromKeyboardBufferAsync()
    {
      return await Task<char>.Run(() => m_CriticalSection.ReadKeyFromKeyboardBuffer());
    }
    #endregion

    #region Event-based Asynchronous Pattern (EAP)
    public event EventHandler<ReadKeyFromKeyboardBufferCompletedEventArgs> ReadKeyFromKeyboardBufferCompleted;
    public void EAPReadKeyFromKeyboardBufferAsync()
    {
      ThreadPool.QueueUserWorkItem(x =>
          {
            char _char = m_CriticalSection.ReadKeyFromKeyboardBuffer();
            ReadKeyFromKeyboardBufferCompleted?.Invoke(this, new ReadKeyFromKeyboardBufferCompletedEventArgs { Result = _char });
          }
      );
    }
    #endregion

    #region Asynchronous Programming Model  Pattern (APM)
    public IAsyncResult BeginReadKeyFromKeyboardBuffer(AsyncCallback callback, object parameter)
    {
      m_Caller = m_CriticalSection.ReadKeyFromKeyboardBuffer;
      return m_Caller.BeginInvoke(callback, parameter);
    }
    public char EndReadKeyFromKeyboardBuffer(IAsyncResult result)
    {
      return m_Caller.EndInvoke(result);
    }
    #endregion

    #region IDisposable Support
    private bool disposedValue = false; // To detect redundant calls
    protected virtual void Dispose(bool disposing)
    {
      if (disposedValue)
        return;
      if (disposing)
      {
        m_Timer.Dispose();
        m_CriticalSection.Dispose();
      }
      disposedValue = true;
    }
    // This code added to correctly implement the disposable pattern.
    public void Dispose()
    {
      // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
      Dispose(true);
    }
    #endregion

    #region private
    private delegate char AsyncMethodCaller();
    private Timer m_Timer;
    private AsyncMethodCaller m_Caller;
    private CriticalSection m_CriticalSection = new CriticalSection();

    [Synchronization(true)]
    class CriticalSection : IDisposable
    {

      internal void GenerateChar()
      {
        _charBuffer.Enqueue((char)m_Random.Next('a', 'z'));
        if (_charBuffer.Count == 1)
          m_AutoResetEvent.Set();
      }
      internal char ReadKeyFromKeyboardBuffer()
      {
        if (_charBuffer.Count == 0)
          m_AutoResetEvent.WaitOne(-1, true);
        else if (_charBuffer.Count == 1)
          m_AutoResetEvent.Reset();
        Debug.Assert(_charBuffer.Any<Char>());
        return _charBuffer.Dequeue();
      }

      public void Dispose()
      {
        m_AutoResetEvent.Dispose();
      }
      private readonly Queue<char> _charBuffer = new Queue<char>();
      private Random m_Random = new Random();
      private readonly AutoResetEvent m_AutoResetEvent = new AutoResetEvent(false);
    }

    #endregion    

  }
}
