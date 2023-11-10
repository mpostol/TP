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

using System;
using System.Reflection;

namespace TP.DataStreams.Reflection
{
  public class AttachedProperty<TypeParameter>
  {
    //API
    public AttachedProperty(object dataSource, string sourcePropertyName)
    {
      m_dataSource = dataSource ?? throw new ArgumentNullException(nameof(dataSource), "dataSource cannot be null.");
      Type _objectType = dataSource.GetType();
      m_source = _objectType.GetProperty(sourcePropertyName) ?? throw new ArgumentException("No such Property in Data Source");
      if (!m_source.PropertyType.IsAssignableFrom(typeof(TypeParameter)))
        throw new ArgumentException("Properties types don't match");
    }

    public TypeParameter Value
    {
      get
      {
        return (TypeParameter)m_source.GetValue(m_dataSource);
      }
      set
      {
        m_source.SetValue(m_dataSource, value);
      }
    }

    //private
    private readonly object m_dataSource;

    private readonly PropertyInfo m_source;
  }
}