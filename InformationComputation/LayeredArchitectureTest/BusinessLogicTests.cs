#nullable disable
//__________________________________________________________________________________________
//
//  Copyright 2022 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

using TP.InformationComputation.LayeredArchitecture.Instrumentation;
using TP.InformationComputation.LayeredArchitecture.Logic.AbstractLayerInterface;

namespace TP.InformationComputation.LayeredArchitecture
{
  [TestClass()]
  public class BusinessLogicTests
  {
    [TestMethod()]
    public void ConstructorTest()
    {
      DataLayerAbstractFixture dataLayerTestingFixture = new DataLayerAbstractFixture();
      ILogic logic = LayerFactory.CreateLayer(dataLayerTestingFixture);
      Assert.AreEqual<int>(1, dataLayerTestingFixture.ConnectedCallCount);
      Assert.IsNotNull(logic.NextService);
      Assert.IsNotNull(logic.NextService.Service.Service);
      Assert.IsNotNull(logic.NextService.Service); Assert.AreNotSame(logic.NextService, logic.NextService.Service);
      Assert.AreSame(logic.NextService, logic.NextService.Service.Service);
    }
  }
}
#nullable restore