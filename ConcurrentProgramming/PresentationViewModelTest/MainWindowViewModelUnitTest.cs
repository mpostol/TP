//__________________________________________________________________________________________
//
//  Copyright 2024 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//__________________________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reactive;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using TP.ConcurrentProgramming.PresentationModel;
using TP.ConcurrentProgramming.PresentationViewModel;

namespace PresentationViewModelTest
{
  [TestClass]
  public class MainWindowViewModelUnitTest
  {
    [TestMethod]
    public void ConstructorTest()
    {
      ModelNullFixture nullModelFixture = new ModelNullFixture();
      Assert.AreEqual<int>(0, nullModelFixture.Disposed);
      Assert.AreEqual<int>(0, nullModelFixture.Started);
      Assert.AreEqual<int>(0, nullModelFixture.Subscribed);
      MainWindowViewModel viewModel = new MainWindowViewModel(nullModelFixture);
      Assert.IsNotNull(viewModel.Balls);
      Assert.AreEqual<int>(0, nullModelFixture.Disposed);
      Assert.AreEqual<int>(1, nullModelFixture.Started);
      Assert.AreEqual<int>(1, nullModelFixture.Subscribed);
      viewModel.Dispose();
      Assert.AreEqual<int>(1, nullModelFixture.Disposed);
    }

    private class ModelNullFixture : ModelAbstractApi
    {
      #region Test

      internal int Disposed = 0;
      internal int Started = 0;
      internal int Subscribed = 0;

      #endregion Test

      #region ModelAbstractApi

      public override void Dispose()
      {
        Disposed++;
      }

      public override void Start()
      {
        this.Started++;
      }

      public override IDisposable Subscribe(IObserver<IBall> observer)
      {
        Subscribed++;
        return new NullDisposable();
      }

      #endregion ModelAbstractApi

      #region private

      private class NullDisposable : IDisposable
      {
        public void Dispose()
        {
          throw new NotImplementedException();
        }
      }

      #endregion private
    }

    //TODO CP Improve Architecture Structure of Reference Program #419 - improve the testing method
    [TestMethod]
    public void BehaviorTestMethod()
    {
      MainWindowViewModel window = new MainWindowViewModel(new ModelFixture());
      Assert.Inconclusive("TBDO");
      window.PropertyChanged += (sender, e) => Window_BallChanged(sender, e);
      Assert.IsNotNull(window.Balls);
    }

    private void Window_BallChanged(object? sender, PropertyChangedEventArgs e)
    {
      throw new NotImplementedException();
    }

    private class ModelFixture : ModelAbstractApi
    {
      public ModelFixture()
      {
        eventObservable = Observable.FromEventPattern<BallChaneEventArgs>(this, "BallChanged");
      }

      #region ModelAbstractApi

      public override void Dispose()
      {
        foreach (ModelBall item in Balls2Dispose)
          item.Dispose();
      }

      public override IDisposable? Subscribe(IObserver<IBall> observer)
      {
        return eventObservable?.Subscribe(x => observer.OnNext(x.EventArgs.Ball), ex => observer.OnError(ex), () => observer.OnCompleted());
      }

      public override void Start()
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

      #endregion ModelAbstractApi

      #region API

      public event EventHandler<BallChaneEventArgs> BallChanged;

      #endregion API

      #region private

      private IObservable<EventPattern<BallChaneEventArgs>>? eventObservable = null;
      private List<IDisposable> Balls2Dispose = new List<IDisposable>();

      #endregion private
    }

    private class BallChaneEventArgs : EventArgs
    {
      public IBall Ball { get; internal set; }
    }

    private class ModelBall : IBall, IDisposable
    {
      public ModelBall(double top, double left)
      {
        TopBackingField = top;
        LeftBackingField = left;
        MoveTimer = new Timer(Move, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(100));
      }

      #region IBall

      public double Top
      {
        get { return TopBackingField; }
        private set
        {
          if (TopBackingField == value)
            return;
          TopBackingField = value;
          RaisePropertyChanged();
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
          RaisePropertyChanged();
        }
      }

      public double Diameter { get; internal set; }

      #region INotifyPropertyChanged

      public event PropertyChangedEventHandler? PropertyChanged;

      #endregion INotifyPropertyChanged

      #endregion IBall

      #region IDisposable

      public void Dispose()
      {
        MoveTimer.Dispose();
      }

      #endregion IDisposable

      #region private

      private double TopBackingField;
      private double LeftBackingField;
      private Timer MoveTimer;
      private Random Random = new Random();

      private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
      {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }

      private void Move(object? state)
      {
        if (state != null)
          throw new ArgumentOutOfRangeException(nameof(state));
        Top = Top + (Random.NextDouble() - 0.5) * 10;
        Left = Left + (Random.NextDouble() - 0.5) * 10;
      }

      #endregion private
    }
  }
}