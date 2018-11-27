//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

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
    #endregion

    private readonly IEnumerable<object> m_ObjectsContainer;

  }
}
