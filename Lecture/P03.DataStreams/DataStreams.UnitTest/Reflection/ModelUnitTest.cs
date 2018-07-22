//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TP.DataStreams.Reflection
{
  [TestClass]
  public class ModelUnitTest
  {
    [TestMethod]
    public void ConstructorTest()
    {
      AssemblyModel _ass = new AssemblyModel();
      Assert.IsNotNull(_ass);
    }
  }
}
