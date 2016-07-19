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
            Person[] initialData = service.GetAllPersons();
            Assert.That(initialData.Length, Is.EqualTo(0));
        }

        [Test]
        public void AddPerson_AddedPerson_IsTheFirstAndOnlyOneInCollection()
        {
            Person person = new Person();
            service.AddPerson(person);
            Person[] data = service.GetAllPersons();
            Assert.That(data.Length, Is.EqualTo(1));
            Assert.That(person, Is.SameAs(data[0]));
        }

        [Test, TestCaseSource("GetAllPersonsTest_InputCases")]
        public void GetAllPersons_AfterAddingPersonsFromArray_LengthShouldBeEqual(Person[] input)
        {
            Assume.That(input.Length, Is.GreaterThan(1));
            foreach (Person p in input)
            {
                service.AddPerson(p);
            }
            Person[] dataAfterAdding = service.GetAllPersons();
            Assert.That(dataAfterAdding, Has.Length.EqualTo(input.Length));
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
            Person[] filtered = service.FilterPersonsByLastName_ForEach("Person");
            Assert.That(filtered, Has.All.Property("LastName").EqualTo("Person"));
            Assert.That(filtered.Length, Is.EqualTo(2));
        }

        [Test]
        public void FilterPersonsByLastName_UseExtensionMethod_FindTwoPersons()
        {
            PrepareData();
            Person[] filtered = service.FilterPersonsByLastName_ExtensionMethod("Person");
            Assert.That(filtered, Has.All.Property("LastName").EqualTo("Person"));
            Assert.That(filtered.Length, Is.EqualTo(2));
        }

        [Test]
        public void FilterPersonsByLastName_UseLinq_FindTwoPersons()
        {
            PrepareData();
            Person[] filtered = service.FilterPersonsByLastName("Person");
            Assert.That(filtered, Has.All.Property("LastName").EqualTo("Person"));
            Assert.That(filtered.Length, Is.EqualTo(2));
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