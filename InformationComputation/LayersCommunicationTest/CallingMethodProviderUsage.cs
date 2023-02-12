//__________________________________________________________________________________________
//
//  Copyright 2023 Mariusz Postol LODZ POLAND.
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
  public class CallingMethodProviderUsage
  {
    [TestMethod]
    public void CallingMethodProviderCorrectSequenceTest()
    {
      Logic.ICallingMethod callingMethodProvider = ILogicAbstraction.NewCallingMethodProvider();
      callingMethodProvider.Alpha();
      callingMethodProvider.Bravo();
      callingMethodProvider.Charlie();
      callingMethodProvider.Delta();
      Assert.IsTrue(callingMethodProvider.CheckConsistency());
    }

    [TestMethod]
    public void CallingMethodProviderWrongSequenceTest()
    {
      ICallingMethod callingMethodProvider = ILogicAbstraction.NewCallingMethodProvider();
      callingMethodProvider.Alpha();
      callingMethodProvider.Charlie();//the wrong sequence of calls, Bravo should be called before Charlie
      callingMethodProvider.Bravo();
      callingMethodProvider.Delta();
      Assert.ThrowsException<ApplicationException>(() => callingMethodProvider.CheckConsistency());
    }
  }
}