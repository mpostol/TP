
using System;
using System.Collections.ObjectModel;

namespace TP.Lecture.TreeViewExample
{
  public class ITreeViewItem
  {
    public ITreeViewItem()
    {
      Children = new ObservableCollection<ITreeViewItem>();
      Children.Add(null);
      this._wasBuilt = false;
    }
    public string Name { get; set; }
    public ObservableCollection<ITreeViewItem> Children { get; set; }
    public bool IsExpanded
    {
      get { return _isExpanded; }
      set
      {
        _isExpanded = value;
        if (_wasBuilt)
          return;
        Children.Clear();
        buildMyself();
        _wasBuilt = true;
      }
    }

    private bool _wasBuilt;
    private bool _isExpanded;
    private void buildMyself()
    {
      Random random = new Random();
      for (int i = 0; i < random.Next(7); i++)
        this.Children.Add(new ITreeViewItem() { Name = "sample" + i });
    }

  }
}

