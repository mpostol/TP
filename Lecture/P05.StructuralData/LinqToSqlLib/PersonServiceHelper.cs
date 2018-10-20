//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

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
      m_Context.ExecuteCommand("TRUNCATE TABLE Persons");
    }
  }
}
