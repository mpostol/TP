//__________________________________________________________________________________________
//
//  Copyright 2022 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

using Microsoft.CSharp.RuntimeBinder;
using System.Globalization;

namespace TP.InformationComputation.AnonymousTypes
{
  [TestClass]
  public class TypesCompatibility
  {
    [TestMethod]
    public void DivisionTest()
    {
      //int example
      int intDdividend = 5;
      float result = intDdividend / 2;
      Assert.AreEqual(2, result);
      
      //float example
      float dividend = 5;
      result = dividend / 2;
      Assert.AreEqual(2.5, result);
    }

    [TestMethod]
    public void ObjectTest()
    {
      object objectExample = 5.0f;
      Assert.IsTrue(objectExample is float);
      Assert.AreEqual(5.0f, objectExample);
      //objectExample = objectExample / 2.0f; //Operator '/' cannot be applied to operands of type 'object' and 'float'
      objectExample = "New Value";
      Assert.IsTrue(objectExample is string);
      Assert.AreEqual("New Value", objectExample);
    }

    [TestMethod]
    public void VARTest()
    {
      int integerExample = 5;
      //var integerExample = 5;
      integerExample = integerExample / 2;
      Assert.AreEqual(2, integerExample);
      Assert.IsTrue(integerExample is int);
      //integerExample = " "; //Cannot implicitly convert type 'string' to 'int'
    }

    [TestMethod]
    public void DynamicTest()
    {
      dynamic dynamic = 5.0f;
      Assert.IsTrue(dynamic is float);
      dynamic += 1.0;
      Assert.AreEqual(6, dynamic);
      dynamic = "String";
      Assert.AreEqual("String", dynamic);
      Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture; //before conversion to string a well-defined culture must be set up to guarantee that the result doesn't depend on the computer settings
      dynamic += 1.5f; //conversion of the value of the float type to string is expected. The result is concatenated with the current value of the variable.
      Assert.AreEqual("String1.5", dynamic);
      Assert.AreEqual("1.5", 1.5f.ToString());
      Assert.ThrowsException<RuntimeBinderException>(() => dynamic /= 1);
    }
  }
}
