﻿//__________________________________________________________________________________________
//
//  Copyright 2023 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace TP.InformationComputation.PartialDefinitions
{
  [TestClass]
  public class CustomControlTest
  {
    [TestMethod]
    public void CustomControlTestMethod()
    {
      var thread = new Thread(() =>
      {
        CustomControl newCustomControl = new CustomControl();
        Assert.IsNotNull(newCustomControl);
      });

      thread.SetApartmentState(ApartmentState.STA); // Set the thread to STA, because WPF controls require it
      thread.Start();
      thread.Join();
    }
  }
}