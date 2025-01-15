//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2025, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//_____________________________________________________________________________________________________________________________________

using TP.ConcurrentProgramming.Fundamentals;

namespace TP.ConcurrentProgramming.FundamentalsTest
{
  [TestClass]
  public class RunMethodAsynchronouslyTest
  {
    private bool _methodCalled = false;
    private object[]? _receivedParameters = null;

    [TestMethod]
    public void RunAsync_WithParameters_ShouldCallMethod()
    {
      // Arrange
      RunMethodAsynchronously.AsyncOperation operation = MethodToRun;
      RunMethodAsynchronously runner = new RunMethodAsynchronously(operation);
      object[] parameters = { 1, "test" };

      // Act
      Assert.Inconclusive("RunAsync - operation is not supported on this platform");
      runner.RunAsync(parameters);
      Thread.Sleep(100); // Wait for the async operation to complete

      // Assert
      Assert.IsTrue(_methodCalled);
      Assert.IsNotNull(_receivedParameters);
      Assert.AreEqual(parameters.Length, _receivedParameters.Length);
      Assert.AreEqual(parameters[0], _receivedParameters[0]);
      Assert.AreEqual(parameters[1], _receivedParameters[1]);
    }

    [TestMethod]
    public void RunAsync_WithoutParameters_ShouldCallMethod()
    {
      // Arrange
      RunMethodAsynchronously.AsyncOperation operation = MethodToRun;
      var runner = new RunMethodAsynchronously(operation);

      // Act
      Assert.Inconclusive("RunAsync - operation is not supported on this platform");
      runner.RunAsync();
      Thread.Sleep(100); // Wait for the async operation to complete

      // Assert
      Assert.IsTrue(_methodCalled);
      Assert.IsNull(_receivedParameters);
    }

    #region test instrumentation
    private void MethodToRun(object[] parameters)
    {
      _methodCalled = true;
      _receivedParameters = parameters;
    } 
    #endregion
  }
}