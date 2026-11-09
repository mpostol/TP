
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

namespace AdaptiveProgramming.Logging.UnitTest.Instrumentation
{
  internal class CircularBuffer<T>
  {
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
    internal int Size { get; private set; }
    private readonly Queue<T> queue = new Queue<T>();
  }

}

