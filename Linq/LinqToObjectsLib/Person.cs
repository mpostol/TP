using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObjectsLib
{
    /// <summary>
    /// POCO (Plain Old CLR Object) class to represent person data.
    /// </summary>
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public uint Age { get; set; }

        /// <summary>
        /// Parameterless constructor, initializes all properties with default values.
        /// </summary>
        public Person()
        {
        }

        /// <summary>
        /// Convenience constructor, initializes properties with given values.
        /// </summary>
        /// <param name="firstName">First name of new Person.</param>
        /// <param name="lastName">Last name of new Person.</param>
        /// <param name="age">Age of new Person.</param>
        public Person(string firstName, string lastName, uint age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }
    }
}
