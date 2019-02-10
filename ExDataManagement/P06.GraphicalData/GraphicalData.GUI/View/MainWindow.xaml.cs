//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System;
using System.Windows;
using TP.GraphicalData.ViewModel;

namespace TP.GraphicalData.View
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }
    protected override void OnInitialized(EventArgs e)
    {
      base.OnInitialized(e);
      MainViewModel _vm = (MainViewModel)DataContext;
      _vm.ChildWindow = new Lazy<Window>(() => new TreeViewMainWindow());
    }
  }
}
