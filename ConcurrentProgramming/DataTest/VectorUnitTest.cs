//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2024, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//_____________________________________________________________________________________________________________________________________

namespace TP.ConcurrentProgramming.Data.Test
{
  [TestClass]
  public class VectorUnitTest
  {
    [TestMethod]
    public void ConstructorTestMethod()
    {
      Random randomGenerator = new();
      double XComponent = randomGenerator.NextDouble();
      double YComponent = randomGenerator.NextDouble();
      Vector newInstance = new(XComponent, YComponent);
      Assert.AreEqual<double>(XComponent, newInstance.x);
      Assert.AreEqual<double>(YComponent, newInstance.y);
    }
  }
}