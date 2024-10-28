//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2024, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//_____________________________________________________________________________________________________________________________________

using System.Diagnostics;

namespace TP.ConcurrentProgramming.BusinessLogic
{
  internal class BusinessLogicImplementation : BusinessLogicAbstractAPI
  {
    #region ctor

    public BusinessLogicImplementation()
    {
      MoveTimer = new Timer(Move, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(100));
    }

    #endregion ctor

    #region BusinessLogicAbstractAPI

    public override void Dispose()
    {
      if (Disposed)
        throw new ObjectDisposedException(nameof(BusinessLogicImplementation));
      MoveTimer.Dispose();
      BallsList.Clear();
      Disposed = true;
    }

    public override void Start(int numberOfBalls, Action<IPosition, IBall> upperLayerHandler)
    {
      if (Disposed) 
        throw new ObjectDisposedException(nameof(BusinessLogicImplementation));
      if (upperLayerHandler == null) 
        throw new ArgumentNullException(nameof(upperLayerHandler));
      Random random = new Random();
      for (int i = 0; i < numberOfBalls; i++)
      {
        Position startingPosition = new Position(random.Next(100, 400 - 100), random.Next(100, 400 - 100));
        BusinessBall newBall = new BusinessBall(startingPosition);
        upperLayerHandler(startingPosition, newBall);
        BallsList.Add(newBall);
      }
    }

    #endregion BusinessLogicAbstractAPI

    #region private

    private bool Disposed = false;
    private readonly Timer MoveTimer;
    private Random RandomGenerator = new();
    private List<BusinessBall> BallsList = new();

    private void Move(object? x)
    {
      foreach (BusinessBall item in BallsList)
        item.Move(new Position((RandomGenerator.NextDouble() - 0.5) * 10, (RandomGenerator.NextDouble() - 0.5) * 10));
    }

    #endregion private

    #region TestingInfrastructure

    [Conditional("DEBUG")]
    internal void CheckIfBalls2DisposeIsAssigned(Action<IEnumerable<IBall>> returnBalls2DisposeList)
    {
      returnBalls2DisposeList(BallsList);
    }

    [Conditional("DEBUG")]
    internal void CheckBalls2Dispose(Action<int> returnNumberOfBalls)
    {
      returnNumberOfBalls(BallsList.Count);
    }

    [Conditional("DEBUG")]
    internal void CheckObjectDisposed(Action<bool> returnInstanceDisposed)
    {
      returnInstanceDisposed(Disposed);
    }
    #endregion TestingInfrastructure
  }
}