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

namespace TP.GraphicalData.ViewModel
{
  /// <summary>
  /// Class derived from <see cref="TreeViewModelItem"/> to provide root item for the tree
  /// </summary>
  public class RootTreeViewItem : TreeViewModelItem
  {
    /// <summary>
    /// Creates and instance of <seealso cref="TreeViewModelItem"/> with the hard-coded name "Root"
    /// </summary>
    public RootTreeViewItem()
    {
      Name = "Root";
    }
  }
}