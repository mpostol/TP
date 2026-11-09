
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

using System.Diagnostics;
using System.Reactive.Linq;
using System.Reflection;

namespace AdaptiveProgramming.Logging.UnitTest.Instrumentation
{
  internal static class Extensions
  {
    internal static string? GetFileName(this DelimitedListTraceListener _listener)
    {
      FieldInfo? fi = typeof(TextWriterTraceListener).GetField("fileName", BindingFlags.NonPublic | BindingFlags.Instance);
      if (fi == null)
        throw new NullReferenceException(nameof(fi));
      return (string?)fi.GetValue(_listener);
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
}


