
//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2026, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//  by introducing yourself and telling us what you do with this community.
//_____________________________________________________________________________________________________________________________________

using AdaptiveProgramming.Logging.UnitTest.Instrumentation;
using System.Diagnostics;
using System.Reflection;

namespace AdaptiveProgramming.Logging.UnitTest
{
  [TestClass]
  public class AssemblyTraceEventUnitTest
  {
    [TestMethod]
    public void ManualAssemblyTraceEventTestMethod()
    {
      TraceSource _tracer = AssemblyTraceEvent.Tracer;
      Assert.IsNotNull(_tracer);
      Assert.AreEqual<string>("LoggingSourse", _tracer.Name, $"Actual tracer name: {_tracer.Name}");
      SourceSwitch _switch = new SourceSwitch("LoggingSourseSwitch", "All");
      _tracer.Switch = _switch;
      Assert.IsNotNull(_switch);
      Assert.AreEqual<string>("LoggingSourseSwitch", _switch.DisplayName, $"Actual switch name: {_switch.DisplayName}");
      Assert.AreEqual<SourceLevels>(SourceLevels.All, _switch.Level, $"Actual switch level: {_switch.Level}");
      _tracer.Listeners.Clear();
      Assert.AreEqual<int>(0, _tracer.Listeners.Count);
      string? _testPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
      Assert.IsFalse(String.IsNullOrEmpty(_testPath));
      string _logFilePath = Path.Combine(_testPath, @"LogFileName.LOG");
      Assert.IsTrue(_logFilePath.Contains(@"LogFileName.LOG"))  ;
      DelimitedListTraceListener _advancedListener = new DelimitedListTraceListener(_logFilePath, "AdvancedListener");
      _advancedListener.Delimiter = ";";
      Assert.AreEqual<String>( _advancedListener.Name, "AdvancedListener");
      Assert.IsFalse(String.IsNullOrEmpty(_advancedListener.GetFileName()));
      _tracer.Listeners.Add(_advancedListener);
      Assert.AreEqual(1, _tracer.Listeners.Count);
      Dictionary<string, TraceListener> _listeners = _tracer.Listeners.Cast<TraceListener>().ToDictionary<TraceListener, string>(x => x.Name);
      Assert.AreEqual(1, _listeners.Count);
      Assert.AreEqual<string>("AdvancedListener", _listeners.First().Key);
      TraceListener _listener = _listeners["AdvancedListener"];
      Assert.IsNotNull(_listener);
      Assert.IsInstanceOfType(_listener, typeof(DelimitedListTraceListener));
      DelimitedListTraceListener? _delimitedListener = _listener as DelimitedListTraceListener;
      Assert.IsNotNull(_delimitedListener);
      _delimitedListener.Filter = new EventTypeFilter(SourceLevels.All);
      EventTypeFilter? _filter = _delimitedListener.Filter as EventTypeFilter;
      Assert.IsNotNull(_filter);
      Assert.AreEqual<SourceLevels>(SourceLevels.All, _filter.EventType);
      Assert.IsFalse(String.IsNullOrEmpty(_advancedListener.GetFileName()));
      FileInfo _logFileInfo = new FileInfo(_advancedListener.GetFileName() ?? _logFilePath);
      long _startLength = _logFileInfo.Exists ? _logFileInfo.Length : 0;
      _tracer.TraceEvent(TraceEventType.Information, 0, "LogFileExistsTest is executed");
      _tracer.Flush();
      _logFileInfo.Refresh();
      Assert.IsTrue(_logFileInfo.Exists);
      Assert.IsTrue(_logFileInfo.Length > _startLength);
    }
    [TestMethod]
    public void AssemblyTraceEventTestMethod()
    {
      TraceSource _tracer = AssemblyTraceEvent.Tracer;
      Assert.IsNotNull(_tracer);
      Assert.AreEqual<string>("LoggingSourse", _tracer.Name, $"Actual tracer name: {_tracer.Name}");
      Assert.AreEqual(1, _tracer.Listeners.Count);
      Dictionary<string, TraceListener> _listeners = _tracer.Listeners.Cast<TraceListener>().ToDictionary<TraceListener, string>(x => x.Name);
      Assert.AreEqual(1, _listeners.Count);
      Assert.AreEqual<string>("Default", _listeners.First().Key);
      TraceListener _listener = _listeners["Default"];
      Assert.IsNotNull(_listener);
      Assert.IsInstanceOfType(_listener, typeof(DelimitedListTraceListener));
      DelimitedListTraceListener? _advancedListener = _listener as DelimitedListTraceListener;
      Assert.IsNotNull(_advancedListener);
      Assert.IsNotNull(_advancedListener.Filter);
      Assert.IsInstanceOfType(_advancedListener.Filter, typeof(EventTypeFilter));
      EventTypeFilter? _eventTypeFilter = _advancedListener.Filter as EventTypeFilter;
      Assert.AreEqual(SourceLevels.All, _eventTypeFilter.EventType);
      string? _testPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
      //Assert.AreEqual<string>(Path.Combine(_testPath, @"TPA.Logging.Consumer.log"), _advancedListener.GetFileName());
    }
  }
}