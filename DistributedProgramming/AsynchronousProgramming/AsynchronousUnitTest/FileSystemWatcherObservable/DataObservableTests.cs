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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reactive.Linq;
using System.Threading;
using TPD.AsynchronousProgramming.Instrumentation;

namespace TPD.AsynchronousProgramming.FileSystemWatcherObservable
{
  [TestClass()]
  [DeploymentItem(@"TestingData\", "TestingData")]
  public class DataObservableTests
  {
    [TestMethod()]
    public void DataObservableTest()
    {
      Assert.IsTrue(File.Exists(_fileName));
      List<IDataEntity> _buffer = new List<IDataEntity>();
      Stopwatch _watch = Stopwatch.StartNew();
      TestTraceSource _trace = new TestTraceSource();
      using (DataObservable _dataSource = new DataObservable(_fileName, TestTextReaderProtocolParameters.InstanceData(), _trace))
      {
        Exception _exception = null;
        int _nextExecutedCount = 0;
        Assert.AreEqual<double>(1000, TestTextReaderProtocolParameters.InstanceData().DelayFileScan);
        using (IDisposable _client = _dataSource
          .Do<IDataEntity>(x => _nextExecutedCount++)
          .Subscribe(x => { _buffer.Add(x); _watch.Stop(); }, exception => _exception = exception))
        {
          Assert.AreEqual<int>(0, _buffer.Count);
          string[] _content = File.ReadAllLines(_fileName);
          Assert.AreEqual<int>(2422, _content.Length);
          File.WriteAllLines(_fileName, _content);
          Thread.Sleep(2200);
          Assert.IsNull(_exception, $"{_exception}");
          Assert.AreEqual<int>(1, _trace.TraceBuffer.Count);
          Console.WriteLine(_trace.TraceBuffer[0].ToString());
          Assert.AreEqual<int>(1, _nextExecutedCount, $"Execution count: {_nextExecutedCount}");
          Assert.AreEqual<int>(1, _buffer.Count);
          Assert.AreEqual<int>(39, _buffer[0].Tags.Length);
          Assert.AreEqual<string>("09-12-16", _buffer[0].Tags[0]);
          Assert.AreEqual<string>("09:24:02", _buffer[0].Tags[1]);
          Assert.AreEqual<string>("", _buffer[0].Tags[38]);
          Assert.IsTrue(_watch.ElapsedMilliseconds > 2000, $"Elapsed: {_watch.ElapsedMilliseconds}"); //1000nS for Buffer + 1000 for Delay
          Console.WriteLine($"Time execution: {_watch.ElapsedMilliseconds}");
        }
      }
    }

    #region test instrumentation

    private const string _fileName = @"TestingData\g1765xa1.1";

    private class TestTraceSource : ITraceSource
    {
      public List<Tuple<TraceEventType, int, string>> TraceBuffer { get; private set; } = new List<Tuple<TraceEventType, int, string>>();

      public void TraceMessage(TraceEventType eventType, int id, string message)
      {
        TraceBuffer.Add(new Tuple<TraceEventType, int, string>(eventType, id, message));
      }
    }

    private class TestTextReaderProtocolParameters : TextReaderProtocolParameters
    {
      private static TestTextReaderProtocolParameters m_Signleton;

      public static TestTextReaderProtocolParameters InstanceData()
      {
        if (m_Signleton == null)
          m_Signleton = new TestTextReaderProtocolParameters();
        return m_Signleton;
      }

      public override string ToString()
      {
        return $"ColumnSeparator: \"{ColumnSeparator}\", DelayFileScann: {TimeSpan.FromMilliseconds(DelayFileScan)}, Timeout: {TimeSpan.FromMilliseconds(FileModificationNotificationTimeout)}";
      }
    }

    #endregion test instrumentation
  }
}