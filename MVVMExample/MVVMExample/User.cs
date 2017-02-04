using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.MVVMExample
{
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Boolean Active { get; set; }

        public override string ToString()
        {
            return Name + " " + Age + " " + Active;
        }
    }
}
