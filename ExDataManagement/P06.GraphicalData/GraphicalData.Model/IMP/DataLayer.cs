using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.GraphicalData.Model.API;
namespace TP.GraphicalData.Model.IMP
{
    internal class DataLayer : DataLayerAPI
    {

        public IEnumerable<IUser> Users
        {
            get
            {
                List<IUser> Users = new List<IUser>()
                {
                    new User() { Age = 21, Name = "Jan", Active = true },
                    new User() { Age = 22, Name = "Stefan", Active = false }
                };
                return Users;
            }
        }
    }
}
