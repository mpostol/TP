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

namespace TP.ConcurrentProgramming.Communication.Test
{
  [TestClass]
  public class EventsExchangeTests
  {
    [TestMethod]
    public void SetEvent_ShouldThrowArgumentNullException_WhenEventIsNull()
    {
      // Arrange
      using (EventsExchange<string> eventsExchange = new EventsExchange<string>())
      {
        // Act & Assert
        Assert.ThrowsException<ArgumentNullException>(() => eventsExchange.SetEvent(null));
      }
    }

    [TestMethod]
    public void GetEvent_ShouldWaitForNewEvent()
    {
      // Arrange
      bool isWaiting = true;
      using (EventsExchange<string> eventsExchange = new EventsExchange<string>())
      {
        Thread newThread = new Thread(() =>
        {
          eventsExchange.GetEvent();
          isWaiting = false;
        });
        // Act
        newThread.Start();
        Thread.Sleep(500);
        // Assert
        Assert.IsTrue(isWaiting);
      }
    }

    [TestMethod]
    public void SetEvent_ShouldSetEventCorrectly()
    {
      // Arrange
      string testEvent = "TestEvent";
      string? result = string.Empty;
      Thread? newThread = null;
      using (EventsExchange<string> eventsExchange = new())
      {
        newThread = new Thread(() => eventsExchange.SetEvent(testEvent));
        // Act
        newThread.Start();
        Thread.Sleep(500);
        result = eventsExchange.GetEvent();
      }
      newThread.Join();
      // Assert
      Assert.AreEqual<string>(testEvent, result);
    }

    [TestMethod]
    public void GetEvent_ShouldWaitForEventToBeSet()
    {
      // Arrange
      string testEvent = "TestEvent";
      string? result = string.Empty;
      Thread? getEventThread = null;
      using (EventsExchange<string> eventsExchange = new())
      {
        // Act
        getEventThread = new Thread(() => result = eventsExchange.GetEvent());
        getEventThread.Start();
        Thread.Sleep(500); // Ensure getEventThread is waiting
        eventsExchange.SetEvent(testEvent);
        getEventThread.Join();
      }
      // Assert
      Assert.AreEqual<string>(testEvent, result);
    }
  }
}