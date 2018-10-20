
//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using LinqToObjectsLib;
using System;
using System.Collections.Generic;

namespace LinqToObjectsApp
{
  internal class LinqToObjectsConsoleApp
  {
    private static void Main(string[] args)
    {
      DataService _service = PrepareData();
      IEnumerable<Person> _all = _service.GetAllPersons();
      Display("All persons", _all);
      Console.WriteLine();
      const string lastName = "Person";
      const int minAge = 25;
      Display($"With last name '{lastName}' / ForEach", _service.FilterPersonsByLastName_ForEach(lastName));
      Display($"With last name '{lastName}' / Extension", _service.FilterPersonsByLastName_ExtensionMethod(lastName));
      Display($"With last name '{lastName}' / LINQ", _service.FilterPersonsByLastName(lastName));
      Console.WriteLine();
      Display("After finishing studies", _service.FilterPersonsByMinAge(minAge));
      Console.ReadLine();
    }
    private static void Display(string title, IEnumerable<Person> data)
    {
      Console.WriteLine($"*** {title} ***");
      foreach (Person p in data)
        Console.WriteLine($"Person: {p.FirstName} {p.LastName}, age {p.Age}");
    }
    private static DataService PrepareData()
    {
      DataService _service = new DataService();
      _service.AddPerson(new Person("First", "Person", 20));
      _service.AddPerson(new Person("Second", "Person", 30));
      _service.AddPerson(new Person("Mister", "Clever", 42));
      return _service;
    }
  }
}
