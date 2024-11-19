//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2024, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//_____________________________________________________________________________________________________________________________________

using System;
using System.Diagnostics;
using System.Reactive;
using System.Reactive.Linq;
using UnderneathLayerAPI = TP.ConcurrentProgramming.BusinessLogic.BusinessLogicAbstractAPI;

namespace TP.ConcurrentProgramming.Presentation.Model
{
  /// <summary>
  /// Class Model - implements the <see cref="ModelAbstractApi" />
  /// </summary>
  internal class ModelImplementation : ModelAbstractApi
  {
    internal ModelImplementation() : this(null)
    { }

    internal ModelImplementation(UnderneathLayerAPI underneathLayer)
    {
      layerBellow = underneathLayer == null ? UnderneathLayerAPI.GetBusinessLogicLayer() : underneathLayer;
      eventObservable = Observable.FromEventPattern<BallChaneEventArgs>(this, "BallChanged");
    }

    #region ModelAbstractApi

    public override void Dispose()
    {
      if (Disposed)
        throw new ObjectDisposedException(nameof(Model));
      layerBellow.Dispose();
      Disposed = true;
    }

    public override IDisposable Subscribe(IObserver<IBall> observer)
    {
      return eventObservable.Subscribe(x => observer.OnNext(x.EventArgs.Ball), ex => observer.OnError(ex), () => observer.OnCompleted());
    }

    public override void Start(int numberOfBalls)
    {
      layerBellow.Start(numberOfBalls, StartHandler);
    }

    #endregion ModelAbstractApi

    #region API

    public event EventHandler<BallChaneEventArgs> BallChanged;

    #endregion API

    #region private

    private bool Disposed = false;
    private readonly IObservable<EventPattern<BallChaneEventArgs>> eventObservable = null;
    private readonly UnderneathLayerAPI layerBellow = null;

    private void StartHandler(BusinessLogic.IPosition position, BusinessLogic.IBall ball)
    {
      ModelBall newBall = new ModelBall(position.x, position.y, ball) { Diameter = 20.0 };
      BallChanged.Invoke(this, new BallChaneEventArgs() { Ball = newBall });
    }

    #endregion private

    #region TestingInfrastructure

    [Conditional("DEBUG")]
    internal void CheckObjectDisposed(Action<bool> returnInstanceDisposed)
    {
      returnInstanceDisposed(Disposed);
    }

    [Conditional("DEBUG")]
    internal void CheckUnderneathLayerAPI(Action<UnderneathLayerAPI> returnNumberOfBalls)
    {
      returnNumberOfBalls(layerBellow);
    }

    [Conditional("DEBUG")]
    internal void CheckBallChangedEvent(Action<bool> returnBallChangedIsNull)
    {
      returnBallChangedIsNull(BallChanged == null);
    }

    #endregion TestingInfrastructure
  }

  public class BallChaneEventArgs : EventArgs
  {
    public IBall Ball { get; init; }
  }
}