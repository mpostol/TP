//__________________________________________________________________________________________
//
//  Copyright 2022 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

using System.Collections.ObjectModel;
using TP.ConcurrentProgramming.PresentationModel;
using TP.ConcurrentProgramming.PresentationViewModel.MVVMLight;

namespace TP.ConcurrentProgramming.PresentationViewModel
{
  public class MainWindowViewModel : ViewModelBase

  {
    #region public API

    public MainWindowViewModel()
    {
      ModelLayer = ModelAbstractApi.CreateApi(BallChaneEventHandler);
    }

    public ObservableCollection<IBall> Balls { get; } = new ObservableCollection<IBall>();

    public int Diameter
    {
      get
      {
        return b_Diameter;
      }
      set
      {
        if (value.Equals(b_Diameter))
          return;
        b_Diameter = value;
        RaisePropertyChanged("Radious");
      }
    }

    #endregion public API

    #region private

    private int b_Diameter = 20;
    private ModelAbstractApi ModelLayer;

    private void BallChaneEventHandler(object sender, BallChaneEventArgs e)
    {
      if (e.Ball.Index == -1)
      {
        e.Ball.Index = Balls.Count;
        Balls.Add(e.Ball);
      }
      else
        Balls[e.Ball.Index] = e.Ball;
    }

    #endregion private
  }
}