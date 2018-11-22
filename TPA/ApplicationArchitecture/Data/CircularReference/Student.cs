using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA.ApplicationArchitecture.Data.CircularReference
{
    public class Student
    {
        public List<Teacher> Teachers;
    }
}
