using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA.ApplicationArchitecture.Data
{
    public class GenericClass<T>
    {
        public List<T> GenericList;
        public T GenericField;
        public T GenericProperty { get; set; }
        public T GenericMethod(T arg) { return arg; }
    }
}
