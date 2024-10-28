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
  public class BusinessLogicImplementationUnitTest
  {
    [TestMethod]
    public void ConstructorTestMethod()
    {
      BusinessLogicImplementation newInstance = new BusinessLogicImplementation();
      IEnumerable<IDisposable>? ballsToDisposeList = null;
      newInstance.CheckIfBalls2DisposeIsAssigned(x => ballsToDisposeList = x);
      Assert.IsNotNull(ballsToDisposeList);
      int numberOfBalls = 0;
      newInstance.CheckBalls2Dispose(x => numberOfBalls = x);
      Assert.AreEqual<int>(0, numberOfBalls);
    }

    [TestMethod]
    public void DisposeTestMethod()
    {
      BusinessLogicImplementation newInstance = new BusinessLogicImplementation();
      newInstance.Dispose();
      bool newInstanceDisposed = false;
      newInstance.CheckObjectDisposed(x => newInstanceDisposed = x);
      Assert.IsTrue(newInstanceDisposed);
      IEnumerable<IBall>? ballsToDisposeList = null;
      newInstance.CheckIfBalls2DisposeIsAssigned(x => ballsToDisposeList = x);
      Assert.IsNotNull(ballsToDisposeList);
      foreach (IBall item in ballsToDisposeList)
        Assert.ThrowsException<ObjectDisposedException>(() => item.Dispose());
      int numberOfBalls = 0;
      newInstance.CheckBalls2Dispose(x => numberOfBalls = x);
      Assert.AreEqual<int>(0, numberOfBalls);
      Assert.ThrowsException<ObjectDisposedException>(() => newInstance.Dispose());
      Assert.ThrowsException<ObjectDisposedException>(() => newInstance.Start(0, (position, ball) => { }));
    }

    [TestMethod]
    public void StartTestMethod()
    {
      BusinessLogicImplementation newInstance = new BusinessLogicImplementation();
      int called = 0;
      int numberOfBalls2Create = 10;
      newInstance.Start(
        numberOfBalls2Create, 
        (startingPosition, ball) => { called++; Assert.IsTrue(startingPosition.x >= 0); Assert.IsTrue(startingPosition.y >= 0); Assert.IsNotNull(ball); });
      Assert.AreEqual<int>(numberOfBalls2Create, called);
      int numberOfBalls = 0;
      newInstance.CheckBalls2Dispose(x => numberOfBalls = x);
      Assert.AreEqual<int>(10, numberOfBalls);
    }
  }
}