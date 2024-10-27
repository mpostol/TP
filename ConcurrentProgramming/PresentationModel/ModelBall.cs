//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2023, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//  by introducing yourself and telling us what you do with this community.
//_____________________________________________________________________________________________________________________________________

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace TP.ConcurrentProgramming.Presentation.Model
{
  internal class ModelBall : IBall, IDisposable
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

    public event PropertyChangedEventHandler PropertyChanged;

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

    private void Move(object state)
    {
      if (state != null)
        throw new ArgumentOutOfRangeException(nameof(state));
      Top = Top + (Random.NextDouble() - 0.5) * 10;
      Left = Left + (Random.NextDouble() - 0.5) * 10;
    }

    #endregion private
  }
}