//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2025, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//_____________________________________________________________________________________________________________________________________
using TP.ConcurrentProgramming.Fundamentals;

namespace TP.ConcurrentProgramming.Communication
{
  /// <summary>
  /// It allows synchronizing and exchanging events between concurrent threads on the FIFO basis.
  /// </summary>
  public class EventsExchange : HoareMonitor
  {
    #region ctor

    public EventsExchange()
    {
      m_MarkBuffEmpty = CreateCondition();
      m_MarkNewEvent = CreateCondition();
    }

    #endregion ctor

    #region public

    /// <summary>
    /// Gets the event.
    /// Deposits or gets new event. If there is any events to be get depositing thread enters wait state.
    /// </summary>
    /// <returns></returns>
    public object? GetEvent()
    {
      EnterMonitor();
      try
      {
        object? lastEvent = null;
        if (m_CurrEvent == null)
          m_MarkNewEvent.Wait();
        lastEvent = m_CurrEvent;
        m_CurrEvent = null;
        m_MarkBuffEmpty.Send();
        return lastEvent;
      }
      finally
      {
        ExitMonitor();
      }
    }

    /// <summary>
    /// Sets the event.
    /// Adds this event to process list and informs that new event occurs
    /// </summary>
    /// <param name="newEvent">The new event.</param>
    public void SetEvent(object newEvent)
    {
      EnterMonitor();
      try
      {
        if (m_CurrEvent != null)
          m_MarkBuffEmpty.Wait();
        m_CurrEvent = newEvent;
        m_MarkNewEvent.Send();
      }
      finally
      {
        ExitMonitor();
      }
    }

    #endregion public

    #region HoareMonitor

    protected override ISignal CreateSignal()
    {
      throw new NotImplementedException();
    }

    #endregion HoareMonitor

    #region private

    private object? m_CurrEvent;
    private ICondition m_MarkNewEvent;
    private ICondition m_MarkBuffEmpty;

    #endregion private
  }
}