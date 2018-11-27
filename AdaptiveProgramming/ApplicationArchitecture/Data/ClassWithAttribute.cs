using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA.ApplicationArchitecture.Data
{
    [Serializable]
    public class ClassWithAttribute
    {
        [Obsolete]
        public float FieldWithAttribute;
    }
}
