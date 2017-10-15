using System;
using System.Threading;

namespace TPA.AsynchronousBehavior.Threading
{
    public class ThreadsExample
    {
        /// <summary>
        /// Gets a value indicating whether this instance is consistent.
        /// </summary>
        /// <remarks>Always must be true.</remarks>
        /// <value><c>true</c> if this instance is consistent; otherwise, <c>false</c>.</value>
        public bool IsConsistent { get; private set; } = true;
        public void StartThreads(bool useMonitor)
        {
            for (int i = 0; i < m_Threads.Length; i++)
            {
                if (useMonitor)
                    m_Threads[i] = new Thread(ThreadFuncWithMonitor);
                else
                    m_Threads[i] = new Thread(ThreadFunc);
            }
            foreach (Thread _thread in m_Threads)
                _thread.Start();
            foreach (Thread _thread in m_Threads)
                _thread.Join();
        }
        public void StartThreadsUsingThreadPool(bool useMonitor)
        {
            for (int i = 0; i < 2; i++)
                if (useMonitor)
                    ThreadPool.QueueUserWorkItem(ThreadFuncWithMonitor);
                else
                    ThreadPool.QueueUserWorkItem(ThreadFunc);
            //wait for threads
            Thread.Sleep(1000);
        }
        private readonly Thread[] m_Threads = new Thread[2];
        private readonly object m_SyncObject = new object();
        private int m_IntegerA = 0;
        private int m_IntegerB = 0;
        private Random m_Random = new Random();
        private void ThreadFunc(object parameter)
        {
            DataProcessingSimulator();
        }
        private void ThreadFuncWithMonitor(object parameter)
        {
            lock (m_SyncObject)
            {
                DataProcessingSimulator();
            }
        }
        private void DataProcessingSimulator()
        {
            for (int i = 0; i < 1000000; i++)
            {
                int _value = m_Random.Next();
                m_IntegerA += _value;
                m_IntegerB -= _value;
                IsConsistent &= m_IntegerA - m_IntegerB == 0;
            }
        }
    }
}
