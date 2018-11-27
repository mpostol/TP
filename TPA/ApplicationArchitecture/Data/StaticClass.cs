using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA.ApplicationArchitecture.Data
{
    public static class StaticClass
    {
        public static int StaticField;
        public static int StaticProperty { get; set; }
        public static void StaticMethod1() { }
        public static float StaticMethod2() { return 0f; }
    }
}
