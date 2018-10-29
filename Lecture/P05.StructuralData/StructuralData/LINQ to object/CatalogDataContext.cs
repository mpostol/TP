//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System.Collections.Generic;
using System.Linq;

namespace TP.StructuralData.LINQ_to_object
{
  public class CatalogDataContext
  {

    /// <summary>
    /// Adds given person object to underlying collection.
    /// </summary>
    /// <param name="p">Person object to add to collection.</param>
    public void AddPerson(Person p)
    {
      Persons.Add(p);
    }
    /// <summary>
    /// Retrieves a copy of all objects references from underlying collection,
    /// as enumerable source of Persons, so original collection stays unmodified.
    /// </summary>
    /// <returns>Enumerable source of all Person objects from collection.</returns>
    public IEnumerable<Person> GetAllPersons()
    {
      return new List<Person>(Persons);
    }
    /// <summary>
    /// First version of filtering Person objects by last name, that uses traditional
    /// iteration over collection and .Equals() call for strings.
    /// </summary>
    /// <param name="lastName">Value of Person's last name - used for direct comparison in .Equals() calls.</param>
    /// <returns>Enumerable source of Person objects that match given last name.</returns>
    public IEnumerable<Person> FilterPersonsByLastName_ForEach(string lastName)
    {
      List<Person> result = new List<Person>();
      foreach (Person p in Persons)
        if (p.LastName.Equals(lastName))
          result.Add(p);
      return result;
    }
    /// <summary>
    /// Second version of filtering Person objects by last name, that uses collection's
    /// extension method .Where() and lambda predicate to match each object.
    /// </summary>
    /// <param name="lastName">Value of Person's last name - used for direct comparison in .Equals() calls.</param>
    /// <returns>Enumerable source of Person objects that match given last name.</returns>
    public IEnumerable<Person> FilterPersonsByLastName_ExtensionMethod(string lastName)
    {
      IEnumerable<Person> expression = Persons.Where(p => p.LastName.Equals(lastName));
      return expression;
    }
    /// <summary>
    /// Third and final version of filtering Person objects by last name, that uses
    /// LINQ to Objects expression.
    /// </summary>
    /// <param name="lastName">Value of Person's last name - used for direct comparison in .Equals() calls.</param>
    /// <returns>Enumerable source of Person objects that match given last name.</returns>
    public IEnumerable<Person> FilterPersonsByLastName(string lastName)
    {
      //System.Linq.Enumerable.WhereListIterator
      IEnumerable<Person> _expression =
          from Person p in Persons
          where p.LastName.Equals(lastName)
          select p;
      return _expression;
    }
    /// <summary>
    /// Filters Person objects by minimum age.
    /// </summary>
    /// <param name="minAge">Minimum age of a Person to match.</param>
    /// <returns>Enumerable source of Person objects that match or exceed given minimum age.</returns>
    public IEnumerable<Person> FilterPersonsByMinAge(int minAge)
    {
      IEnumerable<Person> _expression =
          from Person p in Persons
          where p.Age >= minAge
          select p;
      return _expression;
    }

    internal List<Person> Persons { get; } = new List<Person>();
    internal List<CDCatalog> CDCatalogs { get; } = new List<CDCatalog>();
  }
}
