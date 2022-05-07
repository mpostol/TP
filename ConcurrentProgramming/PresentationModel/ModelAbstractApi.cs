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
using System.ComponentModel;

namespace TP.ConcurrentProgramming.PresentationModel
{
  public interface IBall : INotifyPropertyChanged
  {
    double Top { get; }
    double Left { get; }
    double Diameter { get; }
  }

  public class BallChaneEventArgs : EventArgs
  {
    public IBall Ball { get; set; }
  }

  public interface INotifyBallChanged
  {
    //     Occurs when a property value changes.
    /// <summary>
    /// Occurs when a ball value changes..
    /// </summary>
    event EventHandler<BallChaneEventArgs> BallChanged;
  }

  public abstract class ModelAbstractApi : IObservable<IBall>, INotifyBallChanged, IDisposable
  {
    public abstract event EventHandler<BallChaneEventArgs> BallChanged;

    public abstract IDisposable Subscribe(IObserver<IBall> observer);

    public static ModelAbstractApi CreateApi(EventHandler<BallChaneEventArgs> eventHandler)
    {
      PresentationModel model = new PresentationModel();
      model.BallChanged += eventHandler;
      model.CraeteBalls();
      return model;
    }

    public abstract void Dispose();
  }
}