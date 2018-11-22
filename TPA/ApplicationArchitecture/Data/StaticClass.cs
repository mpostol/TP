using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA.ApplicationArchitecture.Data
{
    public static class StaticClass
    {
        /*TODO:
        + class 
        + structure
        - nested class
        + static class
        - enum
        + inheritance
        + abstact class
        + interface
        - delegate
        + attribute
        + property
        + field
        + circular reference
        - generic class
        */
        public static int StaticField;
        public static int StaticProperty { get; set; }
        public static void StaticMethod1() { }
        public static float StaticMethod2() { return 0f; }
    }
}
