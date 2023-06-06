using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.GraphicalData.Model.IMP;

namespace TP.GraphicalData.Model.API
{
    public abstract class DataLayerAPI
    {
        public IEnumerable<IUser> User { get; }

        public static DataLayerAPI Create()
        {
            return new DataLayer();
        }
    }
}
