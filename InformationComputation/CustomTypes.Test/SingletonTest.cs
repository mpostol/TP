//__________________________________________________________________________________________
//
//  Copyright 2022 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

namespace TP.InformationComputation.CustomTypes
{
  [TestClass]
  public class SingletonTest
  {
    [TestMethod]
    public void SingletonTestMethod()
    {
      Singleton _instance1 = Singleton.SingletonInstance;
      Singleton _instance2 = Singleton.SingletonInstance;
      Assert.AreSame(_instance1, _instance2);
      Assert.AreEqual(_instance1.GetHashCode(), _instance1.GetHashCode());
    }
  }
}