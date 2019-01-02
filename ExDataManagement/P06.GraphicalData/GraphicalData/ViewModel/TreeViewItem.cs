//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System;
using System.Collections.ObjectModel;
using TP.GraphicalData.ViewModel.MVVMLight;

namespace TP.GraphicalData.ViewModel
{
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
    #endregion

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
    #endregion

  }
}

