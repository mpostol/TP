
using System.Collections.Generic;

namespace TP.MVVMExample.Model
{
  internal class DataLayer
  {
    internal IEnumerable<User> User
    {
      get
      {
        List<User> Users = new List<User>();
        Users.Add(new User() { Age = 21, Name = "Jan", Active = true });
        Users.Add(new User() { Age = 22, Name = "Stefan", Active = false });
        return Users;
      }
    }
  }
}
