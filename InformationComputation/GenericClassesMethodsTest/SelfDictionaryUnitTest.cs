#nullable disable
//__________________________________________________________________________________________
//
//  Copyright 2023 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

namespace TP.InformationComputation.GenericClassesMethods
{
  [TestClass]
  public class SelfDictionaryUnitTest
  {
    [TestMethod]
    public void SelfDictionaryTest()
    {
      SelfDictionary<EquatableNotImplemented> dictionary = new SelfDictionary<EquatableNotImplemented>();
      dictionary.AddIfNotPresent(new EquatableNotImplemented());
      EquatableNotImplemented EquatableNotImplementedInstance = new EquatableNotImplemented();
      dictionary.AddIfNotPresent(EquatableNotImplementedInstance);
      Assert.AreEqual<int>(2, dictionary.Count);
      Assert.ThrowsException<NotImplementedException>(() => dictionary.AddIfNotPresent(EquatableNotImplementedInstance));
      Assert.ThrowsException<NotImplementedException>(() => dictionary.ContainsKey(EquatableNotImplementedInstance));
    }

    //instrumentation
    private class EquatableNotImplemented : IEquatable<EquatableNotImplemented>
    {
      public bool Equals(EquatableNotImplemented other)
      {
        throw new NotImplementedException();
      }
    }
  }
}
#nullable restore