using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA.Reflection.Model
{
    class ClassWithDynamic
    {
        public dynamic DynamicMethod(dynamic value)
        {
            value += 1;

            return value;
        }
    }
}
