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
  internal class BusinessBall : IBall
  {
    public BusinessBall(Position startingPosition)
    {
      position = startingPosition;
    }

    #region IBall

    public event EventHandler<IPosition>? NewPositionNotification;

    public void Dispose()
    {
      if (disposed)
        throw new ObjectDisposedException(nameof(BusinessBall));
      disposed = true;
      NewPositionNotification = null;
    }

    #endregion IBall

    #region private

    internal void Move(Position delta)
    {
      if (disposed)
        throw new ObjectDisposedException(nameof(BusinessBall));
      position = new Position(position.x + delta.x, position.y + delta.y);
      NewPositionNotification?.Invoke(this, position);
    }

    private bool disposed = false;
    private Position position = new Position(0.0, 0.0);

    #endregion private

    #region TestingInfrastructure

    [Conditional("DEBUG")]
    internal void CheckIfBalls2DisposeIsAssigned(Action<EventHandler<IPosition>?> returnNewPositionNotification)
    {
      returnNewPositionNotification(NewPositionNotification);
    }

    [Conditional("DEBUG")]
    internal void CheckIfLocalDisposedVariable(Action<bool> returnDisposed)
    {
      returnDisposed(disposed);
    }

    #endregion TestingInfrastructure
  }
}