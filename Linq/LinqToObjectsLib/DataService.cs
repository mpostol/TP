using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObjectsLib
{
    public class DataService
    {
        private List<Person> persons;

        /// <summary>
        /// Constructor of DataService class, creates private underlying collection.
        /// </summary>
        public DataService()
        {
            persons = new List<Person>();
        }

        /// <summary>
        /// Adds given person object to underlying collection.
        /// </summary>
        /// <param name="p">Person object to add to collection.</param>
        public void AddPerson(Person p)
        {
            persons.Add(p);
        }

        /// <summary>
        /// Retrieves a copy of all objects references from underlying collection,
        /// as array of Persons, so original collection stays unmodified.
        /// </summary>
        /// <returns>Array of all Person objects from collection.</returns>
        public Person[] GetAllPersons()
        {
            return persons.ToArray();
        }

        /// <summary>
        /// First version of filtering Person objects by last name, that uses traditional
        /// iteration over collection and .Equals() call for strings.
        /// </summary>
        /// <param name="lastName">Value of Person's last name - used for direct comparison in .Equals() calls.</param>
        /// <returns>Array of Person objects that match given last name.</returns>
        public Person[] FilterPersonsByLastName_ForEach(string lastName)
        {
            List<Person> result = new List<Person>();
            foreach (Person p in persons)
            {
                if (p.LastName.Equals(lastName))
                    result.Add(p);
            }
            return result.ToArray();
        }

        /// <summary>
        /// Second version of filtering Person objects by last name, that uses collection's
        /// extension method .Where() and lambda predicate to match each object.
        /// </summary>
        /// <param name="lastName">Value of Person's last name - used for direct comparison in .Equals() calls.</param>
        /// <returns>Array of Person objects that match given last name.</returns>
        public Person[] FilterPersonsByLastName_ExtensionMethod(string lastName)
        {
            IEnumerable<Person> expr = persons.Where(
                /*Predicate*/
                (Person p) => { return p.LastName.Equals(lastName); }
            );
            return expr.ToArray();
        }

        /// <summary>
        /// Third and final version of filtering Person objects by last name, that uses
        /// LINQ to Objects expression.
        /// </summary>
        /// <param name="lastName">Value of Person's last name - used for direct comparison in .Equals() calls.</param>
        /// <returns>Array of Person objects that match given last name.</returns>
        public Person[] FilterPersonsByLastName(string lastName)
        {
            //System.Linq.Enumerable.WhereListIterator
            IEnumerable<Person> linq =
                from Person p in persons
                where p.LastName.Equals(lastName)
                select p;
            return linq.ToArray();
        }

        /// <summary>
        /// Filters Person objects by minimum age.
        /// </summary>
        /// <param name="minAge">Minimum age of a Person to match.</param>
        /// <returns>IEnumerable of Person objects that match or exceed given minimum age.</returns>
        public IEnumerable<Person> FilterPersonsByMinAge(int minAge)
        {
            IEnumerable<Person> linq =
                from Person p in persons
                where p.Age >= minAge
                select p;
            return linq.ToArray();
        }
    }
}
