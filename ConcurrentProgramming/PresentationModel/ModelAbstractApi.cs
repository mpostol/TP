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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace TP.ConcurrentProgramming.PresentationModel
{
  public abstract class ModelAbstractApi : IObservable<IBall>, INotifyBallChanged, IDisposable
  {
    public abstract event EventHandler<BallChaneEventArgs> BallChanged;

    public static ModelAbstractApi CreateApi(EventHandler<BallChaneEventArgs> eventHandler)
    {
      PresentationModelApi model = new PresentationModelApi();
      model.BallChanged += eventHandler;
      model.CraeteBalls();
      return model;
    }

    public abstract void Dispose();

    public IDisposable Subscribe(IObserver<IBall> observer)
    {
      throw new NotImplementedException();
    }
  }

  internal class PresentationModelApi : ModelAbstractApi
  {
    internal void CraeteBalls()
    {
      Random random = new Random();
      int ballNumber = random.Next(1, 10);
      for (int i = 0; i < ballNumber; i++)
      {
        BallFixture newBall = new BallFixture(random.Next(10, 400 - 10), random.Next(10, 400 - 10)) { Diameter = 20 };
        Balls2Dispose.Add(newBall);
        BallChanged?.Invoke(this, new BallChaneEventArgs() { Ball = newBall });
      }
    }

    public override void Dispose()
    {
      foreach (BallFixture item in Balls2Dispose)
        item.Dispose();
    }

    public override event EventHandler<BallChaneEventArgs> BallChanged;

    private List<BallFixture> Balls2Dispose = new List<BallFixture>();

    private class BallFixture : IBall, IDisposable
    {
      private double TopBackingField;

      private double LeftBackingField;

      public BallFixture(double top, double left)
      {
        TopBackingField = top;
        LeftBackingField = left;
        MoveTimer = new Timer(Move, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(200));
      }

      public double Top
      {
        get { return TopBackingField; }
        private set
        {
          if (TopBackingField == value)
            return;
          TopBackingField = value;
          NotifyPropertyChanged();
        }
      }

      public double Left
      {
        get { return LeftBackingField; }
        private set
        {
          if (LeftBackingField == value)
            return;
          LeftBackingField = value;
          NotifyPropertyChanged();
        }
      }

      public int Index { get; set; } = -1;

      public double Diameter { get; internal set; }

      public event PropertyChangedEventHandler PropertyChanged;

      private Timer MoveTimer;

      private Random Random = new Random();

      private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")

      {
        if (PropertyChanged != null)
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }

      private void Move(object state)
      {
        if (state != null)
          throw new ArgumentOutOfRangeException(nameof(state));
        Top = Top + (Random.NextDouble() - 0.5) * 10;
        Left = Left + (Random.NextDouble() - 0.5) * 10;
      }

      public void Dispose()
      {
        MoveTimer.Dispose();
      }
    }
  }
}