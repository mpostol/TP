//__________________________________________________________________________________________
//
//  Copyright 2022 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

using System.Collections.Generic;
using System.Windows.Input;
using TP.ConcurrentProgramming.PresentationModel;
using TP.ConcurrentProgramming.PresentationViewModel.MVVMLight;

namespace TP.ConcurrentProgramming.PresentationViewModel
{
  public class MainWindowViewModel : ViewModelBase

  {
    #region public API

    public MainWindowViewModel() : this(ModelAbstractApi.CreateApi())
    {
    }

    public MainWindowViewModel(ModelAbstractApi modelAbstractApi)
    {
      ModelLayer = modelAbstractApi;
      Radious = ModelLayer.Radius;
      ButtomClick = new RelayCommand(() => ClickHandler());
    }

    public IList<object> CirclesCollection
    {
      get
      {
        return b_CirclesCollection;
      }
      set
      {
        if (value.Equals(b_CirclesCollection))
          return;
        RaisePropertyChanged("CirclesCollection");
      }
    }

    public int Radious
    {
      get
      {
        return b_Radious;
      }
      set
      {
        if (value.Equals(b_Radious))
          return;
        b_Radious = value;
        RaisePropertyChanged("Radious");
      }
    }

    public ICommand ButtomClick { get; set; }

    private void ClickHandler()
    {
      // do something usefull
    }

    #endregion public API

    #region private

    private IList<object> b_CirclesCollection;
    private int b_Radious;
    private ModelAbstractApi ModelLayer = ModelAbstractApi.CreateApi();

    #endregion private

  }
}