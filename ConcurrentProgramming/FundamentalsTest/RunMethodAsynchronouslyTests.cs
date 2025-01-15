using System.ComponentModel;
using TP.ConcurrentProgramming.Fundamentals;

namespace TP.ConcurrentProgramming.FundamentalsTest
{
  [TestClass]
  public class RunMethodAsynchronouslyTests
  {
    [TestMethod]
    public void Constructor_ShouldAttachEventHandlers()
    {
      // Arrange
      DoWorkEventHandler doWorkHandler = new DoWorkEventHandler((sender, e) => { });
      RunWorkerCompletedEventHandler completedHandler = new RunWorkerCompletedEventHandler((sender, e) => { });

      // Act
      using (RunMethodAsynchronously runner = new RunMethodAsynchronously(doWorkHandler, completedHandler))
      {
        // Assert
        Assert.IsNotNull(runner);
      }
    }

    [TestMethod]
    public void RunAsync_WithArgument_ShouldStartWorker()
    {
      // Arrange
      var doWorkHandler = new DoWorkEventHandler((sender, e) => { });
      var completedHandler = new RunWorkerCompletedEventHandler((sender, e) => { });
      var runner = new RunMethodAsynchronously(doWorkHandler, completedHandler);
      var argument = new object();

      // Act
      runner.RunAsync(argument);

      // Assert
      runner.Dispose();
      // No exception means the test passed
    }

    [TestMethod]
    public void RunAsync_WithoutArgument_ShouldStartWorker()
    {
      // Arrange
      RunMethodAsynchronously? doWorkSender = null;
      RunMethodAsynchronously? completedHandlerSender = null;
      int doWorkHandlerCounter = 0;
      int completedHandlerCounter = 0;
      DoWorkEventHandler doWorkHandler = new DoWorkEventHandler((sender, e) =>
      {
        doWorkSender = sender as RunMethodAsynchronously;
        Assert.IsNotNull(e);
        Assert.IsNull(e.Argument);
        doWorkHandlerCounter++;
      });
      RunWorkerCompletedEventHandler completedHandler =
        new RunWorkerCompletedEventHandler((sender, e) =>
        {
          completedHandlerSender = sender as RunMethodAsynchronously;
          Assert.IsNotNull(e);
          Assert.IsNull(e.Error);
          Assert.IsFalse(e.Cancelled);
          Assert.IsNull(e.Result);
          completedHandlerCounter++;
        });
      RunMethodAsynchronously runner = new RunMethodAsynchronously(doWorkHandler, completedHandler);

      // Act
      runner.RunAsync();
      //while (completedHandlerCounter == 0)
      Thread.Sleep(1000);

      // Assert
      Assert.AreEqual<int>(1, doWorkHandlerCounter);
      Assert.AreEqual<int>(1, completedHandlerCounter);
      Assert.AreSame<object>(doWorkSender, completedHandlerSender);
      runner.Dispose();
    }
  }
}