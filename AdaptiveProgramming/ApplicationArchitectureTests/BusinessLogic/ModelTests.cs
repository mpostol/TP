//___________________________________________________________________________________
//
//  Copyright (C) 2021, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TPA.ApplicationArchitecture.BusinessLogic.Tests
{
  [TestClass()]
  public class ModelTests
  {
    [TestMethod()]
    public void ModelTest()
    {
      TestLinq2SQLFixcture dataLayerTestingFixture = new TestLinq2SQLFixcture();
      Model model = new Model(dataLayerTestingFixture);
      Assert.AreEqual<int>(1, dataLayerTestingFixture.ConnectedCallCount);
    }
  }
}