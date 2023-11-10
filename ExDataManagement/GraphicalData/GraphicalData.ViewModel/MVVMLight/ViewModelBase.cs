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

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TP.GraphicalData.ViewModel.MVVMLight
{
  /// <summary>
  /// Notifies clients that a property value has changed.
  /// </summary>
  public class ViewModelBase : INotifyPropertyChanged
  {
    #region INotifyPropertyChanged

    /// <summary>
    /// Occurs when a property value changes.
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged;

    #endregion INotifyPropertyChanged

    #region API

    /// <summary>
    /// Raises the PropertyChanged event if needed.
    /// </summary>
    /// <param name="propertyName">(optional) The name of the property that changed.
    /// The <see cref="CallerMemberName"/> allows you to obtain the method or property name of the caller to the method.
    /// </param>
    protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion API
  }
}