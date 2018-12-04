using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA.ApplicationArchitecture.Data
{

    class ClassWithDelegate
    {
        public static void DelegateMethod(string message)
        {
            System.Console.WriteLine(message);
        }

        public delegate void Del(string message);

        public ClassWithDelegate()
        {
            Del handler = DelegateMethod;

            handler("Constructor called");
        }

    }
}
