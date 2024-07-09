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
using TP.GraphicalData.ViewModel.MVVMLight;

namespace TP.GraphicalData.ViewModel.Test
{
  [TestClass]
  public class MVVMLightUnitTest
  {
    [TestMethod]
    public void RelayCommandTest()
    {
      int executeCount = 0;
      RelayCommand _testCommand = new RelayCommand(() => executeCount++);
      Assert.IsTrue(_testCommand.CanExecute(null));
      int _CanExecuteChangedCount = 0;
      _testCommand.CanExecuteChanged += (object sender, EventArgs e) => _CanExecuteChangedCount++;
      _testCommand.Execute(null);
      Assert.AreEqual<int>(1, executeCount);
      Assert.AreEqual<int>(0, _CanExecuteChangedCount);
    }

    [TestMethod]
    public void RelayCommandCanExecuteTest()
    {
      int executeCount = 0;
      bool canExecute = true;
      int canExecuteChangedCount = 0;
      RelayCommand testCommand = new RelayCommand(() => executeCount++, () => canExecute);
      testCommand.CanExecuteChanged += (object sender, EventArgs e) => canExecuteChangedCount++;
      Assert.IsTrue(testCommand.CanExecute(null));
      testCommand.Execute(null);
      canExecute = false;
      Assert.IsFalse(testCommand.CanExecute(null));
      testCommand.Execute(null);
      Assert.AreEqual<int>(2, executeCount);
      Assert.AreEqual<int>(0, canExecuteChangedCount);
    }

    [TestMethod]
    public void ViewModelBaseTest()
    {
      ViewModelBaseFixture toTest = new ViewModelBaseFixture();
      int _PropertyChangedCount = 0;
      string _lastPropertyName = String.Empty;
      toTest.PropertyChanged += (object sender, PropertyChangedEventArgs e) => { _PropertyChangedCount++; _lastPropertyName = e.PropertyName; };
      toTest.TestRaisePropertyChanged("PropertyName");
      Assert.AreEqual<string>("PropertyName", _lastPropertyName);
      Assert.AreEqual<int>(1, _PropertyChangedCount);
    }

    private class ViewModelBaseFixture : ViewModelBase
    {
      internal void TestRaisePropertyChanged(string propertyName)
      {
        base.RaisePropertyChanged(propertyName);
      }
    }
  }
}