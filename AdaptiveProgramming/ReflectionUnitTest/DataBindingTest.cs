//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TPA.Reflection.Execution;

namespace TPA.Reflection.UnitTest
{
  [TestClass]
  public class DataBindingTest
  {

    [TestMethod]
    public void ParametersValidationTest()
    {
      DataSource _dataSource = new DataSource();
      DataConsumer _dataConsumer = new DataConsumer();
      Assert.ThrowsException<ArgumentNullException>(() => new DataBinding(null, StringPropName, _dataConsumer, IntPropConsumerName), "The exception must be thrown if dataSource is null");
      Assert.ThrowsException<ArgumentNullException>(() => new DataBinding(_dataSource, StringPropName, null, IntPropConsumerName), "The exception must be thrown if consumer is null");
      Assert.ThrowsException<ArgumentException>(() => new DataBinding(_dataSource, StringPropName, _dataConsumer, IntPropConsumerName), "The exception must be thrown if properties types don't match");
      Assert.ThrowsException<ArgumentException>(() => new DataBinding(_dataSource, StringPropName + "A", _dataConsumer, IntPropConsumerName), "The exception must be thrown if property name is wrong in Data Source");
      Assert.ThrowsException<ArgumentException>(() => new DataBinding(_dataSource, StringPropName, _dataConsumer, IntPropConsumerName + "A"), "The exception must be thrown if property name is wrong in Data Consumer");
    }

    [TestMethod]
    public void CheckAssignmentToAppropriateTypes()
    {
      DataSource _dataSource = new DataSource() { StringProperty = "Source", IntProperty = 3 };
      DataConsumer _dataConsumer = new DataConsumer() { StringPropertyConsumer = "Consumer", IntPropertyConsumer = 4 };
      DataBinding _binding = new DataBinding(_dataSource, StringPropName, _dataConsumer, StringPropConsumerName);
      Assert.AreEqual(_dataSource.StringProperty, _dataConsumer.StringPropertyConsumer);
      _dataSource.StringProperty = "New String";
      Assert.AreEqual("New String", _dataConsumer.StringPropertyConsumer);
      DataBinding bindingInt = new DataBinding(_dataSource, IntPropName, _dataConsumer, IntPropConsumerName);
      Assert.AreEqual(_dataSource.IntProperty, _dataConsumer.IntPropertyConsumer);
      _dataSource.IntProperty = 15;
      Assert.AreEqual(15, _dataConsumer.IntPropertyConsumer);
    }

    [TestMethod]
    public void CheckAssignmentFromValueType()
    {
      DataSource _dataSource = new DataSource() { IntProperty = 3 };
      DataConsumer _dataConsumer = new DataConsumer() { ValuePropertyConsumer = 6 };
      DataBinding _binding = new DataBinding(_dataSource, IntPropName, _dataConsumer, ValueTypePropConsumerName);
      Assert.AreEqual(_dataSource.IntProperty, _dataConsumer.ValuePropertyConsumer);
      _dataSource.IntProperty = 87;
      Assert.AreEqual(87, _dataConsumer.ValuePropertyConsumer);
    }

    #region test instrumentation
    private const string StringPropName = "StringProperty";
    private const string IntPropName = "IntProperty";
    private const string StringPropConsumerName = "StringPropertyConsumer";
    private const string IntPropConsumerName = "IntPropertyConsumer";
    private const string ValueTypePropConsumerName = "ValuePropertyConsumer";
    private class DataSource : INotifyPropertyChanged
    {

      public int IntProperty
      {
        get { return m_intField; }
        set
        {
          m_intField = value;
          OnPropertyChanged("IntProperty");
        }
      }
      public string StringProperty
      {
        get { return m_stringField; }
        set
        {
          m_stringField = value;
          OnPropertyChanged("StringProperty");
        }
      }
      public event PropertyChangedEventHandler PropertyChanged;

      #region private
      private int m_intField = 0;
      private string m_stringField = "";
      private void OnPropertyChanged([CallerMemberName] string propertyName = null)
      {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
      #endregion

    }
    internal class DataConsumer
    {
      public int IntPropertyConsumer { get; set; }
      public string StringPropertyConsumer { get; set; }
      public ValueType ValuePropertyConsumer { get; set; }
    }
    #endregion

  }
}
