//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2024, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//_____________________________________________________________________________________________________________________________________

using System;
using System.Windows.Input;

namespace TP.ConcurrentProgramming.Presentation.ViewModel.MVVMLight
{
  /// <summary>
  /// A generic command whose sole purpose is to relay its functionality to other
  /// objects by invoking delegates. The default return value for the CanExecute
  /// method is 'true'. This class allows you to accept command parameters in the
  /// Execute and CanExecute callback methods.
  /// </summary>
  /// <remarks>The <see cref="CommandManager"/>handles automatic enabling/disabling of controls based on the CanExecute delegate.</remarks>
  public class RelayCommand : ICommand
  {
    #region constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="RelayCommand"/>  class that can always execute.
    /// </summary>
    /// <param name="execute">The execution logic encapsulated by the <paramref name="execute"/> delegate. </param>
    /// <exception cref="T:System.ArgumentNullException">If the <paramref name="execute"/> argument is null.</exception>
    public RelayCommand(Action execute) : this(execute, null) { }

    /// <summary>
    /// Initializes a new instance of the RelayCommand class.
    /// </summary>
    /// <param name="canExecute">The execution status logic encapsulated by the <paramref name="canExecute"/> delegate.
    /// </param>
    /// <exception cref="T:System.ArgumentNullException">If the execute argument is null.</exception>
    public RelayCommand(Action execute, Func<bool> canExecute)
    {
      this.m_Execute = execute ?? throw new ArgumentNullException(nameof(execute));
      this.m_CanExecute = canExecute;
    }

    #endregion constructors

    #region ICommand

    /// <summary>
    /// Defines the method that determines whether the command can execute in its current state.
    /// </summary>
    /// <param name="parameter">Data used by the command. Because the command does not require data
    /// to be passed, this parameter is always ignored</param>
    /// <returns><c>true</c> if this command can be executed; otherwise, <c>false</c>.</returns>
    public bool CanExecute(object parameter)
    {
      if (this.m_CanExecute == null)
        return true;
      if (parameter == null)
        return this.m_CanExecute();
      return this.m_CanExecute();
    }

    /// <summary>
    /// Defines the method to be called when the command is invoked.
    /// </summary>
    /// <param name="parameter">Data used by the command. Because the command does not require data
    /// to be passed, this parameter is always ignored</param>
    public virtual void Execute(object parameter)
    {
      this.m_Execute();
    }

    /// <summary>
    /// Occurs when changes occur that affect whether the command should execute.
    /// </summary>
    public event EventHandler CanExecuteChanged;

    #endregion ICommand

    #region API

    /// <summary>
    /// Raises the <see cref="CanExecuteChanged" /> event.
    /// </summary>
    internal void RaiseCanExecuteChanged()
    {
      this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }

    #endregion API

    #region private

    private readonly Action m_Execute;
    private readonly Func<bool> m_CanExecute;

    #endregion private
  }
}