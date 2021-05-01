//___________________________________________________________________________________
//
//  Copyright (C) 2021, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

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