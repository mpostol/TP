//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System;
using System.Collections.Generic;
using System.Linq;

namespace TP.StructuralData.LINQ_to_SQL
{
  public class DataService : IDisposable
  {
    /// <summary>
    /// Constructor of PersonService class, creates and configures internal LINQ to SQL database context.
    /// </summary>
    /// <param name="connectionString">Custom connection string that specifies database to connect to.</param>
    public DataService(string connectionString)
    {
      //Possible, but that would limit this library to access project's own "Database.mdf" only
      //context = new PersonsDataContext();
      //Better to configure PersonsDataContext with custom connection string (it might even be the one pointing to project's own "Database.mdf")
      m_Context = new CatalogDataContext(connectionString);
    }
    /// <summary>
    /// Adds given Person entity to database context, and ultimately to database table.
    /// </summary>
    /// <param name="item">Person entity to add to database.</param>
    public void AddCD(CDCatalog item)
    {
      m_Context.CDCatalogs.InsertOnSubmit(item);
      m_Context.SubmitChanges();
    }
    public void AddCD(IEnumerable<CDCatalog> collection)
    {
      foreach (CDCatalog _item in collection)
        m_Context.CDCatalogs.InsertOnSubmit(_item);
      m_Context.SubmitChanges();
    }
    /// <summary>
    /// Retrieves all Person entities as list of Persons, using database context.
    /// </summary>
    /// <returns>List of all Person entities read from database context.</returns>
    public List<CDCatalog> GetAllPersons()
    {
      return m_Context.CDCatalogs.ToList();
    }
    /// <summary>
    /// Retrieves <see cref="Person"/> entities filtered by last name, using LINQ and database context.
    /// </summary>
    /// <param name="lastName">Value of Person's last name - used for direct comparison in .Equals() calls.</param>
    /// <returns>Queryable source of Person entities that match given last name.</returns>
    public IQueryable<CDCatalog> FilterPersonsByLastName(string lastName)
    {
      IQueryable<CDCatalog> expression = from CDCatalog p in m_Context.CDCatalogs
                                         where p.ArtistKey.Equals(lastName)
                                         select p;
      return expression;
    }
    /// <summary>
    /// Prepares LINQ expression to filter <see cref="CatalogCD"/> entities by minimum year.
    /// This *DOES NOT* execute anything on the data source, it is only like a recipe for operations.
    /// Operations will be executed using a translation of the expression to SQL query only when expression is evaluated,
    /// for example when .Enumerator(), .ToArray() or .ToList() is called upon the expression.
    /// </summary>
    /// <param name="minYear">Minimum year of a <see cref="CatalogCD"/> to match.</param>
    /// <returns>LINQ expression as queryable source of <see cref="CatalogCD"/> objects.</returns>
    public IEnumerable<CDCatalog> PreparePersonsByMinAgeLinq(int minYear)
    {
      return from CDCatalog _item in m_Context.CDCatalogs
             where _item.Year >= minYear
             select _item;
    }
    /// <summary>
    /// Modifies age for all <see cref="CatalogCD"/> entities in database, and then retrieves <see cref="CatalogCD"/> entities
    /// filtered by minimum age, using LINQ and database context.
    /// </summary>
    /// <param name="change">Number of years (positive or negative) to add to age of each Person.</param>
    /// <param name="minYea">Minimum age of a Person to match.</param>
    /// <returns>Enumerable source of Person entities that match or exceed given minimum age.</returns>
    public IEnumerable<CDCatalog> ChangeAgeThenFilterPersonsByMinAge(short change, int minYea)
    {
      IEnumerable<CDCatalog> linq = PreparePersonsByMinAgeLinq(minYea);
      // Modify the data *BEFORE* evaluating LINQ expression.
      foreach (CDCatalog p in m_Context.CDCatalogs)
        p.Year = (short)(p.Year + change);
      m_Context.SubmitChanges();
      return linq.ToList();
    }
    /// <summary>
    /// Helper method to quickly remove all entities from the table.
    /// This method is intended to be used in unit tests, but it is useful on its own too.
    /// </summary>
    public void TruncateAllPersons()
    {
      // http://stackoverflow.com/questions/1516962/linq-to-sql-how-to-quickly-clear-a-table
      m_Context.ExecuteCommand("TRUNCATE TABLE CDCatalog");
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
          m_Context.Dispose();
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

    #region private
    private CatalogDataContext m_Context;
    #endregion

  }
}
