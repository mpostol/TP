
//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

namespace TP.StructuralData.LINQ_to_object
{
  /// <summary>
  /// Person - class to represent person data.
  /// </summary>
  public class Person
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public uint Age { get; set; }
    /// <summary>
    /// Parameterless constructor, initializes all properties with default values.
    /// </summary>
    public Person() { }
    /// <summary>
    /// Convenience constructor, initializes properties with given values.
    /// </summary>
    /// <param name="firstName">First name of new Person.</param>
    /// <param name="lastName">Last name of new Person.</param>
    /// <param name="age">Age of new Person.</param>
    public Person(string firstName, string lastName, uint age)
    {
      FirstName = firstName;
      LastName = lastName;
      Age = age;
    }
  }
}
