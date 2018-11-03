//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TP.Lecture.LessonExtensionMethods;

namespace TP.Lecture.UnitTest
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
    public void SequentialCallTestMethod()
    {
      string _TestString = "Hello Extension Methods";
      Assert.IsFalse(_TestString.WordCount().Even()); //To enable extension methods for a particular type, the definition must be visible.
      Assert.AreEqual<int>(_TestString.WordCount(), ExtensionMethods.WordCount(_TestString)); //Typical method call can also be in use.
    }
    /// <summary>
    /// Test method of the rule: the existing class method cannot be replaced by an extension method.
    /// </summary>
    [TestMethod]
    public void OverrideTestMethod()
    {
      string _TestString = "Hello Extension Methods";
      Assert.IsTrue(_TestString.Contains("Hello")); //An extension method with the same name and signature as an interface or class method will never be called.
    }
    /// <summary>
    /// Calling the instance method if the reference is null is impossible.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void NullCallExceptionTest()
    {
      IMyInterface _myInterface = null;
      _myInterface.MyInterfaceMethod(); //Here the runtime throws the exception NullReferenceException.
    }
    /// <summary>
    /// Calling the extension method if the reference is null proceeds normally.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void NullCallTest()
    {
      IMyInterface _myInterface = null;
      _myInterface.ProtectedMyInterfaceMethodCall();
    }

  }
}

