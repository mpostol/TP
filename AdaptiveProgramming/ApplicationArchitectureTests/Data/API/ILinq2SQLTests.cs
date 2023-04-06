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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TPA.ApplicationArchitecture.Data.API.Tests
{
  [TestClass()]
  public class ILinq2SQLTests
  {
    [TestMethod()]
    public void CreateLinq2SQLTest()
    {
      DataLayerAbstractAPI linq2SQL = DataLayerAbstractAPI.CreateLinq2SQL();
      Assert.IsNotNull(linq2SQL);
      Assert.ThrowsException<NotImplementedException>(() => linq2SQL.Connect());
    }
  }
}