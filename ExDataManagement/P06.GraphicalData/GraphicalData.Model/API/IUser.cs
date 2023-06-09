using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.GraphicalData.Model.API
{
    public interface IUser
    {
        string Name { get; set; }
        
        int Age { get; set; }

        bool Active { get; set; }

    }
}
