using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TP.Lecture.UnitTest
{
  [TestClass]
  public class ExtensionMethodsUnitTest
  {
    /// <summary>
    /// In your code you invoke the extension method with instance method syntax. 
    /// </summary>
    [TestMethod]
    public void InstanceCallTestMethod()
    {
      string _TestString = "Hello Extension Methods";
      Assert.AreEqual<int>(3, _TestString.WordCount()); //To enable extension methods for a particular type, the definition must be visible.
      Assert.AreEqual<int>(3, ExtensionMethods.WordCount(_TestString)); //Typical method call can also be in use.
    }
    /// <summary>
    /// Mies the test method.
    /// </summary>
    [TestMethod]
    public void OverrideTestMethod()
    {
      string _TestString = "Hello Extension Methods";
      Assert.IsTrue(_TestString.Contains("Hello")); //The existing class method cannot be replaced. An extension method with the same name and signature as an interface or class method will never be called.
    }
    [TestMethod]
    public void MyTestMethod()
    {
      // Declare an instance of class B, and class C.
      B b = new B();
      C c = new C();

      Assert.AreEqual<int>(-1, b.MethodA(1)); // Extension.MethodA(object, int)
      string _inputString = "hello";
      string _expectedResult = "s=hello";
      Assert.AreEqual<string>(_expectedResult, b.MethodA(_inputString)); // Extension.MethodA(object, string)
      //Note difference between same and equal.
      Assert.AreNotSame(_expectedResult, b.MethodA(_inputString)); // Extension.MethodA(object, string)

      // C contains an instance method that matches each of the following method calls.
      Assert.AreEqual<int>(1, (int)c.MethodA(1));           // C.MethodA(object)
      Assert.AreSame(_inputString, c.MethodA(_inputString));     // C.MethodA(object)
      Assert.AreNotSame(new AnyClass(), c.MethodA(new AnyClass()));
    }
    private class AnyClass
    {

    }
  }
}

