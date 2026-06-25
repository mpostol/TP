//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2024, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//  by introducing yourself and telling us what you do with this community.
//_____________________________________________________________________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TP.ExDM.StructuralData.LINQ_to_object;
using TP.ExDM.StructuralDataUnitTest.Instrumentation;

namespace TP.ExDM.StructuralDataUnitTest
{
  [TestClass]
  /// <summary>
  /// Unit tests for LINQ to object operations in the Catalog class.
  /// </summary>
  /// <remarks>
  /// These tests cover the filtering methods in the Catalog.PersonDataTable class. It relies on TestDataGenerator.PrepareData() to create consistent test data.
  /// </remarks>
  public class LINQ_to_objectUnitTest
  {
    [TestMethod]
    public void CatalogConstructorTest()
    {
      using (Catalog _newCatalog = new Catalog(TestDataGenerator.PrepareData()))
      {
        DataRelation _relation = _newCatalog.Relations["ArtistRelation"];
        Assert.IsNotNull(_relation);
        Assert.AreEqual<string>(_newCatalog.Person.TableName, _relation.ParentTable.TableName);
        Assert.AreEqual<string>(_newCatalog.CDCatalogEntity.TableName, _relation.ChildTable.TableName);
        Assert.AreEqual<int>(3, _newCatalog.Person.Count);
        Assert.AreEqual<int>(15, _newCatalog.CDCatalogEntity.Count);
      }
    }
    [TestMethod]
    /// <summary>
    /// Tests the FilterPersonsByLastName_ForEach method in the Catalog.PersonDataTable class.
    /// </summary>
    /// <remarks>
    /// This test verifies that the method correctly filters persons by their last name using a foreach loop.
    /// </remarks>
    public void FilterPersonsByLastName_ForEachTest()
    {
      using (Catalog _newCatalog = new Catalog(TestDataGenerator.PrepareData()))
      {
        IEnumerable<Catalog.PersonRow> _filtered = _newCatalog.Person.FilterPersonsByLastName_ForEach("Person");
        Type _returnedType = _filtered.GetType();
        Assert.AreEqual<string>("System.Collections.Generic.List`1", $"{_returnedType.Namespace}.{_returnedType.Name}");
        Assert.AreEqual<string>("System.Collections.Generic.List`1[TP.ExDM.StructuralData.LINQ_to_object.Catalog+PersonRow]", _filtered.ToString(), _filtered.ToString());
        Assert.AreEqual(2, _filtered.Count());
        foreach (Catalog.PersonRow p in _filtered)
          Assert.AreEqual("Person", p.LastName);
      }
    }
    [TestMethod]
    /// <summary>
    /// Tests the FilterPersonsByLastName_QuerySyntax method in the Catalog.PersonDataTable class.
    /// </summary>
    public void FilterPersonsByLastName_QuerySyntaxTest()
    {
      using (Catalog _newCatalog = new Catalog(TestDataGenerator.PrepareData()))
      {
        IEnumerable<Catalog.PersonRow> _filtered = _newCatalog.Person.FilterPersonsByLastName_QuerySyntax("Person");
        Type _returnedType = _filtered.GetType();
        Assert.AreEqual<string>("System.Linq.WhereEnumerableIterator`1", $"{_returnedType.Namespace}.{_returnedType.Name}");
        Assert.AreEqual<string>("System.Linq.Enumerable+WhereEnumerableIterator`1[TP.ExDM.StructuralData.LINQ_to_object.Catalog+PersonRow]", _filtered.ToString(), _filtered.ToString());
        Assert.AreEqual(2, _filtered.Count());
        foreach (Catalog.PersonRow p in _filtered)
          Assert.AreEqual("Person", p.LastName);
      }
    }
    [TestMethod]
    /// <summary>
    /// Tests the FilterPersonsByLastName_MethodSyntax method in the Catalog.PersonDataTable class.   
    /// </summary>
    public void FilterPersonsByLastName_MethodSyntaxTest()
    {
      using (Catalog _newCatalog = new Catalog(TestDataGenerator.PrepareData()))
      {
        IEnumerable<Catalog.PersonRow> _filtered = _newCatalog.Person.FilterPersonsByLastName_MethodSyntax("Person");
        Type _returnedType = _filtered.GetType();
        Assert.AreEqual<string>("System.Linq.WhereEnumerableIterator`1", $"{_returnedType.Namespace}.{_returnedType.Name}");
        Assert.AreEqual<string>("System.Linq.Enumerable+WhereEnumerableIterator`1[TP.ExDM.StructuralData.LINQ_to_object.Catalog+PersonRow]", _filtered.ToString(), _filtered.ToString());
        Assert.AreEqual(2, _filtered.Count());
        foreach (Catalog.PersonRow p in _filtered)
          Assert.AreEqual("Person", p.LastName);
      }
    }
  }
}