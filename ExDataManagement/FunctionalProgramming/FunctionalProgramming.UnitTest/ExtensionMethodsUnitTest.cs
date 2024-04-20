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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TP.FunctionalProgramming
{
  /// <summary>
  /// Class ExtensionMethodsUnitTest - main purpose of this class is to present main features of the extension method, but not to test code validation.
  /// </summary>
  [TestClass]
  public class ExtensionMethodsUnitTest
  {
    /// <summary>
    /// To call static method in a chain we need temporary variables.
    /// </summary>
    [TestMethod]
    public void TypicalCallTestMethod()
    {
      string _TestString = "Hello Extension Methods";
      int _wordCount = ExtensionMethods.WordCount(_TestString);
      Assert.IsFalse(ExtensionMethods.Even(_wordCount));
    }

    /// <summary>
    /// You can invoke the extension method with instance method syntax.
    /// </summary>
    [TestMethod]
    public void CascadedCallTestMethod()
    {
      string _TestString = "Hello Extension Methods";
      Assert.IsFalse(_TestString.WordCount().Even()); //To enable extension methods for a particular type, the definition must be visible.
      Assert.AreEqual<int>(_TestString.WordCount(), ExtensionMethods.WordCount(_TestString)); //Typical method call can also be in use.
    }

    /// <summary>
    /// Test method of the rule: the existing class method cannot be replaced by an extension method.
    /// </summary>
    [TestMethod]
    public void CollisionWithInstanceMemberTest()
    {
      string testString = "Hello Extension Methods";
      Assert.IsTrue(testString.Contains("Hello")); //An extension method with the same name and signature as an interface or class method will never be called.
      Assert.ThrowsException<NotImplementedException>(() => ExtensionMethods.Contains(testString, "Hello"));
    }

    /// <summary>
    /// Instance method call if the reference is null
    /// </summary>
    [TestMethod]
    public void NullCallExceptionTest()
    {
      IMyInterface _myInterface = null;
      Assert.ThrowsException<NullReferenceException>(() => _myInterface.MyInterfaceMethod()); //Here the runtime throws the exception NullReferenceException.
      Assert.ThrowsException<ArgumentNullException>(() => _myInterface.ProtectedMyInterfaceMethodCall()); //Here the ProtectedMyInterfaceMethodCall method is executed despite the reference being null.
    }
  }
}