//https://msdn.microsoft.com/en-us/library/vstudio/bb397696.aspx?f=255&MSPPError=-2147217396

using System;
using System.Collections.Generic;

namespace TP.Lecture
{

  public class AnonymousTypes
  {

    public string AnonymousTypesMyTestMethod1()
    {
      var v = new { Amount = 108, Message = "Hello" };
      return String.Format("{0}-{1}", v.Amount, v.Message);
    }

    //var vs dynamic
    //var v = new { Amount = 108, Message = "Hello" };
    dynamic v = new { Amount = 108, Message = "Hello" };

    /// <summary>
    /// Anonymouses types compatybility.
    /// </summary>
    /// <returns>System.String.</returns>
    public string AnonymousTypesMyTestMethod2()
    {
      var v = new { Amount = 108, Message = "Hello" };
      var v2 = new { Amount = 300, Message = "Eello" };
      v = v2;
      return String.Format("{0}-{1}", v.Amount, v.Message);
    }
    public string AnonymousTypesMyTestMethod3()
    {
      var v = new { Amount = 108, Message = "Hello" };
      var v2 = new { Message = "Eello", Amount = 300 };
      //v = v2;
      return String.Format("{0}-{1}", v2.Amount, v.Message);
    }
    public string AnonymousTypesMyTestMethod4()
    {
      var anonArray = new[] { 
                              new { name = "apple", diam = 4 }, 
                              new { name = "grape", diam = 1 },
                              //new { diam = 2, name = "plum"  } 
                             };
      List<string> content = new List<string>();
      foreach (var item in anonArray)
        content.Add(String.Format("{0}-{1}", item.name, item.diam));
      return String.Join(", ", content.ToArray());
    }
    public string AnonymousTypesMyTestMethod5()
    {
      var v = new { Amount = 108, Message = "Hello" };
      var v2 = new { Amount = 300.12, Message = "Eello" };
      //v = v2;
      return String.Format("{0}-{1}", v2.Amount, v2.Message);
    }
  }
}
