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
using TP.GraphicalData.ViewModel.MVVMLight;

namespace TP.GraphicalData.ViewModel
{
  /// <summary>
  /// An instance of this class is used as the data context to provide a ViewModel sublayer for a Window rendered by the View sublayer.
  /// </summary>
  public class TreeViewModelItem : ViewModelBase
  {
    #region View Model API

    public string Name { get; set; }
    public ObservableCollection<TreeViewModelItem> Children { get; } = new ObservableCollection<TreeViewModelItem>() { null };

    public bool TreeViewItemIsExpanded
    {
      get => m_IsExpanded;
      set
      {
        m_IsExpanded = value;
        if (m_WasBuilt)
          return;
        Children.Clear();
        BuildMyself();
        m_WasBuilt = true;
        RaisePropertyChanged();
      }
    }

    #endregion View Model API

    #region private

    private bool m_WasBuilt = false;
    private bool m_IsExpanded = false;
    private static Random m_Random = new Random();

    private void BuildMyself()
    {
      int _numberOfChildren = Math.Max(1, m_Random.Next(7));
      for (int i = 0; i < _numberOfChildren; i++)
        this.Children.Add(new TreeViewModelItem() { Name = $"sample{i}" });
    }

    #endregion private
  }
}