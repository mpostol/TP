//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2023, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//  by introducing yourself and telling us what you do with this community.
//_____________________________________________________________________________________________________________________________________

using System.Collections.Generic;
using TP.StructuralData.Data;

namespace TP.StructuralDataUnitTest.Instrumentation
{
  internal static class TestDataGenerator
  {
    internal static IEnumerable<IPerson> PrepareData()
    {
      return new List<Person>()
      {
        new Person("First", "Person", 20),
        new Person("Second", "Person", 30),
        new Person("Mister", "Clever", 42)
      };
    }

    private class Person : IPerson
    {
      public Person(string firstName, string lastName, ushort age)
      {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        for (int i = 0; i < 5; i++)
        {
          _assignedCDs.Add(new CDCatalog()
          {
            Country = $"Country{i}",
            Price = 0,
            Title = $"Title{i}",
            Year = (ushort)(2000 + i)
          });
        }
      }

      #region IPerson

      public ushort Age { get; private set; }
      public string FirstName { get; private set; }
      public string LastName { get; private set; }
      public IEnumerable<ICDCatalog> CDs => _assignedCDs;

      #endregion IPerson

      private List<ICDCatalog> _assignedCDs = new List<ICDCatalog>();
    }

    private class CDCatalog : ICDCatalog
    {
      #region ICDCatalog

      public string Country { get; set; }
      public decimal Price { get; set; }
      public string Title { get; set; }
      public ushort Year { get; set; }

      #endregion ICDCatalog
    }
  }
}