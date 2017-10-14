using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPA.AsynchronousBehavior.Threading
{
    public class ThreadsExample
    {
        public int A { get; private set; }
        public int B { get; private set; }

        private readonly Thread[] _threads = new Thread[2];
        private readonly object _syncObject = new object();

        public void StartThreads(bool useMonitor)
        {
            A = B = 0;

            for (int i = 0; i < _threads.Length; i++)
            {
                if (useMonitor)
                    _threads[i] = new Thread(ThreadFuncWithMonitor);
                else
                    _threads[i] = new Thread(ThreadFunc);
            }

            foreach (var thread in _threads)
            {
                thread.Start();
            }

            foreach (var thread in _threads)
            {
                thread.Join();
            }
        }

        public void StartThreadsUsingThreadPool(bool useMonitor)
        {
            A = B = 0;

            for (int i = 0; i < 2; i++)
            {
                if (useMonitor)
                    ThreadPool.QueueUserWorkItem(ThreadFuncWithMonitor);
                else
                    ThreadPool.QueueUserWorkItem(ThreadFunc);
            }

            //wait for threads
            Thread.Sleep(1000);
        }

        private void ThreadFunc(object parameter)
        {
            Random r = new Random();

            for (int i = 0; i < 1000000; i++)
            {
                int value = r.Next();
                A += value;
                B -= value;
            }
        }

        private void ThreadFuncWithMonitor(object parameter)
        {
            Monitor.Enter(_syncObject);
            try
            {
                Random r = new Random();

                for (int i = 0; i < 1000000; i++)
                {
                    int value = r.Next();
                    A += value;
                    B -= value;
                }
            }
            finally 
            {
                Monitor.Exit(_syncObject);
            }
        }
    }
}
