//__________________________________________________________________________________________
//
//  Copyright 2022 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

using TP.InformationComputation.LayersCommunication.Logic;

namespace TP.InformationComputation.LayersCommunication
{
  [TestClass]
  public class CallingMethodProviderTest
  {
    [TestMethod]
    public void CallingMethodProviderCorrectSequenceTest()
    {
      Logic.ICallingMethodProvider callingMethodProvider = LogicAbstraction.NewCallingMethodProvider();
      callingMethodProvider.Alpha();
      callingMethodProvider.Bravo();
      callingMethodProvider.Charlie();
      callingMethodProvider.Delta();
      Assert.IsTrue(callingMethodProvider.CheckConsistency());
    }

    [TestMethod]
    public void CallingMethodProviderWrongSequenceTest()
    {
      ICallingMethodProvider callingMethodProvider = LogicAbstraction.NewCallingMethodProvider();
      callingMethodProvider.Alpha();
      callingMethodProvider.Charlie();// wrong sequence of calls, Bravo should be before Charlie
      callingMethodProvider.Bravo();
      callingMethodProvider.Delta();
      Assert.ThrowsException<ApplicationException>(() => callingMethodProvider.CheckConsistency());
    }
  }
}