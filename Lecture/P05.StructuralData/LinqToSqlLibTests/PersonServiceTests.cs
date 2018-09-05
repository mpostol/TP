#define PRINT_PERSONS  //uncomment to print persons to the console in tests that call PrintPersons()

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqToSqlLib.Tests
{
  [TestClass]
  public class PersonServiceTests
  {
    // Connection string defined in LinqToSqlLibTests project settings.
    readonly string connectionString = global::LinqToSqlLibTests.Properties.Settings.Default.UnitTestDataConnectionString;

    PersonService service;

    [TestInitialize]
    public void Init()
    {
      service = new PersonService(connectionString);
    }

    [TestCleanup]
    public void CleanUp()
    {
      // Vital for ensuring that table is empty after each test
      service.TruncateAllPersons();
      // Release database context
      service.Dispose();
    }

    private void CreatePersons(int number, string lastName, int startAge, int ageStep = 5)
    {
      for (int i = 0; i < number; i++)
      {
        int N = i + 1;
        int age = startAge + i * ageStep;
        service.AddPerson(new Person() { FirstName = "Test " + N, LastName = lastName, Age = age });
      }
    }

    private void PrintPersons(IEnumerable<Person> data)
    {
#if PRINT_PERSONS
      foreach (Person p in data)
      {
        Console.WriteLine("Person(PersonId={0}) : {1} {2}, age {3}", p.PersonId, p.FirstName, p.LastName, p.Age);
      }
#endif
    }

    [TestMethod]
    public void PersonService_AfterCreation_DataShouldBeEmpty()
    {
      IEnumerable<Person> initialData = service.GetAllPersons();
      Assert.AreEqual(0, initialData.Count());
    }

    [TestMethod]
    public void AddPerson_AddedEntity_ShouldBeTheOnlyOneAndCorrectEntity()
    {
      CreatePersons(1, "Person", 33);
      IEnumerable<Person> data = service.GetAllPersons();
      PrintPersons(data);
      Assert.AreEqual(1, data.Count());
      Assert.IsNotNull(data.First().PersonId);
      Assert.AreNotEqual(0, data.First().PersonId);
    }

    [TestMethod]
    public void GetAllPersons_ExpectCorrectEntities_WithIncreasingPersonId()
    {
      CreatePersons(3, "Person", startAge: 20);
      CreatePersons(2, "Smith", startAge: 11);
      IEnumerable<Person> data = service.GetAllPersons();
      PrintPersons(data);
      Assert.AreEqual(3 + 2, data.Count());
      foreach (Person p in data)
        Assert.IsNotNull(p.PersonId);
      for (int i = 1; i < data.Count(); i++)
        Assert.IsTrue(data.ElementAt(i - 1).PersonId < data.ElementAt(i).PersonId);
    }

    [TestMethod]
    public void FilterPersonsByLastName_FilterTwoSmith_OutOfFivePersons()
    {
      CreatePersons(3, "Person", startAge: 20);
      CreatePersons(2, "Smith", startAge: 11);
      IEnumerable<Person> data = service.FilterPersonsByLastName("Smith");
      PrintPersons(data);

      Assert.AreEqual(2, data.Count());
      foreach (Person p in data)
        Assert.AreEqual("Smith", p.LastName);
    }

    [TestMethod]
    public void FilterPersonsByMinAge_FindTwoPersonsInAge25OrMore()
    {
      CreatePersons(3, "Person", startAge: 20, ageStep: 5); // ages: 20, 25, 30
      CreatePersons(2, "Smith", startAge: 11, ageStep: 2); // ages: 11, 13
      IEnumerable<Person> filtered = service.FilterPersonsByMinAge(25);
      PrintPersons(filtered);

      Assert.AreEqual(2, filtered.Count());
      foreach (Person p in filtered)
        Assert.IsTrue(p.Age >= 25);
    }

    [TestMethod]
    public void ChangeAgeThenFilterPersonsByMinAge_FindFourPersonsInAge25OrMore()
    {
      CreatePersons(3, "Person", startAge: 20, ageStep: 5); // ages: 20, 25, 30 - will become 20+13, 25+13, 30+13
      CreatePersons(2, "Smith", startAge: 11, ageStep: 2); // ages: 11, 13 - will become 11+13 = 24, 13+13 = 26
      IEnumerable<Person> filtered = service.ChangeAgeThenFilterPersonsByMinAge(change: 13, minAge: 25);
      PrintPersons(filtered);

      Assert.AreEqual(4, filtered.Count());
      foreach (Person p in filtered)
        Assert.IsTrue(p.Age >= 25);
    }

    [TestMethod]
    public void ChangeAgeThenFilterPersonsByMinAge_MakeOlderThenYounger_OriginalAgeShouldBeRestored()
    {
      CreatePersons(3, "Young", startAge: 20, ageStep: 5);
      IEnumerable<Person> persons = service.GetAllPersons();
      int[] originalAge = new int[persons.Count()];
      for (int i = 0; i < persons.Count(); i++)
      {
        originalAge[i] = persons.ElementAt(i).Age;
      }

      IEnumerable<Person> oldPersons = service.ChangeAgeThenFilterPersonsByMinAge(change: 100, minAge: 120);
      Assert.AreEqual(persons.Count(), oldPersons.Count());
      foreach (Person p in oldPersons)
        Assert.IsTrue(p.Age >= 120);

      IEnumerable<Person> youngPersons = service.ChangeAgeThenFilterPersonsByMinAge(change: -100, minAge: 20).ToArray();
      Assert.AreEqual(persons.Count(), youngPersons.Count());
      foreach (Person p in youngPersons)
        Assert.IsTrue(p.Age >= 20 && p.Age < 100);

      int[] finalAge = new int[youngPersons.Count()];
      for (int i = 0; i < youngPersons.Count(); i++)
      {
        finalAge[i] = youngPersons.ElementAt(i).Age;
      }
      CollectionAssert.AreEqual(originalAge, finalAge);

      PrintPersons(youngPersons);
    }

    // Ignore, or comment out [TestMethod] below
    //[TestMethod]
    public void Dispose_DoNotReallyTest_AssumeThatDisposeJustWorks()
    {
      Assert.Inconclusive();
    }
  }
}