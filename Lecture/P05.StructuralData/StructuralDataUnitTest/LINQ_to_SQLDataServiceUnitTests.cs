//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

#define PRINT_PERSONS  //uncomment to print persons to the console in tests that call PrintPersons()

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
using TP.StructuralData.LINQ_to_SQL;

namespace TP.StructuralDataUnitTest
{
  [TestClass]
  public class PersonServiceTests
  {

    [TestInitialize]
    public void Initialize()
    {
      m_Service = new DataService(m_ConnectionString);
    }
    [TestCleanup]
    public void CleanUp()
    {
      // Vital for ensuring that table is empty after each test
      m_Service.TruncateAllPersons();
      // Release database context
      m_Service.Dispose();
    }
    [TestMethod]
    public void PersonService_AfterCreation_DataShouldBeEmpty()
    {
      IEnumerable<CatalogCD> initialData = m_Service.GetAllPersons();
      Assert.AreEqual(0, initialData.Count());
    }
    [TestMethod]
    public void AddPerson_AddedEntity_ShouldBeTheOnlyOneAndCorrectEntity()
    {
      m_Service.AddCD(CreateCatalogCD());
      IEnumerable<CatalogCD> data = m_Service.GetAllPersons();
      PrintPersons(data);
      Assert.AreEqual(1, data.Count());
      Assert.AreNotEqual(0, data.First().Id);
    }
    [TestMethod]
    public void GetAllPersons_ExpectCorrectEntities_WithIncreasingPersonId()
    {
      m_Service.AddCD(CreateCatalogCD(3));
      m_Service.AddCD(CreateCatalogCD(2));
      IEnumerable<CatalogCD> _data = m_Service.GetAllPersons();
      PrintPersons(_data);
      Assert.AreEqual(3 + 2, _data.Count());
      foreach (CatalogCD p in _data)
        Assert.IsFalse(string.IsNullOrEmpty(p.Title));
      for (int i = 1; i < _data.Count(); i++)
        Assert.IsTrue(_data.ElementAt(i - 1).Id < _data.ElementAt(i).Id);
    }
    //[TestMethod]
    //public void FilterPersonsByLastName_FilterTwoSmith_OutOfFivePersons()
    //{
    //  CreateCatalogCD(3);
    //  CreateCatalogCD(2);
    //  IEnumerable<CatalogCD> data = m_Service.FilterPersonsByLastName("Smith");
    //  PrintPersons(data);
    //  Assert.AreEqual(2, data.Count());
    //  foreach (CatalogCD p in data)
    //    Assert.AreEqual("Smith", p.LastName);
    //}
    //[TestMethod]
    //public void FilterPersonsByMinAge_FindTwoPersonsInAge25OrMore()
    //{
    //  CreateCatalogCD(3, "Person", startAge: 20, ageStep: 5); // ages: 20, 25, 30
    //  CreateCatalogCD(2, "Smith", startAge: 11, ageStep: 2); // ages: 11, 13
    //  IEnumerable<CatalogCD> filtered = m_Service.FilterPersonsByMinAge(25);
    //  PrintPersons(filtered);
    //  Assert.AreEqual(2, filtered.Count());
    //  foreach (CatalogCD p in filtered)
    //    Assert.IsTrue(p.Age >= 25);
    //}
    //[TestMethod]
    //public void ChangeAgeThenFilterPersonsByMinAge_FindFourPersonsInAge25OrMore()
    //{
    //  CreateCatalogCD(3, "Person", startAge: 20, ageStep: 5); // ages: 20, 25, 30 - will become 20+13, 25+13, 30+13
    //  CreateCatalogCD(2, "Smith", startAge: 11, ageStep: 2); // ages: 11, 13 - will become 11+13 = 24, 13+13 = 26
    //  IEnumerable<CatalogCD> filtered = m_Service.ChangeAgeThenFilterPersonsByMinAge(change: 13, minAge: 25);
    //  PrintPersons(filtered);
    //  Assert.AreEqual(4, filtered.Count());
    //  foreach (CatalogCD p in filtered)
    //    Assert.IsTrue(p.Year >= 25);
    //}
    //[TestMethod]
    //public void ChangeAgeThenFilterPersonsByMinAge_MakeOlderThenYounger_OriginalAgeShouldBeRestored()
    //{
    //  CreateCatalogCD(3, "Young", startAge: 20, ageStep: 5);
    //  IEnumerable<CatalogCD> persons = m_Service.GetAllPersons();
    //  int[] originalAge = new int[persons.Count()];
    //  for (int i = 0; i < persons.Count(); i++)
    //    originalAge[i] = persons.ElementAt(i).Year;
    //  IEnumerable<CatalogCD> oldPersons = m_Service.ChangeAgeThenFilterPersonsByMinAge(change: 100, minAge: 120);
    //  Assert.AreEqual(persons.Count(), oldPersons.Count());
    //  foreach (CatalogCD p in oldPersons)
    //    Assert.IsTrue(p.Year >= 120);
    //  IEnumerable<CatalogCD> youngPersons = m_Service.ChangeAgeThenFilterPersonsByMinAge(change: -100, minAge: 20).ToArray();
    //  Assert.AreEqual(persons.Count(), youngPersons.Count());
    //  foreach (CatalogCD p in youngPersons)
    //    Assert.IsTrue(p.Year >= 20 && p.Year < 100);
    //  int[] finalAge = new int[youngPersons.Count()];
    //  for (int i = 0; i < youngPersons.Count(); i++)
    //    finalAge[i] = youngPersons.ElementAt(i).Year;
    //  CollectionAssert.AreEqual(originalAge, finalAge);
    //  PrintPersons(youngPersons);
    //}
    //TODO review; it is from LinqToSqlApp
    //private static void Main(string[] args)
    //{
    //// Connection string defined in LinqToSqlApp project settings.
    //string connectionString = global::LinqToSqlApp.Properties.Settings.Default.PersonDataConnectionString;
    //using (PersonService service = new PersonService(connectionString))
    //{
    //  IEnumerable<Person> all = service.GetAllPersons();
    //  Display("Everyone", all);
    //  Console.WriteLine();
    //  const string lastName = "Kowalski";
    //  const int minAge = 25;
    //  const int change = 11;
    //  Display("With last name '" + lastName + "'", service.FilterPersonsByLastName(lastName));
    //  Console.WriteLine();
    //  Display("After finishing studies", service.FilterPersonsByMinAge(minAge));
    //  Display("Forward " + change + " years", service.ChangeAgeThenFilterPersonsByMinAge(change, minAge));
    //  Display("And back " + change + " years", service.ChangeAgeThenFilterPersonsByMinAge(-change, minAge));
    //}
    //Console.ReadLine();
    //}
    //private static void Display(string title, IEnumerable<Person> data)
    //{
    //  Console.WriteLine("*** {0} ***", title);
    //  foreach (Person p in data)
    //    Console.WriteLine("Person: {0} {1}, age {2}", p.FirstName, p.LastName, p.Age);
    //}

