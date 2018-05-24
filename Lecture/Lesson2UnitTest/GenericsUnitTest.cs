
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TP.Lecture.UnitTest
{
  [TestClass]
  public class GenericsUnitTest
  {
    [TestMethod]
    public void AfterCreatioValueTestMethod()
    {
      Generics<int> _intInstance = new Generics<int>();
      Assert.AreEqual<int>(default(int), _intInstance.DefaultValue);
    }
    [TestMethod]
    public void AfterCreatioReferenceTestMethod()
    {
      Generics<AnyClass> _intInstance = new Generics<AnyClass>();
      //Assert.AreEqual<int>(0, _intInstance.DefaultValue);
      Assert.IsNull(_intInstance.DefaultValue);
    }
    [TestMethod]
    public void DictionaryCreatorTestMethod()
    {
      //SelfDictionary<AnyClass> _dictionPrim = new SelfDictionary<AnyClass>();
      SelfDictionary<EquatableNotImplemented> _dictionSecond = new SelfDictionary<EquatableNotImplemented>();
    }
    [TestMethod]
    [ExpectedException(typeof(NotImplementedException))]
    public void DictionaryNotImplementedExceptionTestMethod()
    {
      SelfDictionary<EquatableNotImplemented> _dictionary = new SelfDictionary<EquatableNotImplemented>();
      _dictionary.AddIfNotPresent(new EquatableNotImplemented());
      EquatableNotImplemented _EquatableNotImplementedInstance = new EquatableNotImplemented();
      _dictionary.AddIfNotPresent(_EquatableNotImplementedInstance);
      Assert.AreEqual<int>(2, _dictionary.Count);
      _dictionary.ContainsKey(_EquatableNotImplementedInstance);
    }

    #region UT instrumentation
    private class AnyClass { }
    private class EquatableNotImplemented : System.IEquatable<EquatableNotImplemented>
    {
      public bool Equals(EquatableNotImplemented other)
      {
        throw new NotImplementedException();
      }
    }
    #endregion

  }
}
