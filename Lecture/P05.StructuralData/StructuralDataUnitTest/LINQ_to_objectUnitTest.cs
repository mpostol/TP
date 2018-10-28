//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TP.StructuralData.LINQ_to_object;

namespace TP.StructuralDataUnitTest
{
  [TestClass]
  public class LINQ_to_objectUnitTest
  {
    [TestMethod]
    public void DataService_AfterCreation_CollectionIsEmpty()
    {
      Assert.IsNotNull(m_Service);
      IEnumerable<Person> _initialData = m_Service.GetAllPersons();
      Assert.AreEqual(0, _initialData.Count());
    }
    [TestMethod]
    public void AddPerson_AddedPerson_IsTheFirstAndOnlyOneInCollection()
    {
      Person _person = new Person();
      m_Service.AddPerson(_person);
      IEnumerable<Person> data = m_Service.GetAllPersons();
      Assert.AreEqual(1, data.Count());
      Assert.AreSame(data.First(), _person);
    }
    [TestMethod]
    public void GetAllPersons_AfterAdding0PersonsFromArray_CountShouldBeEqual()
    {
      Person[] input = GetAllPersonsTest_InputCases[0];
      AddPersonsFromArray(input);
      IEnumerable<Person> dataAfterAdding = m_Service.GetAllPersons();
      Assert.AreEqual(input.Length, dataAfterAdding.Count());
    }
    [TestMethod]
    public void GetAllPersons_AfterAdding2PersonsFromArray_CountShouldBeEqual()
    {
      Person[] input = GetAllPersonsTest_InputCases[1];
      AddPersonsFromArray(input);
      IEnumerable<Person> dataAfterAdding = m_Service.GetAllPersons();
      Assert.AreEqual(input.Length, dataAfterAdding.Count());
    }
    [TestMethod]
    public void GetAllPersons_AfterAdding3PersonsFromArray_CountShouldBeEqual()
    {
      Person[] input = GetAllPersonsTest_InputCases[2];
      AddPersonsFromArray(input);
      IEnumerable<Person> dataAfterAdding = m_Service.GetAllPersons();
      Assert.AreEqual(input.Length, dataAfterAdding.Count());
    }
    [TestMethod]
    public void FilterPersonsByLastName_UseForEach_FindTwoPersons()
    {
      PrepareData();
      IEnumerable<Person> filtered = m_Service.FilterPersonsByLastName_ForEach("Person");
      foreach (Person p in filtered)
        Assert.AreEqual("Person", p.LastName);
      Assert.AreEqual(2, filtered.Count());
    }
    [TestMethod]
    public void FilterPersonsByLastName_UseExtensionMethod_FindTwoPersons()
    {
      PrepareData();
      IEnumerable<Person> filtered = m_Service.FilterPersonsByLastName_ExtensionMethod("Person");
      foreach (Person p in filtered)
        Assert.AreEqual("Person", p.LastName);
      Assert.AreEqual(2, filtered.Count());
    }
    [TestMethod]
    public void FilterPersonsByLastName_UseLinq_FindTwoPersons()
    {
      PrepareData();
      IEnumerable<Person> filtered = m_Service.FilterPersonsByLastName("Person");
      foreach (Person p in filtered)
        Assert.AreEqual("Person", p.LastName);
      Assert.AreEqual(2, filtered.Count());
    }
    [TestMethod]
    public void FilterPersonsByMinAge_CheckExpectedCount_GivenMinAge_25()
    {
      const int minAge = 25, expectedCount = 2;
      PrepareData();
      IEnumerable<Person> filtered = m_Service.FilterPersonsByMinAge(minAge);
      foreach (Person p in filtered)
        Assert.IsTrue(p.Age >= minAge);
      Assert.AreEqual(expectedCount, filtered.Count());
    }
    [TestMethod]
    public void FilterPersonsByMinAge_CheckExpectedCount_GivenMinAge_40()
    {
      const int minAge = 40, expectedCount = 1;
      PrepareData();
      IEnumerable<Person> filtered = m_Service.FilterPersonsByMinAge(minAge);
      foreach (Person p in filtered)
        Assert.IsTrue(p.Age >= minAge);
      Assert.AreEqual(expectedCount, filtered.Count());
    }
    [TestMethod]
    public void FilterPersonsByMinAge_CheckExpectedCount_GivenMinAge_99()
    {
      const int minAge = 99, expectedCount = 0;
      PrepareData();
      IEnumerable<Person> filtered = m_Service.FilterPersonsByMinAge(minAge);
      foreach (Person p in filtered)
        Assert.IsTrue(p.Age >= minAge);
      Assert.AreEqual(expectedCount, filtered.Count());
    }
    [TestMethod]
    public void DispalyContentTest()
    {
      PrepareData();
      IEnumerable<Person> _all = m_Service.GetAllPersons();
      Display("All persons", _all);
      const string lastName = "Person";
      const int minAge = 25;
      Display($"With last name '{lastName}' / ForEach", m_Service.FilterPersonsByLastName_ForEach(lastName));
      Display($"With last name '{lastName}' / Extension", m_Service.FilterPersonsByLastName_ExtensionMethod(lastName));
      Display($"With last name '{lastName}' / LINQ", m_Service.FilterPersonsByLastName(lastName));
      Display("After finishing studies", m_Service.FilterPersonsByMinAge(minAge));
    }

    #region test instrumentation
    [TestInitialize]
    public void Init()
    {
      m_Service = new CatalogDataContext();
    }
    private CatalogDataContext m_Service;
    private static void Display(string title, IEnumerable<Person> data)
    {
      Debug.WriteLine($"*** {title} ***");
      foreach (Person p in data)
        Debug.WriteLine($"Person: {p.FirstName} {p.LastName}, age {p.Age}");
    }
    private static readonly Person[][] GetAllPersonsTest_InputCases = new Person[][] {
            new Person[] { },
            new Person[] { new Person("A", "One", 1), new Person("B", "Two", 2) },
            new Person[] { new Person("A", "One", 1), new Person("B", "Two", 2), new Person("C", "Three", 3) },
        };
    private void AddPersonsFromArray(Person[] input)
    {
      foreach (Person p in input)
        m_Service.AddPerson(p);
    }
    private void PrepareData()
    {
      m_Service.AddPerson(new Person("First", "Person", 20));
      m_Service.AddPerson(new Person("Second", "Person", 30));
      m_Service.AddPerson(new Person("Mister", "Clever", 42));
    }
    #endregion
  }
}
