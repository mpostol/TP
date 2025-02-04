//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2025, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//  by introducing yourself and telling us what you do with this community.
//_____________________________________________________________________________________________________________________________________

using TP.ConcurrentProgramming.Fundamentals;

namespace TP.ConcurrentProgramming.Communication
{
  /// <summary>
  /// Provides access to a queue of <seealso cref="IEnvelope"/> messages.
  /// Thread Safety: Instances members of this type are safe for multi-threaded operations.
  /// </summary>
  // TODO implement UT
  public sealed class Port : HoareMonitor
  {
    #region ctor

    public Port()
    {
      m_AtLeastOneMessageInQueue = CreateCondition();
    }

    #endregion ctor

    #region public

    /// <summary>
    /// Gets the number of elements contained in the Port queue.
    /// </summary>
    public int Count
    {
      get
      {
        int retval = 0;
        EnterMonitor();
        try
        {
          if (!this.m_Openned)
            throw new InvalidOperationException("Port is closed");
          retval = m_NumOfMess;
        }
        finally
        {
          //ExitMonitor();
        }
        return retval;
      }
    }

    /// <summary>
    /// Opens this instance.
    /// </summary>
    public void Open()
    {
      EnterMonitor();
      m_Openned = true;
      ExitMonitor();
    }

    /// <summary>
    /// Closes this instance.
    /// </summary>
    public void Close()
    {
      EnterMonitor();
      m_Openned = false;
      //TODO implement NotifyAll m_AtLeastOneMessageInQueue.NotifyAll();
      ExitMonitor();
    }

    /// <summary>
    /// Clears this instance.
    /// </summary>
    public void Clear()
    {
      EnterMonitor();
      try
      {
        IEnvelope _messToReturn;
        while (m_NumOfMess != 0)
        {
          _messToReturn = Dequeue();
          _messToReturn.ReturnEmptyEnvelope();
        }
        //m_AtLeastOneMessageInQueue.NotifyAll();
      }
      finally
      {
        ExitMonitor();
      }
    }

    /// <summary>
    /// Sends the message to the 'port'. If there is a process waiting in 'port' it
    /// will be resumed from the 'port' queue. If there is no process, the message will be queued.
    /// </summary>
    /// <param name="mess">Message to be sent</param>
    public void SendMsg(ref IEnvelope mess)
    {
      EnterMonitor();
      try
      {
        if (!m_Openned) throw new InvalidOperationException("Port is closed");
        m_Queue.Enqueue(mess);
        mess = null;
        m_NumOfMess++;
        m_AtLeastOneMessageInQueue?.Send();
      }
      finally
      {
        ExitMonitor();
      }
    }

    /// <summary>
    /// Receive message from 'port'. If there is no message in the 'port', the calling
    /// thread will be blocked until it receives a message or a specified amount of
    /// time elapses.
    /// </summary>
    /// <param name="mess">UMessage removed from the beginning of the port Queue</param>
    /// <param name="timeOut">The number of milliseconds to wait before this method returns. 0 means wait forever.
    /// </param>
    /// <param name="callingMonitor">TODO: add some description</param>
    /// <returns>
    /// true if the message was received before the specified time elapsed; otherwise, false
    /// </returns>
    public bool WaitMsg(out IEnvelope? mess)
    {
      bool res = false;
      EnterMonitor();
      mess = null;
      try
      {
        if ((m_NumOfMess == 0) & m_Openned)
          m_AtLeastOneMessageInQueue?.Wait();
        if (m_NumOfMess != 0)
        {
          mess = Dequeue();
          res = true;
        }
      }
      finally
      {
        ExitMonitor();
      }
      return res;
    }

    #endregion public

    protected override void Dispose(bool disposing)
    {
      base.Dispose(disposing);
    }

    #region private

    private bool m_Openned = false;
    private Queue<IEnvelope> m_Queue = new Queue<IEnvelope>();
    private readonly ICondition? m_AtLeastOneMessageInQueue = null;
    private int m_NumOfMess = 0;

    private IEnvelope Dequeue()
    {
      if (m_NumOfMess <= 0)
        throw new InvalidOperationException("No message in the queue");
      m_NumOfMess--;
      return m_Queue.Dequeue();
    }

    #endregion private

    #region HoareMonitor

    protected override ISignal CreateSignal()
    {
      throw new NotImplementedException();
    }

    #endregion HoareMonitor
  }
}