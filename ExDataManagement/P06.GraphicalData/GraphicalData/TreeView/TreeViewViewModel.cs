//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System.Collections.ObjectModel;
using System.Windows.Input;
using TP.GraphicalData.MVVMLight;

namespace TP.GraphicalData.TreeView
{
  /// <summary>
  /// Class MyViewModel - ViewModel implementation 
  /// </summary>
  /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
  public class TreeViewViewModel : ViewModelBase
  {

    #region constructors
    public TreeViewViewModel()
    {
      Click_Button = new RelayCommand(AddRoot, () => true);
      Click_Browse = new RelayCommand(Browse);
    }
    #endregion

    #region DataContext
    public ObservableCollection<TreeViewModelItem> HierarchicalAreas { get; set; } = new ObservableCollection<TreeViewModelItem>();
    public string PathVariable { get; set; }
    public ICommand Click_Browse { get; }
    public ICommand Click_Button { get; }
    #endregion

    #region private
    private void AddRoot()
    {
      TreeViewModelItem _rootItem = new RootTreeViewItem();
      HierarchicalAreas.Add(_rootItem);
    }
    private void Browse() { }
    #endregion

  }
}
