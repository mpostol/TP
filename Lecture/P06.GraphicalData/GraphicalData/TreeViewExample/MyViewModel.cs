using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace TP.Lecture.TreeViewExample
{
  /// <summary>
  /// Class MyViewModel - ViewModel implementation 
  /// </summary>
  /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
  public class MyViewModel : INotifyPropertyChanged
  {
    #region constructors
    public MyViewModel()
    {
      HierarchicalAreas = new ObservableCollection<ITreeViewItem>();
      Click_Button = new DelegateCommand(LoadDLL);
      Click_Browse = new DelegateCommand(Browse);
    }
    #endregion

    #region DataContext
    public ObservableCollection<ITreeViewItem> HierarchicalAreas { get; set; }
    public string PathVariable
    {
      get { return pathVariable; }
      set { pathVariable = value; }
    }
    public Visibility ChangeControlVisibility
    {
      get { return _visibility; }
      set
      {
        _visibility = value;
      }
    }
    public ICommand Click_Browse { get; }
    public ICommand Click_Button { get; }
    #endregion

    #region INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;
    private void RaisePropertyChanged(string propertyName_)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName_));
    }
    #endregion

    #region private
    private string pathVariable;
    private Visibility _visibility = Visibility.Hidden;
    private void LoadDLL()
    {
      if (pathVariable.Substring(pathVariable.Length - 4) == ".dll")
        TreeViewLoaded();
    }
    private void TreeViewLoaded()
    {
      ITreeViewItem rootItem = new ITreeViewItem { Name = pathVariable.Substring(pathVariable.LastIndexOf('\\') + 1) };
      HierarchicalAreas.Add(rootItem);
    }
    private void Browse()
    {
      OpenFileDialog test = new OpenFileDialog();
      test.Filter = "Dynamic Library File(*.dll)| *.dll";
      test.ShowDialog();
      if (test.FileName.Length == 0)
      {
        MessageBox.Show("No files selected");
      }
      else
      {
        pathVariable = test.FileName;
        _visibility = Visibility.Visible;
        RaisePropertyChanged("ChangeControlVisibility");
        RaisePropertyChanged("PathVariable");
      }
    }
    #endregion

  }
}
