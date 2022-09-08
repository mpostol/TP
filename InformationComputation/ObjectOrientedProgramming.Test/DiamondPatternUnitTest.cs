//__________________________________________________________________________________________
//
//  Copyright 2022 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

namespace TP.InformationComputation.ObjectOrientedProgramming
{
  [TestClass]
  public class DiamondPatternUnitTest
  {
    [TestMethod]
    public void DiamondPatternCreationTest()
    {
      Bottom bottom = new Bottom();
      Left left = new Left(bottom);
      Assert.AreSame(left.BottomEntity, bottom);
      Right right = new Right(bottom);
      Assert.AreSame(right.BottomEntity, bottom);
      Top top = new Top(left, right);
      Assert.IsNotNull(top.LeftEntity);
      Assert.IsNotNull(top.RightEntity);
      Assert.AreSame(left, top.LeftEntity);
      Assert.AreSame(right, top.RightEntity);
    }
  }
}