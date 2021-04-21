using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA.ApplicationArchitecture.Data.API
{
    internal interface IFactory
    {
        ILinq2SQL CreateLinq2SQL();
    }
}
