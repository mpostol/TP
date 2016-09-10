
using System;
using System.Windows.Input;

namespace TP.Lecture.TreeViewExample
{
  /// <summary>
  /// Class DelegateCommand implements 
  /// </summary>
  /// <seealso cref="System.Windows.Input.ICommand" />
  public class DelegateCommand : ICommand
  {
    private readonly Action _action;

    public DelegateCommand(Action action)
    {
      _action = action;
    }
    public void Execute(object parameter)
    {
      _action();
    }
    public bool CanExecute(object parameter)
    {
      return true;
    }
    public event EventHandler CanExecuteChanged;
  }
}
