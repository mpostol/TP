//__________________________________________________________________________________________
//
//  Copyright 2021 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started 
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TPA.ApplicationArchitecture.BusinessLogic.Tests
{
  [TestClass()]
  public class BusinessLogicTests
  {
    [TestMethod()]
    public void ConstructorTest()
    {
      TestLinq2SQLFixcture dataLayerTestingFixture = new TestLinq2SQLFixcture();
      BusinessLogicAbstractAPI model = BusinessLogicAbstractAPI.CreateLayer(dataLayerTestingFixture);
      Assert.AreEqual<int>(1, dataLayerTestingFixture.ConnectedCallCount);
    }
  }
}