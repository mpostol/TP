//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2024, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//_____________________________________________________________________________________________________________________________________

using TP.ConcurrentProgramming.BusinessLogic;

namespace TP.ConcurrentProgramming.BusinessLogicTest
{
  [TestClass]
  public class BusinessLogicUnitTest
  {
    [TestMethod]
    public void ConstructorTestMethod()
    {
      BusinessLogicImplementation newInstance = new BusinessLogicImplementation();
      Assert.ThrowsException<NotImplementedException>(() => newInstance.Dispose());
      Assert.AreEqual<Dimensions>(new(10.0, 10.0, 10.0), newInstance.GetDimensions);
      IEnumerable<IDisposable>? ballsToDisposeList = null;
      newInstance.CheckIfBalls2DisposeIsAssigned(x => ballsToDisposeList = x);
      Assert.IsNotNull(ballsToDisposeList);
      int numberOfBalls = 0;
      newInstance.CheckBalls2Dispose(x => numberOfBalls = x);
      Assert.AreEqual<int>(0, numberOfBalls);
    }

    [TestMethod]
    public void StartTestMethod()
    {
      BusinessLogicImplementation newInstance = new BusinessLogicImplementation();
      newInstance.Start(10);
      int numberOfBalls = 0;
      newInstance.CheckBalls2Dispose(x => numberOfBalls = x);
      Assert.AreEqual<int>(10, numberOfBalls);
    }

    [TestMethod]
    public void OnNewBallCreatingTestMethod()
    {
      int numberOfBalls = 0;
      BusinessLogicImplementation newInstance = new BusinessLogicImplementation();
      newInstance.OnNewBallCreating += (source, x) => { numberOfBalls++; Assert.AreSame<object?>(newInstance, source); };
      newInstance.Start(10);
      Assert.AreEqual<int>(10, numberOfBalls);
    }
  }
}