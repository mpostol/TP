//__________________________________________________________________________________________
//
//  Copyright 2022 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started 
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP.ConcurrentProgramming.PresentationViewModel;

namespace PresentationViewModelTest
{
  [TestClass]
  public class MainWindowViewModelUnitTest
  {
    [TestMethod]
    public void ConstructorTest()
    {
      MainWindowViewModel window = new MainWindowViewModel();
      Assert.IsNotNull(window.ButtomClick);
      Assert.IsTrue(window.ButtomClick.CanExecute(null));
    }
  }
}