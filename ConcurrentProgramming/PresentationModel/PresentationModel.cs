//__________________________________________________________________________________________
//
//  Copyright 2022 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

using System;
using System.Collections.Generic;

namespace TP.ConcurrentProgramming.PresentationModel
{
  /// <summary>
  /// Class PresentationModel - implements the <see cref="ModelAbstractApi" />
  /// </summary>
  internal class PresentationModel : ModelAbstractApi
  {
    #region ModelAbstractApi

    public override void Dispose()
    {
      foreach (ModelBall item in Balls2Dispose)
        item.Dispose();
    }

    public override IDisposable Subscribe(IObserver<IBall> observer)
    {
      throw new NotImplementedException();
    }

    public override event EventHandler<BallChaneEventArgs> BallChanged;

    #endregion ModelAbstractApi

    #region API

    internal void CraeteBalls()
    {
      Random random = new Random();
      int ballNumber = random.Next(1, 10);
      for (int i = 0; i < ballNumber; i++)
      {
        ModelBall newBall = new ModelBall(random.Next(100, 400 - 100), random.Next(100, 400 - 100)) { Diameter = 20 };
        Balls2Dispose.Add(newBall);
        BallChanged?.Invoke(this, new BallChaneEventArgs() { Ball = newBall });
      }
    }

    #endregion API

    #region private

    private List<ModelBall> Balls2Dispose = new List<ModelBall>();

    #endregion private
  }
}