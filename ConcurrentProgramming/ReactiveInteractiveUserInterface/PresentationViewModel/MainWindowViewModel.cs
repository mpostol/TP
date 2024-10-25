//__________________________________________________________________________________________
//
//  Copyright 2024 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//__________________________________________________________________________________________

using System;
using System.Collections.ObjectModel;
using TP.ConcurrentProgramming.PresentationModel;
using TP.ConcurrentProgramming.PresentationViewModel.MVVMLight;

namespace TP.ConcurrentProgramming.PresentationViewModel
{
  public class MainWindowViewModel : ViewModelBase, IDisposable
  {
    #region public API

    public MainWindowViewModel() : this(null)
    {
    }

    public MainWindowViewModel(ModelAbstractApi modelLayerAPI)
    {
      //TODO CP - use singleton design pattern to implement ModelAbstractApi factoring #314
      ModelLayer = modelLayerAPI == null ? ModelAbstractApi.CreateApi() : modelLayerAPI;
      IDisposable observer = ModelLayer.Subscribe<IBall>(x => Balls.Add(x));
      ModelLayer.Start();
    }

    public ObservableCollection<IBall> Balls { get; } = new ObservableCollection<IBall>();

    #endregion public API

    #region IDisposable

    public void Dispose()
    {
      ModelLayer.Dispose();
    }

    #endregion IDisposable

    #region private

    private ModelAbstractApi ModelLayer;

    #endregion private
  }
}