using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA.Reflection.UnitTest.Execution
{
  internal class DataConsumer
  {
    private int m_intField;
    public int IntPropertyConsumer {
      get { return m_intField; }
      set { m_intField = value; }
    }
  
    private string m_stringField;
    public string StringPropertyConsumer {
      get { return m_stringField; }
      set { m_stringField = value; }
    }
  
    private ValueType m_valueTypeField;
    public ValueType ValuePropertyConsumer {
      get { return m_valueTypeField; }
      set { m_valueTypeField = value; }
    }
  }
}
