//____________________________________________________________________________
//
//  Copyright (C) 2019, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows;
using TP.GraphicalData.Model;
using TP.GraphicalData.ViewModel;

namespace TP.GraphicalData
{
  [TestClass]
  public class MainViewModelUnitTest
  {
    [TestMethod]
    public void CreatorTestMethod()
    {
      MainViewModel _vm = new MainViewModel();
      Assert.IsFalse(String.IsNullOrEmpty(_vm.ActionText));
      Assert.IsNotNull(_vm.MessageBoxShowDelegate);
      Assert.IsNotNull(_vm.DisplayTextCommand);
      Assert.IsNull(_vm.Users);
      Assert.IsNull(_vm.CurrentUser);
      Assert.IsTrue(_vm.DisplayTextCommand.CanExecute(null));
    }
    [TestMethod]
    public void MyCommandTest()
    {
      MainViewModel _vm = new MainViewModel();
      int _boxShowCount = 0;
      _vm.MessageBoxShowDelegate = (messageBoxText, caption, button, icon) =>
      {
        _boxShowCount++;
        Assert.AreEqual < string>("ActionText", messageBoxText);
        Assert.AreEqual<string>("Button interaction", caption);
        Assert.AreEqual<MessageBoxButton>(MessageBoxButton.OK, button);
        Assert.AreEqual<MessageBoxImage>(MessageBoxImage.Information, icon);
        return System.Windows.MessageBoxResult.OK;
      };
      _vm.ActionText = "ActionText";
      Assert.IsTrue(_vm.DisplayTextCommand.CanExecute(null));
      _vm.DisplayTextCommand.Execute(null);
      Assert.AreEqual<int>(1, _boxShowCount);
    }
    [TestMethod]
    public void ActionTextTestMethod()
    {
      MainViewModel _vm = new MainViewModel();
      Assert.IsTrue(_vm.DisplayTextCommand.CanExecute(null));
      _vm.ActionText = String.Empty;
      Assert.IsFalse(_vm.DisplayTextCommand.CanExecute(null));
    }
    [TestMethod]
    public void DataLayerTestMethod()
    {
      DataLayer _dl = new DataLayer();
      MainViewModel _vm = new MainViewModel();
      Assert.IsNull(_vm.DataLayer);
      _vm.FetchDataCommend.Execute(null);
      Assert.IsNotNull(_vm.DataLayer);
      Assert.AreNotSame(_vm.DataLayer, _dl);
      _vm.DataLayer = _dl;
      Assert.AreSame(_vm.DataLayer, _dl);
    }
  }
}
