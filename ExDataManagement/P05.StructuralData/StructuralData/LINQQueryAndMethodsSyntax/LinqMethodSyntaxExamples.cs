//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace TP.StructuralData.LINQQueryAndMethodsSyntax
{

  public static class LinqMethodSyntaxExamples
  {
    public static string MethodSyntax()
    {
      string[] _words = { "apple", "strawberry", "grape", "peach", "banana" };
      IEnumerable<string> _wordQuery = _words.Where<string>(word => word[0] == 'g').Select<String, String>(word => word);
      return String.Join(";", _wordQuery.ToArray());
    }
    public static string MethodSyntaxSideEffect()
    {
      string[] _words = new string[] { "apple", "strawberry", "grape", "peach", "banana" };
      //IEnumerable<string> _wordQuery = from word in _words where word[0] == 'g' select word;
      IEnumerable<string> _wordQuery = _words.Where<string>(word => word[0] == 'g');
      _words[2] = "pear";
      return String.Join(";", _wordQuery.ToArray());
    }
    public static string AnonymousType()
    {
      Customer[] customers = new Customer[] { new Customer() { City = "Phoenix", Name = "Name1", Revenue=11.0E3F  },
                                              new Customer() { City = "NewYork", Name = "Name2", Revenue=12.0E4F   },
                                              new Customer() { City = "Phoenix", Name = "Name3", Revenue=13.0E4F   },
                                              new Customer() { City = "Washington", Name = "Name4", Revenue=14.0E4F   }
      };
      var _customerQuery = customers.Where(_customer => _customer.City == "Phoenix").Select(_customer => new { _customer.Name, _customer.Revenue });
      return String.Join("; ", _customerQuery.Select(x => $"{x.Name}:{x.Revenue.ToString("F", CultureInfo.InvariantCulture)}").ToArray<string>());
    }

  }
}
