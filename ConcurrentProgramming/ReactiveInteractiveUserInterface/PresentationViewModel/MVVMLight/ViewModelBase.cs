//__________________________________________________________________________________________
//
//  Copyright 2024 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//__________________________________________________________________________________________

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TP.ConcurrentProgramming.Presentation.ViewModel.MVVMLight
{
  public class ViewModelBase : INotifyPropertyChanged
  {
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
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion API
  }
}