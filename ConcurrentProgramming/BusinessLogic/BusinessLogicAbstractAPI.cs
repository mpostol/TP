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
  public abstract class BusinessLogicAbstractAPI: IDisposable
  {
    #region Layer Factory

    public static BusinessLogicAbstractAPI CreateModel()
    {
      return modelInstance.Value;
    }

    #endregion Layer Factory

    public readonly Dimensions GetDimensions = new(10.0, 10.0, 10.0);

    public abstract IEnumerable<IBall> Start(int numberOfBalls);

    #region IDisposable

    public abstract void Dispose();

    #endregion IDisposable

    #region private

    private static Lazy<BusinessLogicAbstractAPI> modelInstance = new Lazy<BusinessLogicAbstractAPI>(() => new BusinessLogic());

    #endregion private
  }

  public record Dimensions(double BallDimension, double TableHeight, double TableWidth);
  public record Position(double x, double y);

  public interface IBall
  {
    event EventHandler<Position> NewPositionNotification;
  }
}