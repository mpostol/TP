//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2025, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//_____________________________________________________________________________________________________________________________________

namespace TP.ConcurrentProgramming.CommonDataConsistency
{
    public class RecordBasedConsistency
    {
        #region public API

        public record ComplexValueType(int Value1, int Value2);
        public ComplexValueType ComplexValue { get; set; } = new ComplexValueType(0, 0);

        #endregion public API

        public RecordBasedConsistency()
        {
            Thread thread = new Thread(Worker);
            thread.Start();
        }

        private void Worker()
        {
            while (true)
            {
                //wrong implementation
                IsInconsistent &= ComplexValue.Value1 + ComplexValue.Value2 == 0;
                //correct implementation
                ComplexValueType privateComplexValue = ComplexValue;
                IsConsistent &= privateComplexValue.Value1 + privateComplexValue.Value2 == 0;
            }
        }

        public bool IsConsistent { get; set; } = true;
        public bool IsInconsistent { get; set; } = true;
    }
}