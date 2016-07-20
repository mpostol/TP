using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSqlLib
{
    public partial class PersonService
    {
        /// <summary>
        /// Helper method to quickly remove all Person entities from the table.
        /// This method is intended to be used in unit tests, but it is useful on its own too.
        /// </summary>
        public void TruncateAllPersons()
        {
            // http://stackoverflow.com/questions/1516962/linq-to-sql-how-to-quickly-clear-a-table
            context.ExecuteCommand("TRUNCATE TABLE Persons");
        }
    }
}
