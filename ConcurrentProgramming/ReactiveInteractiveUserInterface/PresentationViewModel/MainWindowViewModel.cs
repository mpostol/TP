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
using TP.ConcurrentProgramming.Presentation.Model;
using TP.ConcurrentProgramming.PresentationViewModel.MVVMLight;

namespace TP.ConcurrentProgramming.PresentationViewModel
{
  public class MainWindowViewModel : ViewModelBase, IDisposable
  {
    #region public API

    public MainWindowViewModel() : this(null)
    { }

    public MainWindowViewModel(ModelAbstractApi modelLayerAPI)
    {
      ModelLayer = modelLayerAPI == null ? ModelAbstractApi.CreateModel() : modelLayerAPI;
      Observer = ModelLayer.Subscribe<IBall>(x => Balls.Add(x));
    }

    public void Start(int numberOfBalls)
    {
      ModelLayer.Start(numberOfBalls);
    }

    public ObservableCollection<IBall> Balls { get; } = new ObservableCollection<IBall>();

    #endregion public API

    #region IDisposable

    protected virtual void Dispose(bool disposing)
    {
      if (!disposedValue)
      {
        if (disposing)
        {
          Balls.Clear();
          Observer.Dispose();
          ModelLayer.Dispose();
        }

        // TODO: free unmanaged resources (unmanaged objects) and override finalizer
        // TODO: set large fields to null
        disposedValue = true;
      }
    }

    public void Dispose()
    {
      // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
      Dispose(disposing: true);
      GC.SuppressFinalize(this);
    }

    #endregion IDisposable

    #region private

    private IDisposable Observer = null;
    private ModelAbstractApi ModelLayer;
    private bool disposedValue;

    #endregion private
  }
}