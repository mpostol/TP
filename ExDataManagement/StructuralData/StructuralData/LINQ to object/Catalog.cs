﻿//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2023, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//  by introducing yourself and telling us what you do with this community.
//_____________________________________________________________________________________________________________________________________

using System.Collections.Generic;
using System.Linq;
using TP.ExDM.StructuralData.Data;

namespace TP.ExDM.StructuralData.LINQ_to_object
{
  /// <summary>
  /// Class Catalog.
  /// Implements the <see cref="System.Data.DataSet" />
  /// </summary>
  public partial class Catalog
  {
    //TODO ExDM Add DI to the Catalog #385
    public void AddContent(IEnumerable<IPerson> persons)
    {
      foreach (IPerson _item in persons)
      {
        PersonRow _newPersonROw = Person.AddPersonRow(_item.FirstName, _item.LastName, _item.Age);
        foreach (ICDCatalog _cdEntity in _item.CDs)
          this.CDCatalogEntity.AddCDCatalogEntityRow(_cdEntity.Title, _newPersonROw, _cdEntity.Country, _cdEntity.Price, _cdEntity.Year);
      }
    }
    /// <summary>
    /// Class PersonDataTable.
    /// Implements the <see cref="System.Data.TypedTableBase{TP.ExDM.StructuralData.LINQ_to_object.Catalog.PersonRow}" />
    /// </summary>
    /// <seealso cref="System.Data.TypedTableBase{TP.ExDM.StructuralData.LINQ_to_object.Catalog.PersonRow}" />
    public partial class PersonDataTable
    {
      /// <summary>
      /// It uses foreach instruction for the filtering purpose.
      /// </summary>
      /// <param name="lastName">Person's last name.</param>
      public IEnumerable<PersonRow> FilterPersonsByLastName_ForEach(string lastName)
      {
        List<PersonRow> _result = new List<PersonRow>();
        foreach (PersonRow _row in this)
          if (_row.LastName.Equals(lastName))
            _result.Add(_row);
        return _result;
      }
      /// <summary>
      /// It uses LINQ to Objects expression.
      /// </summary>
      /// <param name="lastName">Person's last name.</param>
      public IEnumerable<PersonRow> FilterPersonsByLastName_QuerySyntax(string lastName)
      {
        return from _person in this
               where _person.LastName.Equals(lastName)
               select _person;
      }
      /// <summary>
      /// It uses the <see cref="Enumerable.Where"/> extension method and lambda predicate to match each object.
      /// </summary>
      /// <param name="lastName">Person's last name.</param>
      public IEnumerable<PersonRow> FilterPersonsByLastName_MethodSyntax(string lastName)
      {
        return this.Where(_person => _person.LastName.Equals(lastName));
      }
    }
  }
}
