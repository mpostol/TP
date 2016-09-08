using NUnit.Framework;
using LinqToObjectsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObjectsLib.Tests
{
    [TestFixture()]
    public class DataServiceTests
    {
        // Class under test.
        private DataService service;

        [SetUp]
        public void Init()
        {
            service = new DataService();
        }

        [Test]
        public void DataService_AfterCreation_CollectionIsEmpty()
        {
            IEnumerable<Person> initialData = service.GetAllPersons();
            Assert.That(initialData.Count(), Is.EqualTo(0));
        }

        [Test]
        public void AddPerson_AddedPerson_IsTheFirstAndOnlyOneInCollection()
        {
            Person person = new Person();
            service.AddPerson(person);
            IEnumerable<Person> data = service.GetAllPersons();
            Assert.That(data.Count(), Is.EqualTo(1));
            Assert.That(person, Is.SameAs(data.First()));
        }

        [Test, TestCaseSource("GetAllPersonsTest_InputCases")]
        public void GetAllPersons_AfterAddingPersonsFromArray_CountShouldBeEqual(Person[] input)
        {
            Assume.That(input.Count(), Is.GreaterThan(1));
            foreach (Person p in input)
            {
                service.AddPerson(p);
            }
            IEnumerable<Person> dataAfterAdding = service.GetAllPersons();
            Assert.That(dataAfterAdding, Has.Count.EqualTo(input.Count()));
        }

        static object[] GetAllPersonsTest_InputCases = new Person[][] {
            new Person[] { },
            new Person[] { new Person("A", "One", 1), new Person("B", "Two", 2) },
            new Person[] { new Person("A", "One", 1), new Person("B", "Two", 2), new Person("C", "Three", 3) },
        };

        private void PrepareData()
        {
            service.AddPerson(new Person("First", "Person", 20));
            service.AddPerson(new Person("Second", "Person", 30));
            service.AddPerson(new Person("Mister", "Clever", 42));
        }

        [Test]
        public void FilterPersonsByLastName_UseForEach_FindTwoPersons()
        {
            PrepareData();
            IEnumerable<Person> filtered = service.FilterPersonsByLastName_ForEach("Person");
            Assert.That(filtered, Has.All.Property("LastName").EqualTo("Person"));
            Assert.That(filtered.Count(), Is.EqualTo(2));
        }

        [Test]
        public void FilterPersonsByLastName_UseExtensionMethod_FindTwoPersons()
        {
            PrepareData();
            IEnumerable<Person> filtered = service.FilterPersonsByLastName_ExtensionMethod("Person");
            Assert.That(filtered, Has.All.Property("LastName").EqualTo("Person"));
            Assert.That(filtered.Count(), Is.EqualTo(2));
        }

        [Test]
        public void FilterPersonsByLastName_UseLinq_FindTwoPersons()
        {
            PrepareData();
            IEnumerable<Person> filtered = service.FilterPersonsByLastName("Person");
            Assert.That(filtered, Has.All.Property("LastName").EqualTo("Person"));
            Assert.That(filtered.Count(), Is.EqualTo(2));
        }

        [TestCase(25, ExpectedResult = 2)]
        [TestCase(40, ExpectedResult = 1)]
        [TestCase(99, ExpectedResult = 0)]
        public int FilterPersonsByMinAge_CheckExpectedCount_GivenMinAge(int minAge)
        {
            PrepareData();
            IEnumerable<Person> filtered = service.FilterPersonsByMinAge(minAge);
            Assert.That(filtered, Has.All.Property("Age").GreaterThanOrEqualTo(minAge));
            return filtered.Count();
        }
    }
}