    #region instrumentation
    // Connection string defined in LinqToSqlLibTests project settings.
    private readonly string m_ConnectionString = Properties.Settings.Default.UnitTestDataConnectionString;
    private DataService m_Service;
    private static int m_catalogCDIndex = 0;
    private IEnumerable<CatalogCD> CreateCatalogCD(int count)
    {
      List<CatalogCD> _list = new List<CatalogCD>();
      for (int i = 0; i < count; i++)
        _list.Add(CreateCatalogCD());
      return _list;
    }
    private CatalogCD CreateCatalogCD()
    {
      m_catalogCDIndex += 1;
      return new CatalogCD()
      {
        Artist = $"artist{m_catalogCDIndex}",
        Country = $"country{m_catalogCDIndex}",
        Id = m_catalogCDIndex,
        Price = 100 + m_catalogCDIndex,
        Title = $"title{m_catalogCDIndex}",
        Year = (short)(2000 + m_catalogCDIndex)
      };
    }
    private void PrintPersons(IEnumerable<CatalogCD> data)
    {
#if PRINT_PERSONS
      foreach (CatalogCD p in data)
        Debug.WriteLine($"Person(PersonId={p.Id}) : {p.Title} {p.Artist}, year {p.Year}");
#endif
    }
    #endregion

  }
}