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
  public class BusinessBallUnitTest1
  {
    //[TestMethod]
    //public void ConstructorTestMethod()
    //{
    //  using (BusinessBall newInstance = new(new Position(0.0, 0.0)))
    //  { }
    //}

    //[TestMethod]
    //public void DisposeTestMethod()
    //{
    //  Position initialPosition = new(10.0, 10.0);
    //  BusinessBall newInstance = new(initialPosition);
    //  bool disposedClone = true;
    //  newInstance.CheckIfLocalDisposedVariable(x => disposedClone = x);
    //  Assert.IsFalse(disposedClone);
    //  newInstance.Dispose();
    //  newInstance.CheckIfLocalDisposedVariable(x => disposedClone = x);
    //  Assert.IsTrue(disposedClone);
    //  Assert.ThrowsException<ObjectDisposedException>(() => newInstance.Move(new Position(0.0, 0.0)));
    //  Assert.ThrowsException<ObjectDisposedException>(() => newInstance.Dispose());
    //}

    [TestMethod]
    public void MoveTestMethod()
    {
      Position initialPosition = new(10.0, 10.0);
      BusinessBall newInstance = new(initialPosition);
      IPosition curentPosition = new Position(0.0, 0.0);
      int callBackCalled = 0;
      newInstance.NewPositionNotification += (sender, position) => { Assert.IsNotNull(sender); curentPosition = position; callBackCalled++; };
      newInstance.Move(new Position(0.0, 0.0));
      Assert.AreEqual<int>(1, callBackCalled);
      Assert.AreEqual<IPosition>(initialPosition, curentPosition);
    }
  }
}