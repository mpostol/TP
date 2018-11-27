#pragma warning disable CS0612 // Type or member is obsolete

//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TP.DataStreams.Reflection;

namespace TP.DataStreams
{
  [TestClass]
  public class ReflectionUnitTest
  {

    [TestMethod]
    public void CustomAttributeTest()
    {
      CustomAttribute _attribute = new CustomAttribute("Instance description");
      Assert.IsNotNull(_attribute);
      Assert.AreEqual<string>("Instance description", _attribute.Description);
    }
    [TestMethod]
    public void ObsoleteTest()
    {
      object _unknownObject = AttributedClass.GetObject();
      Assert.IsNotNull(_unknownObject);
    }
    [TestMethod]
    public void AttributedClassTypeTest()
    {
      Type _objectType = typeof(AttributedClass);
      GoTest(_objectType);
    }
    [TestMethod]
    public void AttributedClassInstanceTest()
    {
      foreach (ObjectFactory.CreationHints _item in Enum.GetValues(typeof(ObjectFactory.CreationHints)))
      {
        object _attributedObject = ObjectFactory.CreateObject(_item);
        Type _objectType = _attributedObject.GetType();
        GoTest(_objectType);
      }
    }
    [TestMethod]
    public void AttachedPropertyTest()
    {
      Siyova16 _dataSource = new Siyova16(); //Create an instance of any class
      Assert.ThrowsException<ArgumentNullException>(() => new AttachedProperty<double>(null, "Rewoca75"), "The exception must be thrown if dataSource is null");
      Assert.ThrowsException<ArgumentException>(() => new AttachedProperty<string>(_dataSource, "Rewoca75"), "The exception must be thrown if properties types don't match");
      Assert.ThrowsException<ArgumentException>(() => new AttachedProperty<double>(_dataSource, "Rewoca75" + "A"), "The exception must be thrown if property name is wrong");
      AttachedProperty<double> _newProperty = new AttachedProperty<double>(_dataSource, "Rewoca75");
      _dataSource.Rewoca75 = 123456789.987;
      Assert.AreEqual<double>(123456789.987, _newProperty.Value);
      _newProperty.Value = 987654321.123;
      Assert.AreEqual<double>((double)987654321.123, _dataSource.Rewoca75);
    }

    #region test instrumentation
    [CustomAttribute("Description of the class")]
    private class Siyova16 //pronounce any class
    {
      public double Rewoca75 { get; set; } //pronounce any property
      public int Tohewu22 { get; set; } //pronounce any property
      public string Vupowe51 { get; set; } //pronounce any property
      public Tuple<double, int, string> Yozoho42 { get; set; } //pronounce any property
    }
    private static class ObjectFactory
    {
      internal enum CreationHints { Suxuxe12, Gipoci82 }
      internal static object CreateObject(CreationHints hints)
      {
        object _return = null;
        switch (hints)
        {
          case CreationHints.Suxuxe12:
            _return = new AttributedClass();
            break;
          case CreationHints.Gipoci82:
            _return = new Siyova16();
            break;
        }
        return _return;
      }
    }
    private static void GoTest(Type objectType)
    {
      Object[] _attribute = objectType.GetCustomAttributes(typeof(CustomAttribute), false);
      Assert.AreEqual<int>(1, _attribute.Length);
      CustomAttribute _expectedAttribute = _attribute[0] as CustomAttribute;
      Assert.IsNotNull(_expectedAttribute);
      Assert.AreEqual<string>("Description of the class", _expectedAttribute.Description);
    }
    #endregion

  }
}

#pragma warning restore CS0612 // Type or member is obsolete
