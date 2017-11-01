
using System;
using System.Diagnostics.Tracing;
using Microsoft.Practices.EnterpriseLibrary.SemanticLogging;
using Microsoft.Practices.EnterpriseLibrary.SemanticLogging.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPA.Logging.Consumer;

namespace TPA.Logging.UnitTest
{
  [TestClass]
  public class SemanticEventSourceUnitTest
  {
    [TestMethod]
    public void ShouldValidateEventSource()
    {
      EventSourceAnalyzer.InspectAll(SemanticEventSource.Log);
    }
    [TestMethod]
    public void LogFailureTest()
    {
      EventEntry _lastEvent = null;
      ObservableEventListener listener = new ObservableEventListener();
      listener.CreateSink(x => _lastEvent = x);
      listener.EnableEvents(SemanticEventSource.Log, EventLevel.LogAlways, Keywords.All);

      Assert.IsNull(_lastEvent);
      SemanticEventUser _logUser = new SemanticEventUser();
      _logUser.LogFailure();
      Assert.IsNotNull(_lastEvent);

      //_lastEvent content
      Assert.AreEqual<int>(1, _lastEvent.EventId);
      Assert.AreEqual<Guid>(Guid.Empty, _lastEvent.ActivityId);
      Assert.AreEqual<string>("Application Failure: LogFailure", _lastEvent.FormattedMessage, _lastEvent.FormattedMessage);
      Assert.AreEqual<string>("System.Collections.ObjectModel.ReadOnlyCollection`1[System.Object]", _lastEvent.Payload.ToString(), _lastEvent.Payload.ToString());
    }
  }
  public class CustomSink : IObserver<EventEntry>
  {

    public CustomSink(Action<EventEntry> feedback)
    {
      m_Feedback = feedback;
    }

    #region IObserver<EventEntry>
    public void OnCompleted() { }
    public void OnError(Exception error) { }
    public void OnNext(EventEntry value)
    {
      m_Feedback(value);
    }
    #endregion

    private Action<EventEntry> m_Feedback;

  }

  public static class EmailSinkExtensions
  {

    public static SinkSubscription<CustomSink> CreateSink(this IObservable<EventEntry> eventStream, Action<EventEntry> feedback)
    {
      CustomSink _sink = new CustomSink(feedback);
      IDisposable subscription = eventStream.Subscribe(_sink);
      return new SinkSubscription<CustomSink>(subscription, _sink);
    }

  }
}
