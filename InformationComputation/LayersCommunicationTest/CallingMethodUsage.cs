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
  public class CallingMethodUsage
  {
    [TestMethod]
    public void CallingMethodCorrectSequenceTest()
    {
      ICallingMethod callingMethod = ILogicAbstraction.NewCallingMethod();
      callingMethod.Alpha();
      callingMethod.Bravo();
      callingMethod.Charlie();
      callingMethod.Delta();
      Assert.IsTrue(callingMethod.CheckConsistency());
    }

    [TestMethod]
    public void CallingMethodWrongSequenceTest()
    {
      ICallingMethod callingMethod = ILogicAbstraction.NewCallingMethod();
      callingMethod.Alpha();
      callingMethod.Charlie();//the wrong sequence of calls, Bravo should be called before Charlie
      callingMethod.Bravo();
      callingMethod.Delta();
      Assert.ThrowsException<ApplicationException>(() => callingMethod.CheckConsistency());
    }
  }
}