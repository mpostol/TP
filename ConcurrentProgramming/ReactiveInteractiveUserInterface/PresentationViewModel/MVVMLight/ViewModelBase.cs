//__________________________________________________________________________________________
//
//  Copyright 2022 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

using System.ComponentModel;
using System.Runtime.CompilerServices;
using TP.ConcurrentProgramming.PresentationModel;

namespace TP.ConcurrentProgramming.PresentationViewModel.MVVMLight
{
  public class ViewModelBase : INotifyPropertyChanged
  {
    private ModelAbstractApi modelAbstractApi;

    #region INotifyPropertyChanged

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
      this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion API
  }
}