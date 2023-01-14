//__________________________________________________________________________________________
//
//  Copyright 2023 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

using System.Windows;
using System.Windows.Controls;

namespace TP.InformationComputation.PartialDefinitions
{
  /// <summary>
  /// Interaction logic for UserControl.xaml
  /// </summary>
  public partial class CustomControl : UserControl
  {
    public CustomControl()
    {
      InitializeComponent();
    }

    private void BrowseClickHandler(object sender, RoutedEventArgs e)
    {
      //Handle the Click Event  of the "Browse" Button
    }

    private void ShowTreeViewHandler (object sender, RoutedEventArgs e)
    {
      //Handle the Click Event of the "Show TreeView" Button
    }
  }
}