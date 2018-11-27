using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA.ApplicationArchitecture.Data
{
    public class OuterClass
    {
        class InnerClass
        {
            public int InnerProperty { get; set; }
        }

        private InnerClass InnerClassInstance;
    }
}
