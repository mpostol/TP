
using System;
using System.Diagnostics.Tracing;
using System.IO;
using Microsoft.Practices.EnterpriseLibrary.SemanticLogging;
using Microsoft.Practices.EnterpriseLibrary.SemanticLogging.Sinks;
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
      using (SinkSubscription<ObservableEventListener> _subscription = SinkExtensions.CreateSink(x => _lastEvent = x))
      {
        Assert.IsNotNull(_subscription.Sink);
        _subscription.Sink.EnableEvents(SemanticEventSource.Log, EventLevel.LogAlways, Keywords.All);
        Assert.IsNull(_lastEvent);
        SemanticEventUser _logUser = new SemanticEventUser();
        _logUser.LogFailure();
        Assert.IsNotNull(_lastEvent);

        //_lastEvent content
        Assert.AreEqual<int>(1, _lastEvent.EventId);
        Assert.AreEqual<Guid>(Guid.Empty, _lastEvent.ActivityId);
        Assert.AreEqual<string>("Application Failure: LogFailure", _lastEvent.FormattedMessage, _lastEvent.FormattedMessage);
        Assert.AreEqual<string>("System.Collections.ObjectModel.ReadOnlyCollection`1[System.Object]", _lastEvent.Payload.ToString(), _lastEvent.Payload.ToString());
        Assert.AreEqual<int>(1, _lastEvent.Payload.Count);
        Assert.AreEqual<string>("LogFailure", _lastEvent.Payload[0].ToString());
        Assert.AreEqual<string>("message", _lastEvent.Schema.Payload[0]);

        Assert.AreEqual<string>("Start", _lastEvent.Schema.OpcodeName);
        Assert.AreEqual<EventOpcode>(EventOpcode.Start, _lastEvent.Schema.Opcode);
        Assert.AreEqual<string>("Page", _lastEvent.Schema.TaskName);
        Assert.AreEqual<EventTask>(SemanticEventSource.Tasks.Page, _lastEvent.Schema.Task);
      }
    }
    [TestMethod]
    public void NamedEventSourceTest()
    {
      EventEntry _lastEvent = null;
      using (SinkSubscription<ObservableEventListener> _subscription = SinkExtensions.CreateSink(x => _lastEvent = x))
      {
        _subscription.Sink.EnableEvents("TPA-SemanticLogging", EventLevel.LogAlways, Keywords.All);
        Assert.IsNull(_lastEvent);
        SemanticEventUser _logUser = new SemanticEventUser();
        _logUser.LogFailure();
        Assert.IsNotNull(_lastEvent);
        Assert.AreEqual<string>("Application Failure: LogFailure", _lastEvent.FormattedMessage, _lastEvent.FormattedMessage);
      }
    }
    [TestMethod]
    public void FlatFileSinkTest()
    {
      string _filePath = $"{nameof(FlatFileSinkTest)}.log";
      FileInfo _logFile = new FileInfo(_filePath);
      if (_logFile.Exists)
        _logFile.Delete();
      SinkSubscription<FlatFileSink> m_FileSubscription = SinkExtensions.CreateSink(SemanticEventSource.Log, _filePath);
      _logFile.Refresh();
      Assert.IsTrue(_logFile.Exists);
      Assert.AreEqual<long>(0, _logFile.Length);
      SemanticEventUser _logUser = new SemanticEventUser();
      _logUser.LogFailure();
      m_FileSubscription.Sink.FlushAsync();
      _logFile.Refresh();
      Assert.IsTrue(_logFile.Length > 100);
      m_FileSubscription.Dispose();
    }
  }

  internal static class SinkExtensions
  {

    public static SinkSubscription<ObservableEventListener> CreateSink(this ObservableEventListener eventStream, Action<EventEntry> feedback)
    {
      IDisposable subscription = eventStream.Subscribe(feedback);
      return new SinkSubscription<ObservableEventListener>(subscription, eventStream);
    }
    public static SinkSubscription<ObservableEventListener> CreateSink(Action<EventEntry> feedback)
    {
      ObservableEventListener _listener = new ObservableEventListener();
      IDisposable subscription = _listener.Subscribe(feedback);
      return new SinkSubscription<ObservableEventListener>(subscription, _listener);
    }
    public static SinkSubscription<FlatFileSink> CreateSink(EventSource eventSource, string path)
    {
      ObservableEventListener _listener = new ObservableEventListener();
      _listener.EnableEvents(eventSource, EventLevel.LogAlways, Keywords.All);
      return _listener.LogToFlatFile(path);
    }


  }
}
