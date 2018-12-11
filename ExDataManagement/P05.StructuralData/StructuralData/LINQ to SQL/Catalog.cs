//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TP.StructuralData.Data;

namespace TP.StructuralData.LINQ_to_SQL
{
  public partial class CatalogDataContext
  {
    public void AddContent(IEnumerable<IPerson> persons)
    {
      foreach (IPerson _item in persons)
      {
        Person _newPerson = new Person()
        {
          FirstName = _item.FirstName,
          LastName = _item.LastName,
          Age = _item.Age
        };
        this.Persons.InsertOnSubmit(_newPerson);
        foreach (ICDCatalog _cdEntity in _item.CDs)
        {
          CDCatalogEntity _newEntity = new CDCatalogEntity()
          {
            Title = _cdEntity.Title,
            Person = _newPerson,
            Country = _cdEntity.Country,
            Price = _cdEntity.Price,
            Year = (short)_cdEntity.Year
          };
          this.CDCatalogEntities.InsertOnSubmit(_newEntity);
        }
        this.SubmitChanges();
      }
    }
    public IEnumerable<Person> FilterPersonsByLastName_ForEach(string lastName)
    {
      List<Person> _result = new List<Person>();
      foreach (Person _row in this.Persons)
        if (_row.LastName.Equals(lastName))
          _result.Add(_row);
      return _result;
    }
    public IEnumerable<Person> FilterPersonsByLastName_QuerySyntax(string lastName)
    {
      return from _person in this.Persons
             where _person.LastName.Equals(lastName)
             select _person;
    }
    public IEnumerable<Person> FilterPersonsByLastName_MethodSyntax(string lastName)
    {
      return this.Persons.Where(_person => _person.LastName.Equals(lastName));
    }
    public string FilterPersonsByLastName_AnonymousType(string lastName)
    {
      var _firstNames = from _person in this.Persons
                        select new { _person.FirstName };
      return string.Join(", ", _firstNames.Select(x => x.FirstName).ToArray<string>());
    }
    /// <summary>
    /// Helper method to quickly remove all entities from the table.
    /// This method is intended to be used in unit tests so it is marked by the <see cref="Conditional"/> attribute and implemented for the "DEBUG" configuration only.
    /// </summary>
    [Conditional("DEBUG")]
    public void TruncateAllData()
    {
      CDCatalogEntities.DeleteAllOnSubmit<CDCatalogEntity>(CDCatalogEntities);
      Persons.DeleteAllOnSubmit<Person>(Persons);
      SubmitChanges();
    }

  }
}
