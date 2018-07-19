using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA.Reflection.UnitTest.Execution
{
    internal class DataConsumer
    {
        private int _intField;
        public int IntPropertyConsumer {
            get { return _intField; }
            set { _intField = value; }
        }

        private string _stringField;
        public string StringPropertyConsumer {
            get { return _stringField; }
            set { _stringField = value; }
        }

        private ValueType _valueTypeField;
        public ValueType ValuePropertyConsumer {
            get { return _valueTypeField; }
            set { _valueTypeField = value; }
        }


    }
}
