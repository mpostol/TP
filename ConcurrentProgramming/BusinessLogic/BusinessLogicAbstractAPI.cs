//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2024, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//_____________________________________________________________________________________________________________________________________

namespace TP.ConcurrentProgramming.BusinessLogic
{
  public abstract class BusinessLogicAbstractAPI : IDisposable
  {
    #region Layer Factory

    public static BusinessLogicAbstractAPI GetBusinessLogicLayer()
    {
      return modelInstance.Value;
    }

    #endregion Layer Factory

    #region Layer API

    public abstract event EventHandler<NewBallNotificationEventArgs> OnNewBallCreating;

    public readonly Dimensions GetDimensions = new(10.0, 10.0, 10.0);

    public abstract void Start(int numberOfBalls);

    #region IDisposable

    public abstract void Dispose();

    #endregion IDisposable

    #endregion Layer API

    #region private

    private static Lazy<BusinessLogicAbstractAPI> modelInstance = new Lazy<BusinessLogicAbstractAPI>(() => new BusinessLogicImplementation());

    #endregion private
  }

  public class NewBallNotificationEventArgs : EventArgs
  {
    public NewBallNotificationEventArgs(IBall newBall) : base()
    {
      Ball = newBall;
    }

    public IBall Ball { get; init; }
  }
}

public record Dimensions(double BallDimension, double TableHeight, double TableWidth);
public record Position(double x, double y);

public interface IBall : IDisposable
{
  event EventHandler<Position> NewPositionNotification;
}