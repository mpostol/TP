//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2024, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//  by introducing yourself and telling us what you do with this community.
//_____________________________________________________________________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TP.GraphicalData.Model.Test
{
  /// <summary>
  /// Place to test the Model sublayer
  /// </summary>
  [TestClass]
  public class ModelTest
  {
    [TestMethod]
    public void DataLayerTestMethod()
    {
      ModelSublayerAPI dl = ModelSublayerAPI.Create();
      Assert.IsNotNull(dl);
    }
  }
}