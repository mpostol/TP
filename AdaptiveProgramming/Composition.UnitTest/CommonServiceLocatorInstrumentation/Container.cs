//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2023, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//  by introducing yourself and telling us what you do with this community.
//_____________________________________________________________________________________________________________________________________

using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TPA.Composition.UnitTest.CommonServiceLocatorInstrumentation
{
  internal class Container : ServiceLocatorImplBase
  {
    public Container(IEnumerable<object> list)
    {
      m_ObjectsContainer = list;
    }

    #region ServiceLocatorImplBase

    protected override object DoGetInstance(Type requestedType, string key)
    {
      return String.IsNullOrEmpty(key) ? m_ObjectsContainer.First(o => requestedType.IsAssignableFrom(o.GetType()))
                                       : m_ObjectsContainer.First(o => requestedType.IsAssignableFrom(o.GetType()) && Equals(key, o.GetType().FullName));
    }

    protected override IEnumerable<object> DoGetAllInstances(Type requestedType)
    {
      return m_ObjectsContainer.Where(o => requestedType.IsAssignableFrom(o.GetType()));
    }

    #endregion ServiceLocatorImplBase

    private readonly IEnumerable<object> m_ObjectsContainer;
  }
}