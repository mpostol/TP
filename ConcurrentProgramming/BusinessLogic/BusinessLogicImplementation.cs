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
    #region BusinessLogicAbstractAPI

    public override void Dispose()
    {
      throw new NotImplementedException();
    }

    public override void Start(int numberOfBalls)
    {
      Random random = new Random();
      for (int i = 0; i < numberOfBalls; i++)
      {
        BusinessBall newBall = new BusinessBall(random.Next(100, 400 - 100), random.Next(100, 400 - 100));
        Balls2Dispose.Add(newBall);
        OnNewBallCreating?.Invoke(this, new NewBallNotificationEventArgs(newBall));
      }
    }

    public override event EventHandler<NewBallNotificationEventArgs> OnNewBallCreating;

    #endregion BusinessLogicAbstractAPI

    #region private

    private List<IBall> Balls2Dispose = new List<IBall>();

    #endregion private

    #region TestingInfrastructure

    [Conditional("DEBUG")]
    internal void CheckIfBalls2DisposeIsAssigned(Action<IList<IBall>> returnBalls2DisposeList)
    {
      returnBalls2DisposeList(Balls2Dispose);
    }

    [Conditional("DEBUG")]
    internal void CheckBalls2Dispose(Action<int> returnNumberOfBalls)
    {
      returnNumberOfBalls(Balls2Dispose.Count);
    }

    #endregion TestingInfrastructure
  }
}