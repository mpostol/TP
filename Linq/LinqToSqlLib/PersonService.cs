using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSqlLib
{
    public partial class PersonService : IDisposable
    {
        private PersonsDataContext context;

        /// <summary>
        /// Constructor of PersonService class, creates and configures internal LINQ to SQL database context.
        /// </summary>
        /// <param name="connectionString">Custom connection string that specifies database to connect to.</param>
        public PersonService(string connectionString)
        {
            /* Possible, but that would limit this library to access project's own "Database.mdf" only
             */
            //context = new PersonsDataContext();

            /* Better to configure PersonsDataContext with custom connection string
             * (it might even be the one pointing to project's own "Database.mdf")
             */
            context = new PersonsDataContext(connectionString);
        }

        /// <summary>
        /// Adds given Person entity to database context, and ultimately to database table.
        /// </summary>
        /// <param name="p">Person entity to add to database.</param>
        public void AddPerson(Person p)
        {
            context.Persons.InsertOnSubmit(p);
            context.SubmitChanges();
        }

        /// <summary>
        /// Retrieves all Person entities as list of Persons, using database context.
        /// </summary>
        /// <returns>List of all Person entities read from database context.</returns>
        public List<Person> GetAllPersons()
        {
            return context.Persons.ToList();
        }

        /// <summary>
        /// Retrieves Person entities filtered by last name, using LINQ and database context.
        /// </summary>
        /// <param name="lastName">Value of Person's last name - used for direct comparison in .Equals() calls.</param>
        /// <returns>Queryable source of Person entities that match given last name.</returns>
        public IQueryable<Person> FilterPersonsByLastName(string lastName)
        {
            IQueryable<Person> expression =
                from Person p in context.Persons
                where p.LastName.Equals(lastName)
                select p;
            return expression;
        }

        /// <summary>
        /// Prepares LINQ expression to filter Person entities by minimum age.
        /// This *DOES NOT* execute anythig on the data source, it is only like a recipe for operations.
        /// Operations will be performed using database context only when expression is evaluated,
        /// for example when .Enumerator(), .ToArray() or .ToList() is called upon the expression.
        /// </summary>
        /// <param name="minAge">Minimum age of a Person to match.</param>
        /// <returns>LINQ expression as queryable source of Person objects.</returns>
        internal IQueryable<Person> PreparePersonsByMinAgeLinq(int minAge)
        {
            return
                from Person p in context.Persons
                where p.Age >= minAge
                select p;
        }

        /// <summary>
        /// Retrieves Person entities filtered by minimum age, using LINQ and database context.
        /// </summary>
        /// <param name="minAge">Minimum age of a Person to match.</param>
        /// <returns>Enumerable source of Person entities that match or exceed given minimum age.</returns>
        public IEnumerable<Person> FilterPersonsByMinAge(int minAge)
        {
            IQueryable<Person> linq = PreparePersonsByMinAgeLinq(minAge);
            return linq;
        }

        /// <summary>
        /// Modifies age for all Person entities in database, and then retrieves Person entities
        /// filtered by minimum age, using LINQ and database context.
        /// </summary>
        /// <param name="change">Number of years (positive or negative) to add to age of each Person.</param>
        /// <param name="minAge">Minimum age of a Person to match.</param>
        /// <returns>Enumerable source of Person entities that match or exceed given minimum age.</returns>
        public IEnumerable<Person> ChangeAgeThenFilterPersonsByMinAge(int change, int minAge)
        {
            IQueryable<Person> linq = PreparePersonsByMinAgeLinq(minAge);

            // Modify the data *BEFORE* evaluating LINQ expression.
            foreach (Person p in context.Persons)
            {
                p.Age = p.Age + change;
            }
            context.SubmitChanges();

            return linq.ToList();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // Dispose managed state (managed objects).
                    context.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~PersonService() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
