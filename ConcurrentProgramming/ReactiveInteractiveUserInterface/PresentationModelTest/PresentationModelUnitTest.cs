//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2024, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//_____________________________________________________________________________________________________________________________________

using TP.ConcurrentProgramming.Presentation.Model;

namespace TP.ConcurrentProgramming.PresentationModelTest
{
  [TestClass]
  public class PresentationModelUnitTest
  {
    [TestMethod]
    public void ConstructorTest()
    {
      Model newInstance = new();
      IList<IDisposable>? ballsToDisposeList = null;
      newInstance.CheckIfBalls2DisposeIsAssigned(x => ballsToDisposeList = x);
      Assert.IsNotNull(ballsToDisposeList);
      int numberOfBalls = 0;
      newInstance.CheckIfBalls2DisposeIsAssigned(x => ballsToDisposeList = x);
      newInstance.CheckBalls2Dispose(x => numberOfBalls = x);
      Assert.AreEqual<int>(0, numberOfBalls);
      newInstance.Start(10);
      newInstance.CheckBalls2Dispose(x => numberOfBalls = x);
      Assert.AreEqual<int>(10, numberOfBalls);
      newInstance.Dispose();
      newInstance.CheckBalls2Dispose(x => numberOfBalls = x);
      Assert.AreEqual<int>(0, numberOfBalls);
    }
  }
}