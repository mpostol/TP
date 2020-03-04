//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ComponentModel;
using TP.GraphicalData.ViewModel.MVVMLight;

namespace TP.GraphicalData
{
  [TestClass]
  public class MVVMLightUnitTest
  {

    [TestMethod]
    public void RelayCommandTest()
    {
      int _executeCount = 0;
      RelayCommand _testCommand = new RelayCommand(() => _executeCount++);
      Assert.IsTrue(_testCommand.CanExecute(null));
      int _CanExecuteChangedCount = 0;
      _testCommand.CanExecuteChanged += (object sender, EventArgs e) => _CanExecuteChangedCount++;
      _testCommand.Execute(null);
      Assert.AreEqual<int>(1, _executeCount);
      Assert.AreEqual<int>(0, _CanExecuteChangedCount);
    }
    [TestMethod]
    public void RelayCommandCanExecuteTest()
    {
      int _ExecuteCount = 0;
      bool _CanExecute = true;
      int _CanExecuteChangedCount = 0;
      RelayCommand _testCommand = new RelayCommand(() => _ExecuteCount++, () => _CanExecute);
      _testCommand.CanExecuteChanged += (object sender, EventArgs e) => _CanExecuteChangedCount++;
      Assert.IsTrue(_testCommand.CanExecute(null));
      _testCommand.Execute(null);
      _CanExecute = false;
      Assert.IsFalse(_testCommand.CanExecute(null));
      _testCommand.Execute(null);
      Assert.AreEqual<int>(2, _ExecuteCount);
      Assert.AreEqual<int>(0, _CanExecuteChangedCount);
    }
    [TestMethod]
    public void ViewModelBaseTest()
    {
      ViewModelBaseFixture _toTest = new ViewModelBaseFixture();
      int _PropertyChangedCount = 0;
      string _lastPropertyName = String.Empty;
      _toTest.PropertyChanged += (object sender, PropertyChangedEventArgs e) => { _PropertyChangedCount++; _lastPropertyName = e.PropertyName; };
      _toTest.TestRaisePropertyChanged("PropertyName");
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
