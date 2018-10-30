
//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System.Collections.Generic;

namespace TP.StructuralData.LINQ_to_object
{

  /// <summary>
  /// Person - class to represent person data.
  /// </summary>
  public class Person : IPerson
  {

    /// <summary>
    /// Convenience constructor, initializes properties with given values.
    /// </summary>
    /// <param name="firstName">First name of new Person.</param>
    /// <param name="lastName">Last name of new Person.</param>
    /// <param name="age">Age of new Person.</param>
    public Person(string firstName, string lastName, ushort age)
    {
      FirstName = firstName;
      LastName = lastName;
      Age = age;
    }
    internal void AddCDs(IEnumerable<ICDCatalog> cds)
    {
      this._assignedCDs.AddRange(cds);
    }
    #region IPerson
    public ushort Age { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public IEnumerable<ICDCatalog> CDs { get { return _assignedCDs; } } 
    #endregion

    private List<ICDCatalog> _assignedCDs = new List<ICDCatalog>();

  }
}
