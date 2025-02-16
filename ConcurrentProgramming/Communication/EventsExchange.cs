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
  /// <remarks>
  /// The EventsExchange class is designed to facilitate synchronization and event exchange between concurrent threads using a FIFO (First-In-First-Out) basis.
  /// It extends the HoareMonitor class, which provides the necessary synchronization primitives.
  /// The EventsExchange class uses condition variables to manage synchronization between threads, ensuring that
  /// events are exchanged in a FIFO manner.
  /// </remarks>
  /// <typeparam name="Event">The type of event to be exchanged. Event is a generic type parameter constrained to be a reference type (class)</typeparam>
  public class EventsExchange<Event> : HoareMonitor
    where Event : class
  {
    #region ctor

    /// <summary>
    /// The constructor initializes two condition variables, m_MarkBuffEmpty and m_MarkNewEvent, using the <seealso cref="HoareMonitor.CreateCondition"/>.
    /// These condition variables are used to manage the synchronization between threads.
    /// </summary>
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
    /// <remarks>While threads calling GetEvent wait for the buffer to be empty before getting a new event.</remarks>
    /// <returns>Return last event descriptor.</returns>
    public Event? GetEvent()
    {
      EnterMonitor();
      try
      {
        Event? lastEvent = null;
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
    /// Sets the event. Adds the event and informs that new event have been occurred
    /// </summary>
    /// <remarks>While threads calling SetEvent wait for the buffer to be empty before setting a new event.
    /// <param name="newEvent">The new event descriptor.</param>
    /// <exception cref="ArgumentNullException">If newEvent is null, an ArgumentNullException is thrown.</exception>
    public void SetEvent(Event newEvent)
    {
      if (newEvent == null)
        throw new ArgumentNullException($"{newEvent} must not be null");
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

    /// <summary>
    /// The CreateSignal method is not implemented in this class. It is an abstract method from the HoareMonitor base class that must be implemented
    /// by derived classes if needed.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    protected override ISignal CreateSignal()
    {
      throw new NotImplementedException();
    }

    #endregion HoareMonitor

    #region private

    private Event? m_CurrEvent;
    private ICondition m_MarkNewEvent;
    private ICondition m_MarkBuffEmpty;

    #endregion private
  }
}