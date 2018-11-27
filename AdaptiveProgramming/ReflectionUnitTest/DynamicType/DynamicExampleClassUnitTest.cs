//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPA.Reflection.DynamicType;

namespace TPA.Reflection.UnitTest.DynamicType
{

  [TestClass]
  public class DynamicExampleClassUnitTest
  {
    [TestMethod]
    public void ConstructorTestMethod()
    {
      DynamicExampleClass _newStrongTypedInstance = new DynamicExampleClass();
      Assert.IsNotNull(_newStrongTypedInstance);
      Assert.IsTrue(_newStrongTypedInstance is DynamicExampleClass);

      object _newObjectInstance = new DynamicExampleClass();
      Assert.IsNotNull(_newObjectInstance);
      Assert.IsTrue(_newObjectInstance is DynamicExampleClass);

      dynamic _newDynamicInstance = new DynamicExampleClass();
      Assert.IsNotNull(_newDynamicInstance);
      Assert.IsTrue(_newDynamicInstance is DynamicExampleClass);
    }
    [TestMethod]
    public void IncrementIntTest()
    {
      DynamicExampleClass _newStrongTypedInstance = new DynamicExampleClass();
      Assert.AreEqual<int>(11, _newStrongTypedInstance.Increment(10));
    }
    [TestMethod]
    [ExpectedException(typeof(Microsoft.CSharp.RuntimeBinder.RuntimeBinderException))]
    public void IncrementStringTest()
    {
      DynamicExampleClass _newStrongTypedInstance = new DynamicExampleClass();
      Assert.AreEqual<int>(11, _newStrongTypedInstance.Increment("10"));
    }
    [TestMethod]
    public void IncrementDynamicTest()
    {
      dynamic _newStrongTypedInstance = new DynamicExampleClass();
      Assert.AreEqual<int>(11, _newStrongTypedInstance.Increment(10));
    }
    [TestMethod]
    [ExpectedException(typeof(Microsoft.CSharp.RuntimeBinder.RuntimeBinderException))]
    public void IncrementDynamicWrongNumberOfParametersTest()
    {
      dynamic _newStrongTypedInstance = new DynamicExampleClass();
      Assert.AreEqual<int>(11, _newStrongTypedInstance.Increment(10, "10"));
    }
    [TestMethod]
    public void Main()
    {
      DynamicExampleClass _ec = new DynamicExampleClass();
      Assert.AreEqual<int>(2, _ec.ExampleMethod("value"));
      Assert.AreEqual<string>("Local variable", _ec.ExampleMethod(10));
    }

  }
}
