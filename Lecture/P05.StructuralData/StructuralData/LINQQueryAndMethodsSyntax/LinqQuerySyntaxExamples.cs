//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System.Collections.Generic;
using System.Linq;

namespace TP.StructuralData.LINQQueryAndMethodsSyntax
{
  public static class LinqQuerySyntaxExamples
  {

    /// <summary>
    /// From clause example
    /// </summary>
    public static string QuerySyntax()
    {
      string[] _words = { "apple", "strawberry", "grape", "peach", "banana" };
      IEnumerable<string> _wordQuery = from word in _words
                                       where word[0] == 'g'
                                       select word;
      return string.Join(";", _wordQuery.ToArray());
    }
    public static string ForeachInstructionExample()
    {
      string[] _words = { "apple", "strawberry", "grape", "peach", "banana" };
      List<string> _wordQuery = new List<string>();
      foreach (string _item in _words)
        if (_item[0] == 'g')
          _wordQuery.Add(_item);
      return string.Join(";", _wordQuery.ToArray());
    }
    /// <summary>
    /// Defered execution
    /// </summary>DeferedExecution
    public static string DeferedExecution()
    {
      string[] _words = new string[] { "apple", "strawberry", "grape", "peach", "banana" };
      IEnumerable<string> _wordQuery = from word in _words
                                       where word[0] == 'g'
                                       select word;
      _words[2] = "pear";
      return string.Join(";", _wordQuery.ToArray());
    }
    /// <summary>
    ///How to use an anonymous type in the select clause
    /// </summary>
    public static string AnonymousType()
    {
      Customer[] customers = new Customer[] { new Customer() { City = "Phoenix", Name = "Name1", Revenue=11.0E3F  },
                                              new Customer() { City = "NewYork", Name = "Name2", Revenue=12.0E4F   },
                                              new Customer() { City = "Phoenix", Name = "Name3", Revenue=13.0E4F   },
                                              new Customer() { City = "Washington", Name = "Name4", Revenue=14.0E4F   }
      };
      var _customerQuery = from _customer in customers // var is required because the select clause specifies an anonymous type 
                           where _customer.City == "Phoenix"
                           select new { _customer.Name, _customer.Revenue };
      return string.Join("; ", _customerQuery.Select(x => $"{x.Name}:{x.Revenue:F}").ToArray<string>());
    }

  }
}
