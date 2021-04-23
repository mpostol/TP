//___________________________________________________________________________________
//
//  Copyright (C) 2021, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace TPA.ApplicationArchitecture.BusinessLogic.Tests
{
  [TestClass()]
  public class ModelTests
  {
    [TestMethod()]
    public void DefaultModelTest()
    {
      Model model = new Model();
      model.Linq2SQL.Connect();

      Assert.IsNotNull(model.Linq2SQL);
    }

    [TestMethod()]
    public void ModelTest()
    {
      Model model = new Model(new TestLinq2SQLFixcture());
      Assert.IsInstanceOfType(model.Linq2SQL, typeof(TestLinq2SQLFixcture));
    }

    [TestMethod()]
    public void ConsoleOutputTextOfLinq2SQLField()
    {
      Model model = new Model(new TestLinq2SQLFixcture());

      TextWriter currentConsoleOut = Console.Out;

      string Linq2SQLConnectMessage = "Text to write for UT";

      using (ConsoleOutput consoleOutput = new ConsoleOutput())
      {
        model.Linq2SQL.Connect();
        Assert.AreEqual(Linq2SQLConnectMessage, consoleOutput.GetOuput());
      }

      Assert.AreEqual(currentConsoleOut, Console.Out);
    }
  }
}