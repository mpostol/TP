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
using System.Reactive.Linq;
using System.Reflection;

namespace TPA.Logging.UnitTest.Instrumentation
{
  internal static class Extensions
  {
    internal static string GetFileName(this DelimitedListTraceListener _listener)
    {
      FieldInfo fi = typeof(TextWriterTraceListener).GetField("fileName", BindingFlags.NonPublic | BindingFlags.Instance);
      Assert.IsNotNull(fi);
      return (string)fi.GetValue(_listener);
    }

    internal static IObservable<T> FlushOnTrigger<T>(this IObservable<T> stream, Func<T, bool> shouldFlush, int bufferSize)
    {
      return Observable.Create<T>
        (
          observer =>
            {
              CircularBuffer<T> _buffer = new CircularBuffer<T>(bufferSize);
              IDisposable _subscription = stream.Subscribe
              (
                newItem =>
                  {
                    if (shouldFlush(newItem))
                    {
                      foreach (T buffered in _buffer.TakeAll())
                        observer.OnNext(buffered);
                      observer.OnNext(newItem);
                    }
                    else
                      _buffer.Add(newItem);
                  },
              observer.OnError,
              observer.OnCompleted);
              return _subscription;
            }
        );
    }
  }

  internal class CircularBuffer<T>
  {
    internal int Size { get; private set; }

    internal CircularBuffer(int size)
    {
      Size = size;
    }

    internal void Add(T obj)
    {
      queue.Enqueue(obj);
      while (queue.Count > Size)
        queue.Dequeue();
    }

    internal IEnumerable<T> TakeAll()
    {
      List<T> _ret = new List<T>();
      while (queue.Count > 0)
        _ret.Add(queue.Dequeue());
      return _ret;
    }

    private readonly Queue<T> queue = new Queue<T>();
  }
}