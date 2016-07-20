#define PRINT_PERSONS  //uncomment to print persons to the console in tests that call PrintPersons()

using NUnit.Framework;
using LinqToSqlLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSqlLib.Tests
{
    [TestFixture()]
    public class PersonServiceTests
    {
        // Connection string defined in LinqToSqlLibTests project settings.
        string connectionString = global::LinqToSqlLibTests.Properties.Settings.Default.UnitTestDataConnectionString;

        PersonService service;

        [SetUp]
        public void Init()
        {
            service = new PersonService(connectionString);
        }

        [TearDown]
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

        [Test]
        public void PersonService_AfterCreation_DataShouldBeEmpty()
        {
            Person[] initialData = service.GetAllPersons();
            Assert.That(initialData.Length, Is.EqualTo(0));
        }

        [Test]
        public void AddPerson_AddedEntity_ShouldBeTheOnlyOneAndCorrectEntity()
        {
            CreatePersons(1, "Person", 33);
            Person[] data = service.GetAllPersons();
            PrintPersons(data);

            Assert.That(data.Length, Is.EqualTo(1));
            Assert.That(data[0].PersonId, Is.Not.Null);
            Assert.That(data[0].PersonId, Is.Not.EqualTo(0));
        }

        [Test]
        public void GetAllPersons_ExpectCorrectEntities_WithIncreasingPersonId()
        {
            CreatePersons(3, "Person", 20);
            CreatePersons(2, "Smith", 11);
            Person[] data = service.GetAllPersons();
            PrintPersons(data);

            Assert.That(data.Length, Is.EqualTo(3 + 2));
            Assert.That(data, Has.All.Property("PersonId").Not.Null);
            for (int i = 1; i < data.Length; i++)
            {
                Assert.That(data[i - 1].PersonId, Is.LessThan(data[i].PersonId));
            }
        }

        [Test]
        public void FilterPersonsByLastName_FilterTwoSmith_OutOfFivePersons()
        {
            CreatePersons(3, "Person", 20);
            CreatePersons(2, "Smith", 11);
            Person[] data = service.FilterPersonsByLastName("Smith");
            PrintPersons(data);

            Assert.That(data.Length, Is.EqualTo(2));
            Assert.That(data, Has.All.Property("LastName").EqualTo("Smith"));
        }

        [Test]
        public void FilterPersonsByMinAge_FindTwoPersonsInAge25OrMore()
        {
            CreatePersons(3, "Person", 20, 5); // ages: 20, 25, 30
            CreatePersons(2, "Smith", 11, 2); // ages: 11, 13
            IEnumerable<Person> filtered = service.FilterPersonsByMinAge(25);
            PrintPersons(filtered);

            Assert.That(filtered.Count, Is.EqualTo(2));
            Assert.That(filtered, Has.All.Property("Age").GreaterThanOrEqualTo(25));
        }

        [Test]
        public void ChangeAgeThenFilterPersonsByMinAge_FindFourPersonsInAge25OrMore()
        {
            CreatePersons(3, "Person", 20, 5); // ages: 20, 25, 30 - will become 20+13, 25+13, 30+13
            CreatePersons(2, "Smith", 11, 2); // ages: 11, 13 - will become 11+13 = 24, 13+13 = 26
            IEnumerable<Person> filtered = service.ChangeAgeThenFilterPersonsByMinAge(13, 25);
            PrintPersons(filtered);

            Assert.That(filtered.Count, Is.EqualTo(4));
            Assert.That(filtered, Has.All.Property("Age").GreaterThanOrEqualTo(25));
        }

        [Test]
        public void ChangeAgeThenFilterPersonsByMinAge_MakeOlderThenYounger_OriginalAgeShouldBeRestored()
        {
            CreatePersons(3, "Young", 20, 5);
            Person[] persons = service.GetAllPersons();
            int[] originalAge = new int[persons.Length];
            for (int i = 0; i < persons.Length; i++)
            {
                originalAge[i] = persons[i].Age;
            }

            IEnumerable<Person> oldPersons = service.ChangeAgeThenFilterPersonsByMinAge(100, 120);
            Assert.That(oldPersons.Count, Is.EqualTo(persons.Length));
            Assert.That(oldPersons, Has.All.Property("Age").GreaterThanOrEqualTo(120));

            Person[] youngPersons = service.ChangeAgeThenFilterPersonsByMinAge(-100, 20).ToArray();
            Assert.That(youngPersons.Count, Is.EqualTo(persons.Length));
            Assert.That(youngPersons, Has.All.Property("Age").GreaterThanOrEqualTo(20));
            Assert.That(youngPersons, Has.All.Property("Age").LessThan(100));

            int[] finalAge = new int[youngPersons.Length];
            for (int i = 0; i < youngPersons.Length; i++)
            {
                finalAge[i] = youngPersons[i].Age;
            }
            CollectionAssert.AreEqual(originalAge, finalAge);

            PrintPersons(youngPersons);
        }

        //[Ignore("assume that Dispose just works")]
        [Test]
        public void Dispose_DoNotReallyTest_AssumeThatDisposeJustWorks()
        {
            Assert.Pass();
        }
    }
}