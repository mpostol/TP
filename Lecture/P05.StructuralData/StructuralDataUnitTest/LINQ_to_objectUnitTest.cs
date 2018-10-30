//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TP.StructuralData.LINQ_to_object;

namespace TP.StructuralDataUnitTest
{
  [TestClass]
  public class LINQ_to_objectUnitTest
  {
    [TestMethod]
    public void CatalogConstructorTest()
    {
      using (Catalog _newCatalog = new Catalog())
      {
        Assert.AreEqual<int>(0, _newCatalog.Person.Count);
        Assert.AreEqual<int>(0, _newCatalog.CDCatalogEntity.Count);
        Assert.AreEqual<int>(1, _newCatalog.Relations.Count);
        DataRelation _relation = _newCatalog.Relations["Person_CDCatalog"];
        Assert.IsNotNull(_relation);
        Assert.AreEqual<string>(_newCatalog.Person.TableName, _relation.ParentTable.TableName);
        Assert.AreEqual<string>(_newCatalog.CDCatalogEntity.TableName, _relation.ChildTable.TableName);
      }
    }
    [TestMethod]
    public void CatalogConstructorInitialDataTest()
    {
      using (Catalog _newCatalog = new Catalog(PrepareData()))
      {
        Assert.AreEqual<int>(3, _newCatalog.Person.Count);
        Assert.AreEqual<int>(0, _newCatalog.CDCatalogEntity.Count);
        Assert.AreEqual<int>(1, _newCatalog.Relations.Count);
        DataRelation _relation = _newCatalog.Relations["Person_CDCatalog"];
        Assert.IsNotNull(_relation);
        Assert.AreEqual<string>(_newCatalog.Person.TableName, _relation.ParentTable.TableName);
        Assert.AreEqual<string>(_newCatalog.CDCatalogEntity.TableName, _relation.ChildTable.TableName);
      }
    }
    [TestMethod]
    public void FilterPersonsByLastName_ForEachTest()
    {
      using (Catalog _newCatalog = new Catalog(PrepareData()))
      {
        IEnumerable<Catalog.PersonRow> _filtered = _newCatalog.Person.FilterPersonsByLastName_ForEach("Person");
        foreach (Catalog.PersonRow p in _filtered)
          Assert.AreEqual("Person", p.LastName);
        Assert.AreEqual(2, _filtered.Count());
      }
    }
    [TestMethod]
    public void FilterPersonsByLastName_MethodSyntaxTest()
    {
      using (Catalog _newCatalog = new Catalog(PrepareData()))
      {
        IEnumerable<Catalog.PersonRow> _filtered = _newCatalog.Person.FilterPersonsByLastName_MethodSyntax("Person");
        foreach (Catalog.PersonRow p in _filtered)
          Assert.AreEqual("Person", p.LastName);
        Assert.AreEqual(2, _filtered.Count());
      }
    }
    [TestMethod]
    public void FilterPersonsByLastName_QuerySyntaxTest()
    {
      using (Catalog _newCatalog = new Catalog(PrepareData()))
      {
        IEnumerable<Catalog.PersonRow> _filtered = _newCatalog.Person.FilterPersonsByLastName_QuerySyntax("Person");
        foreach (Catalog.PersonRow p in _filtered)
          Assert.AreEqual("Person", p.LastName);
        Assert.AreEqual(2, _filtered.Count());
      }
    }

    #region test instrumentation
    private IEnumerable<Person> PrepareData()
    {
      return new List<Person>()
      {
        new Person("First", "Person", 20),
        new Person("Second", "Person", 30),
        new Person("Mister", "Clever", 42)
      };
    }
    #endregion
  }
}
