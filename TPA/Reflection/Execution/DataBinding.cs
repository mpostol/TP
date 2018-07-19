using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TPA.Reflection.Execution
{
  internal class DataBinding
  {
        private readonly PropertyInfo m_source;

        private readonly object m_consumer;
        private readonly PropertyInfo m_consumerProperty;

        public DataBinding(INotifyPropertyChanged dataSource, string sourcePropertyName, object consumer, string consumerPropertyName)
        {
            PropertyInfo sourceProperty = dataSource.GetType().GetProperty(sourcePropertyName) ?? throw new ArgumentException("No such Property in Data Source");
            PropertyInfo consumerProperty = consumer.GetType().GetProperty(consumerPropertyName) ?? throw new ArgumentException("No such Property in Data Consumer");

            if (!consumerProperty.PropertyType.IsAssignableFrom(sourceProperty.PropertyType))
            {
                throw new ArgumentException("Properties types don't match");
            }

            m_source = sourceProperty;

            m_consumer = consumer;
            m_consumerProperty = consumerProperty;

            dataSource.PropertyChanged += OnPropertyChangedAction;
        }

        private void OnPropertyChangedAction(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == m_source.Name)
            {
                m_consumerProperty.SetValue(m_consumer, m_source.GetValue(sender));
            }
        }
  }
}
