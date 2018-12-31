//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.IO;
using System.Linq;
using TP.StructuralData.LINQ_to_SQL;
using TP.StructuralDataUnitTest.Instrumentation;

namespace TP.StructuralDataUnitTest
{
  [TestClass]
  [DeploymentItem(@"Instrumentation\CDCatalog.mdf", @"Instrumentation")]
  public class LINQ_to_SQLDataServiceUnitTests
  {

    [ClassInitialize]
    public static void ClassInitializeMethod(TestContext context)
    {
      string _DBRelativePath = @"Instrumentation\CDCatalog.mdf";
      string _TestingWorkingFolder = Environment.CurrentDirectory;
      string _DBPath = Path.Combine(_TestingWorkingFolder, _DBRelativePath);
      FileInfo _databaseFile = new FileInfo(_DBPath);
      Assert.IsTrue(_databaseFile.Exists, $"{Environment.CurrentDirectory}");
      m_ConnectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={_DBPath};Integrated Security = True; Connect Timeout = 30;";
    }
    [TestMethod]
    public void CatalogConstructorTest()
    {
      using (CatalogDataContext _newCatalog = new CatalogDataContext(m_ConnectionString))
      {
        Assert.IsNotNull(_newCatalog.Connection);
        Assert.AreEqual<int>(0, _newCatalog.Persons.Count());
        Assert.AreEqual<int>(0, _newCatalog.CDCatalogEntities.Count());
        try
        {
          _newCatalog.AddContent(TestDataGenerator.PrepareData());
          Assert.AreEqual<int>(3, _newCatalog.Persons.Count());
          Assert.AreEqual<int>(15, _newCatalog.CDCatalogEntities.Count());
        }
        finally
        {
          _newCatalog.TruncateAllData();
        }
      }
    }
    [TestMethod]
    public void FilterPersonsByLastName_ForEachTest()
    {
      using (CatalogDataContext _newCatalog = new CatalogDataContext(m_ConnectionString))
      {
        try
        {
          _newCatalog.AddContent(TestDataGenerator.PrepareData());
          IEnumerable<Person> _filtered = _newCatalog.FilterPersonsByLastName_ForEach("Person");
          Type _returnedType = _filtered.GetType();
          Assert.AreEqual<string>("System.Collections.Generic.List`1", $"{_returnedType.Namespace}.{_returnedType.Name}");
          Assert.AreEqual<string>("System.Collections.Generic.List`1[TP.StructuralData.LINQ_to_SQL.Person]", _filtered.ToString(), _filtered.ToString());
          Assert.AreEqual(2, _filtered.Count());
          foreach (Person p in _filtered)
            Assert.AreEqual("Person", p.LastName);
        }
        finally
        {
          _newCatalog.TruncateAllData();
        }
      }
    }
    [TestMethod]
    public void FilterPersonsByLastName_QuerySyntaxTest()
    {
      using (CatalogDataContext _newCatalog = new CatalogDataContext(m_ConnectionString))
      {
        try
        {
          _newCatalog.AddContent(TestDataGenerator.PrepareData());
          IEnumerable<Person> _filtered = _newCatalog.FilterPersonsByLastName_QuerySyntax("Person");
          Type _returnedType = _filtered.GetType();
          Assert.AreEqual<string>("System.Data.Linq.DataQuery`1", $"{_returnedType.Namespace}.{_returnedType.Name}");
          Assert.AreEqual<string>("SELECT [t0].[Id], [t0].[FirstName], [t0].[LastName], [t0].[Age]\r\nFROM [dbo].[Person] AS [t0]\r\nWHERE [t0].[LastName] = @p0", _filtered.ToString().Trim());
          Assert.AreEqual(2, _filtered.Count());
          foreach (Person p in _filtered)
            Assert.AreEqual("Person", p.LastName);
        }
        finally
        {
          _newCatalog.TruncateAllData();
        }
      }
    }
    [TestMethod]
    public void FilterPersonsByLastName_MethodSyntaxTest()
    {
      using (CatalogDataContext _newCatalog = new CatalogDataContext(m_ConnectionString))
      {
        try
        {
          _newCatalog.AddContent(TestDataGenerator.PrepareData());
          IEnumerable<Person> _filtered = _newCatalog.FilterPersonsByLastName_MethodSyntax("Person");
          Type _returnedType = _filtered.GetType();
          Assert.AreEqual<string>("System.Data.Linq.DataQuery`1", $"{_returnedType.Namespace}.{_returnedType.Name}");
          Assert.AreEqual<string>("SELECT [t0].[Id], [t0].[FirstName], [t0].[LastName], [t0].[Age]\r\nFROM [dbo].[Person] AS [t0]\r\nWHERE [t0].[LastName] = @p0", _filtered.ToString().Trim());
          Assert.AreEqual(2, _filtered.Count());
          foreach (Person p in _filtered)
            Assert.AreEqual("Person", p.LastName);
        }
        finally
        {
          _newCatalog.TruncateAllData();
        }
      }
    }
    [TestMethod]
    public void FilterPersonsByLastName_AnonymousTypeClass()
    {
      using (CatalogDataContext _newCatalog = new CatalogDataContext(m_ConnectionString))
      {
        try
        {
          _newCatalog.AddContent(TestDataGenerator.PrepareData());
          string _filtered = _newCatalog.FilterPersonsByLastName_AnonymousType("Person");
          Assert.AreEqual("First, Second, Mister", _filtered);
        }
        finally
        {
          _newCatalog.TruncateAllData();
        }
      }
    }
    [TestMethod]
    public void ObjectRelationalMappingTest()
    {
      //CatalogDataContext
      object[] _attributes = typeof(CatalogDataContext).GetCustomAttributes(false);
      Assert.AreEqual<int>(1, _attributes.Length);
      Assert.IsInstanceOfType(_attributes[0], typeof(DatabaseAttribute));
      Assert.AreEqual<string>("CDCatalog", ((DatabaseAttribute)_attributes[0]).Name);
      //CDCatalogEntity
      _attributes = typeof(CDCatalogEntity).GetCustomAttributes(false);
      Assert.AreEqual<int>(1, _attributes.Length);
      Assert.IsInstanceOfType(_attributes[0], typeof(TableAttribute));
      Assert.AreEqual<string>("dbo.CDCatalogEntity", ((TableAttribute)_attributes[0]).Name);
      //Person
      _attributes = typeof(Person).GetCustomAttributes(false);
      Assert.AreEqual<int>(1, _attributes.Length);
      Assert.IsInstanceOfType(_attributes[0], typeof(TableAttribute));
      Assert.AreEqual<string>("dbo.Person", ((TableAttribute)_attributes[0]).Name);
    }

    #region instrumentation
    // Connection string defined in LinqToSqlLibTests project settings.
    private static string m_ConnectionString;
    #endregion
  }
}