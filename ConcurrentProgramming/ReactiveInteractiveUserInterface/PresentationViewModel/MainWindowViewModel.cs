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
using TP.ConcurrentProgramming.PresentationModel;

namespace TP.ConcurrentProgramming.PresentationViewModel
{
  public class MainWindowViewModel : INotifyPropertyChanged
  {
    public MainWindowViewModel()
    {
      ModelLayer = ModelAbstractApi.CreateApi();
      Radious = ModelLayer.Radius;
    }

    private IList<object> b_CirclesCollection;

    public IList<object> CirclesCollection
    {
      get
      {
        return b_CirclesCollection;
      }
      set
      {
        RaiseHandler<IList<object>>(value, ref b_CirclesCollection, "CirclesCollection", this);
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
        RaiseHandler<int>(value, ref b_Radious, "Radious", this);
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    /// Helper method that sets a new value in a variable and then executes the event handler if the new value
    /// differs from the old one. Used to easily implement INotifyPropeprtyChanged.
    /// </summary>
    /// <typeparam name="T">The type of values being handled (usually the type of the property).</typeparam>
    /// <param name="newValue">The new value to set.</param>
    /// <param name="oldValue">The old value to replace (and the value holder).</param>
    /// <param name="propertyName">The property's name as required by <typeparamref name="System.ComponentModel.PropertyChangedEventArgs"/>.</param>
    /// <param name="sender">The object to be appointed as the executioner of the handler.</param>
    /// <returns>A boolean value that indicates if the new value was truly different from the old value according to <code>object.Equals()</code>.</returns>
    private bool RaiseHandler<T>(T newValue, ref T oldValue, string propertyName, object sender)
    {
      bool changed = !Object.Equals(oldValue, newValue);
      if (changed)
      {
        //Save the new value.
        oldValue = newValue;
        //Raise the event
        PropertyChanged?.Invoke(sender, new PropertyChangedEventArgs(propertyName));
      }
      //Signal what happened.
      return changed;
    }

    private int b_Radious;
    private ModelAbstractApi ModelLayer = ModelAbstractApi.CreateApi();
  }
}