//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2024, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//_____________________________________________________________________________________________________________________________________

using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;

namespace TP.ConcurrentProgramming.PresentationModel
{
  /// <summary>
  /// Class PresentationModel - implements the <see cref="ModelAbstractApi" />
  /// </summary>
  internal class PresentationModel : ModelAbstractApi
  {
    public PresentationModel()
    {
      eventObservable = Observable.FromEventPattern<BallChaneEventArgs>(this, "BallChanged");
    }

    #region ModelAbstractApi

    public override void Dispose()
    {
      foreach (ModelBall item in Balls2Dispose)
        item.Dispose();
    }

    public override IDisposable Subscribe(IObserver<IBall> observer)
    {
      return eventObservable.Subscribe(x => observer.OnNext(x.EventArgs.Ball), ex => observer.OnError(ex), () => observer.OnCompleted());
    }

    public override void Start(int numberOfBalls)
    {
      Random random = new Random();
      for (int i = 0; i < numberOfBalls; i++)
      {
        ModelBall newBall = new ModelBall(random.Next(100, 400 - 100), random.Next(100, 400 - 100)) { Diameter = 20 };
        Balls2Dispose.Add(newBall);
        BallChanged?.Invoke(this, new BallChaneEventArgs() { Ball = newBall });
      }
    }

    #endregion ModelAbstractApi

    #region API

    public event EventHandler<BallChaneEventArgs> BallChanged;

    #endregion API

    #region private

    private IObservable<EventPattern<BallChaneEventArgs>> eventObservable = null;
    private List<IDisposable> Balls2Dispose = new List<IDisposable>();

    #endregion private
  }
}