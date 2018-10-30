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
    public Catalog(IEnumerable<IPerson> persons) : this()
    {
      foreach (IPerson _item in persons)
      {
        PersonRow _newPersonROw = Person.AddPersonRow(_item.FirstName, _item.LastName, _item.Age);
        foreach (ICDCatalog _cdEntity in _item.CDs)
          this.CDCatalogEntity.AddCDCatalogEntityRow(_cdEntity.Title, _newPersonROw, _cdEntity.Country, _cdEntity.Price, _cdEntity.Year);
      }
    }
    public partial class PersonDataTable
    {
      public IEnumerable<PersonRow> FilterPersonsByLastName_ForEach(string lastName)
      {
        List<PersonRow> _result = new List<PersonRow>();
        foreach (PersonRow _row in this)
          if (_row.LastName.Equals(lastName))
            _result.Add(_row);
        return _result;
      }
      /// <summary>
      /// It uses extension method .Where() and lambda predicate to match each object.
      /// </summary>
      /// <param name="lastName">Value of Person's last name - used for direct comparison in .Equals() calls.</param>
      /// <returns>Enumerable source of Person objects that match given last name.</returns>
      public IEnumerable<PersonRow> FilterPersonsByLastName_MethodSyntax(string lastName)
      {
        return this.Where(_person => _person.LastName.Equals(lastName));
      }
      /// <summary>
      /// It uses LINQ to Objects expression.
      /// </summary>
      /// <param name="lastName">Person's last name.</param>
      public IEnumerable<PersonRow> FilterPersonsByLastName_QuerySyntax(string lastName)
      {
        return from _person in this
               where _person.LastName.Equals(lastName)
               select _person;
      }
    }
  }
}
