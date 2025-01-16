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
    public void RunAsyncWithoutArgument()
    {
      // Arrange
      int doWorkHandlerCounter = 0;
      RunMethodAsynchronously? doWorkSender = null;
      DoWorkEventArgs? doWorkEventArgs = null;
      DoWorkEventHandler doWorkHandler = new DoWorkEventHandler((sender, e) =>
      {
        doWorkSender = sender as RunMethodAsynchronously;
        doWorkEventArgs = e;  
        doWorkHandlerCounter++;
      });
      RunMethodAsynchronously? completedHandlerSender = null;
      RunWorkerCompletedEventArgs? runWorkerCompletedEventArgs = null;
      int completedHandlerCounter = 0;
      RunWorkerCompletedEventHandler completedHandler =
        new RunWorkerCompletedEventHandler((sender, e) =>
        {
          completedHandlerSender = sender as RunMethodAsynchronously;
          runWorkerCompletedEventArgs = e;
          completedHandlerCounter++;
        });
      RunMethodAsynchronously runner = new RunMethodAsynchronously(doWorkHandler, completedHandler);

      // Act
      runner.RunAsync();
      Thread.Sleep(1000);

      // Assert doWork
      Assert.AreEqual<int>(1, doWorkHandlerCounter);
      Assert.IsNotNull(doWorkEventArgs);
      Assert.IsNull(doWorkEventArgs.Argument);
      Assert.IsNull(doWorkEventArgs.Result);

      // Assert completed
      Assert.AreEqual<int>(1, completedHandlerCounter);
      Assert.IsNotNull(runWorkerCompletedEventArgs);
      Assert.IsNull(runWorkerCompletedEventArgs.Error);
      Assert.IsFalse(runWorkerCompletedEventArgs.Cancelled);
      Assert.IsNull(runWorkerCompletedEventArgs.Result);
      Assert.AreSame<object>(doWorkSender, completedHandlerSender);
      runner.Dispose();
    }
  }
}