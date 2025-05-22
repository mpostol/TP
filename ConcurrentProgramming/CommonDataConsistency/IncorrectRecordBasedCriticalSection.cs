//__________________________________________________________________________________________________
//
//  Copyright (C) 2025, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GitHub: https://github.com/mpostol/OPC-UA-OOI/discussions
//__________________________________________________________________________________________________

namespace TP.ConcurrentProgramming.CommonDataConsistency
{
    /// <summary>
    /// Code sample to examine data consistence in the concurrent programming environment
    /// </summary>
    public class IncorrectRecordBasedCriticalSection
    {
        #region Monitor methods

        public void NoProtectedMethod(object? state)
        {
            CommonDataProcessingSimulator();
        }

        public void ProtectedMethod(object? state)
        {
            bool lockWasTaken = false;
            try
            {
                Monitor.Enter(this, ref lockWasTaken);
                if (!lockWasTaken)
                    throw new ArgumentException();
                CommonDataProcessingSimulator();
            }
            finally
            {
                if (lockWasTaken)
                    Monitor.Exit(this);
            }
        }

        #endregion Monitor methods

        #region private

        private record IntegerComplex(int A, int B);
        private IntegerComplex? valueToTest = null;
        private Random m_Random = new Random();

        private void CommonDataProcessingSimulator()
        {
            for (int i = 0; i < 1000000; i++)
            {
                int _value = m_Random.Next(0, 10000);
                valueToTest = new IntegerComplex(_value, -_value);
                IsConsistent &= valueToTest.A + valueToTest.B == 0;
            }
        }

        #endregion private

        #region UT Instrumentation

        /// <summary>
        /// Gets a value indicating whether this instance is consistent.
        /// </summary>
        /// <remarks>Always must be true.</remarks>
        /// <value><c>true</c> if this instance is consistent; otherwise, <c>false</c>.</value>
        public bool IsConsistent = true;

        #endregion UT Instrumentation
    }
}