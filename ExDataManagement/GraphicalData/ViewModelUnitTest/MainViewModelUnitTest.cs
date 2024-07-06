//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2024, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//  by introducing yourself and telling us what you do with this community.
//_____________________________________________________________________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ComponentModel;
using TP.GraphicalData.ViewMode.Test.Instrumentation;

namespace TP.GraphicalData.ViewModel.Test
{
  /// <summary>
  /// The <seealso cref="MainViewModel"/> class unit test
  /// </summary>
  [TestClass]
  public class MainViewModelUnitTest
  {
    [TestMethod]
    public void CreatorTestMethod()
    {
      MainViewModel _vm = new MainViewModel(new ModelImplementation4Testing());
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
      MainViewModel _vm = new MainViewModel(new ModelImplementation4Testing());
      int _boxShowCount = 0;
      _vm.MessageBoxShowDelegate = (messageBoxText) =>
      {
        _boxShowCount++;
        Assert.AreEqual<string>("ActionText", messageBoxText);
      };
      _vm.ActionText = "ActionText";
      Assert.IsTrue(_vm.DisplayTextCommand.CanExecute(null));
      _vm.DisplayTextCommand.Execute(null);
      Assert.AreEqual<int>(1, _boxShowCount);
    }

    [TestMethod]
    public void ActionTextTestMethod()
    {
      MainViewModel _vm = new MainViewModel(new ModelImplementation4Testing());
      Assert.IsTrue(_vm.DisplayTextCommand.CanExecute(null));
      _vm.ActionText = String.Empty;
      Assert.IsFalse(_vm.DisplayTextCommand.CanExecute(null));
    }

    [TestMethod]
    public void MyTestMethod()
    {
      Object DataContext = new MainViewModel(new ModelImplementation4Testing());
      Assert.IsInstanceOfType(DataContext, typeof(INotifyPropertyChanged));
      int executionCount = 0;
      ((INotifyPropertyChanged)DataContext).PropertyChanged += (x, y) => { Assert.AreEqual<string>("ActionText", y.PropertyName); executionCount++; };
      ((MainViewModel)DataContext).ActionText = "dsdafafafdfsfs";
      Assert.AreEqual<int>(1, executionCount);
    }
  }
}