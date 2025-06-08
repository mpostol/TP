//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2025, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//_____________________________________________________________________________________________________________________________________

using TP.ConcurrentProgramming.CommonDataConsistency;

namespace CommonDataConsistencyUnitTest
{
    [TestClass]
    public class RecordBasedConsistencyUnitTest
    {
        [TestMethod]
        public void RecordBasedConsistencyTestMethod()
        {
            Thread thread = new Thread(Worker);
            thread.Start();
            thread.Join();
            Assert.IsTrue(comonResources.IsConsistent);
            Assert.IsFalse(comonResources.IsInconsistent);
        }

        #region Test Instrumentation

        private Random m_Random = new Random();
        private RecordBasedConsistency comonResources = new RecordBasedConsistency();

        private void Worker()
        {
            for (int i = 0; i < 1000000; i++)
            {
                int value = m_Random.Next(0, 10000);
                comonResources.ComplexValue = new RecordBasedConsistency.ComplexValueType(value, -value);
            }
        }

        #endregion Test Instrumentation
    }
}