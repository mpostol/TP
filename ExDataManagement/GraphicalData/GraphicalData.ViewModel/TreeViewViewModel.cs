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

using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TP.GraphicalData.ViewModel.MVVMLight;

namespace TP.GraphicalData.ViewModel
{
  /// <summary>
  /// An implementation of the <seealso cref="ViewModelBase"/> to be used as a sublayer for the tree view window rendered by the View sublayer
  /// </summary>
  /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
  public class TreeViewViewModel : ViewModelBase
  {
    #region constructors

    /// <summary>
    /// Creates an instance of the <see cref="TreeViewViewModel"/>
    /// </summary>
    public TreeViewViewModel()
    {
      ShowTreeViewCommand = new RelayCommand(AddRoot, () => !string.IsNullOrEmpty(PathVariable));
      BrowseCommand = new RelayCommand(Browse);
    }

    #endregion constructors

    #region View Model API

    public ObservableCollection<TreeViewModelItem> HierarchicalAreas { get; set; } = new ObservableCollection<TreeViewModelItem>();

    public string PathVariable
    {
      get => m_PathVariable;
      set
      {
        m_PathVariable = value;
        ShowTreeViewCommand.RaiseCanExecuteChanged();
        RaisePropertyChanged();
      }
    }

    public ICommand BrowseCommand { get; }
    public RelayCommand ShowTreeViewCommand { get; }

    #endregion View Model API

    #region private

    private string m_PathVariable = string.Empty;
    private Func<string> GetPath { set; get; } = () => "Result of the FileOpenDialog";

    private void AddRoot()
    {
      TreeViewModelItem rootItem = new RootTreeViewItem();
      HierarchicalAreas.Add(rootItem);
    }

    private void Browse()
    {
      PathVariable = GetPath();
    }

    #endregion private
  }
}