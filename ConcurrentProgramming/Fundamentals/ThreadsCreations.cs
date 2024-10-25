//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2024, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//_____________________________________________________________________________________________________________________________________

namespace TP.ConcurrentProgramming.Fundamentals
{
  public static class ThreadsCreations
  {
    public static Thread StartThread(ParameterizedThreadStart start)
    {
      Thread thread = new Thread(start);
      thread.Start();
      return thread;
    }

    public static void StartThreadsUsingThreadPool(WaitCallback start)
    {
      ThreadPool.QueueUserWorkItem(start);
    }

    public static Task StartThreadsUsingTask(Action start)
    {
      return Task.Run(start);
    }
  }
}