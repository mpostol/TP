///____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System.Collections.Generic;
using System.Linq;

namespace TP.StructuralData.LINQ_to_object
{
  public partial class Catalog
  {
    public Catalog(IEnumerable<Person> persons) : this()
    {
      foreach (Person _item in persons)
        Person.AddPersonRow(_item.FirstName, _item.LastName, _item.Age);
    }
    public partial class PersonDataTable
    {
      public IEnumerable<PersonRow> FilterPersonsByLastName_ForEach(string lastName)
      {
        List<PersonRow> result = new List<PersonRow>();
        foreach (PersonRow _row in this)
          if (_row.LastName.Equals(lastName))
            result.Add(_row);
        return result;
      }
      /// <summary>
      /// It uses extension method .Where() and lambda predicate to match each object.
      /// </summary>
      /// <param name="lastName">Value of Person's last name - used for direct comparison in .Equals() calls.</param>
      /// <returns>Enumerable source of Person objects that match given last name.</returns>
      public IEnumerable<PersonRow> FilterPersonsByLastName_MethodSyntax(string lastName)
      {
        return this.Where(p => p.LastName.Equals(lastName));
      }
      /// <summary>
      /// It uses LINQ to Objects expression.
      /// </summary>
      /// <param name="lastName">Person's last name.</param>
      public IEnumerable<PersonRow> FilterPersonsByLastName_QuerySyntax(string lastName)
      {
        return from p in this
               where p.LastName.Equals(lastName)
               select p;
      }
    }
  }
}
