//__________________________________________________________________________________________________
//
//  Copyright (C) 2025, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GitHub: https://github.com/mpostol/OPC-UA-OOI/discussions
//__________________________________________________________________________________________________

namespace TP.ConcurrentProgramming.CommonDataConsistency.UnitTest
{
    [TestClass]
    public class IncorrectRecordBasedCriticalSectionTest
    {
        /// <summary>
        /// Test lack of data consistency using manually created <seealso cref="Thread"/>.
        /// </summary>
        [TestMethod]
        public void LackOfDataConsistencyUsingManuallyCreatedThreads()
        {
            IncorrectRecordBasedCriticalSection m_ThreadsExample = new IncorrectRecordBasedCriticalSection();
            RunConcurrentlyManualyCreatedThreads(m_ThreadsExample.NoProtectedMethod);
            Assert.IsFalse(m_ThreadsExample.IsConsistent);
        }

        /// <summary>
        /// Test how to protect data consistency using critical section implemented using Monitor and manually created <seealso cref="Thread"/>.
        /// </summary>
        [TestMethod]
        public void CriticalSectionImplementedUsingMonitorManuallyCreatedThreads()
        {
            IncorrectRecordBasedCriticalSection m_ThreadsExample = new IncorrectRecordBasedCriticalSection();
            RunConcurrentlyManualyCreatedThreads(m_ThreadsExample.ProtectedMethod);
            Assert.IsTrue(m_ThreadsExample.IsConsistent);
        }

        /// <summary>
        /// Test lack of data consistency using <seealso cref="ThreadPool"/>.
        /// </summary>
        [TestMethod]
        public void LackOfDataConsistencyUsingThreadPool()
        {
            IncorrectRecordBasedCriticalSection m_ThreadsExample = new IncorrectRecordBasedCriticalSection();
            RunThreadsUsingThreadPool(m_ThreadsExample.NoProtectedMethod);
            Assert.IsFalse(m_ThreadsExample.IsConsistent);
        }

        /// <summary>
        /// Test how to protect data consistency using critical section implemented using Monitor and <seealso cref="ThreadPool"/>.
        /// </summary>
        [TestMethod]
        public void CriticalSectionImplementedUsingMonitorThreadPool()
        {
            IncorrectRecordBasedCriticalSection m_ThreadsExample = new IncorrectRecordBasedCriticalSection();
            RunThreadsUsingThreadPool(m_ThreadsExample.ProtectedMethod);
            Assert.IsTrue(m_ThreadsExample.IsConsistent);
        }

        /// <summary>
        /// Test lack of data consistency using manually created <seealso cref="Task"/>
        /// </summary>
        [TestMethod]
        public void CheckConsistencyUsingTaskNoMonitor()
        {
            IncorrectRecordBasedCriticalSection m_ThreadsExample = new IncorrectRecordBasedCriticalSection();
            RunThreadsUsingTask(m_ThreadsExample.NoProtectedMethod);
            Assert.IsFalse(m_ThreadsExample.IsConsistent);
        }

        /// <summary>
        /// Test how to protect data consistency using critical section implemented using Monitor and <seealso cref="Task"/>.
        /// </summary>
        [TestMethod]
        public void CheckWhetherThreadsUsingThreadPoolAreSynchronized()
        {
            IncorrectRecordBasedCriticalSection m_ThreadsExample = new IncorrectRecordBasedCriticalSection();
            RunThreadsUsingTask(m_ThreadsExample.ProtectedMethod);
            Assert.IsTrue(m_ThreadsExample.IsConsistent);
        }

        #region Test Instrumentation

        private void RunConcurrentlyManualyCreatedThreads(ParameterizedThreadStart start)
        {
            if (start == null)
                throw new ArgumentNullException(nameof(start));
            Thread[] threadsArray = new Thread[2];
            for (int i = 0; i < threadsArray.Length; i++)
                threadsArray[i] = new Thread(start);
            foreach (Thread _thread in threadsArray)
                _thread.Start();
            foreach (Thread _thread in threadsArray)
                _thread.Join();
        }

        private void RunThreadsUsingThreadPool(WaitCallback callBack)
        {
            for (int i = 0; i < 2; i++)
                ThreadPool.QueueUserWorkItem(callBack);
            //wait for threads
            //TODO must be improved it could cause race condition
            Thread.Sleep(1000);
        }

        private void RunThreadsUsingTask(WaitCallback callBack)
        {
            if (callBack == null)
                throw new ArgumentNullException(nameof(callBack));
            List<Task> _tasksInProgress = new List<Task>();
            for (int i = 0; i < 2; i++)
                _tasksInProgress.Add(Task.Run(() => callBack(null)));
            //wait for threads
            Task.WaitAll(_tasksInProgress.ToArray());
        }

        #endregion Test Instrumentation
    }
}