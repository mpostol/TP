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
using System.ComponentModel;
using System.Reflection;

namespace TPA.Reflection.Execution
{
  internal class DataBinding
  {
    public DataBinding(INotifyPropertyChanged dataSource, string sourcePropertyName, object consumer, string consumerPropertyName)
    {
      if (dataSource == null)
        throw new ArgumentNullException($"{nameof(dataSource)}", $"{nameof(dataSource)} must not be null");
      if (consumer == null)
        throw new ArgumentNullException($"{nameof(consumer)}", $"{nameof(consumer)} must not be null");
      PropertyInfo _sourceProperty = dataSource.GetType().GetProperty(sourcePropertyName) ?? throw new ArgumentException("No such Property in Data Source");
      PropertyInfo _consumerProperty = consumer.GetType().GetProperty(consumerPropertyName) ?? throw new ArgumentException("No such Property in Data Consumer");
      if (!_consumerProperty.PropertyType.IsAssignableFrom(_sourceProperty.PropertyType))
        throw new ArgumentException("Properties types don't match");
      m_source = _sourceProperty;
      m_consumer = consumer;
      m_consumerProperty = _consumerProperty;
      dataSource.PropertyChanged += OnPropertyChangedAction;
      UpdateProperty(dataSource);
    }

    #region private

    private readonly PropertyInfo m_source;
    private readonly object m_consumer;
    private readonly PropertyInfo m_consumerProperty;

    private void OnPropertyChangedAction(object sender, PropertyChangedEventArgs args)
    {
      if (args.PropertyName == m_source.Name)
        UpdateProperty(sender);
    }

    private void UpdateProperty(object dataSource)
    {
      m_consumerProperty.SetValue(m_consumer, m_source.GetValue(dataSource));
    }

    #endregion private
  }
}