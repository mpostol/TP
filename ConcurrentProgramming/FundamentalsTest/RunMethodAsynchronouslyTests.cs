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
    public void RunAsync_WithArgument()
    {
      // Arrange
      DoWorkEventArgs? doWorkEventArgs = null;
      int doWorkHandlerCounter = 0;
      DoWorkEventHandler doWorkHandler = new DoWorkEventHandler((sender, e) =>
      {
        doWorkEventArgs = e;
        Arguments? argument = e.Argument as Arguments;
        if (argument != null)
          {
            Thread.Sleep(argument.Value); //simulate a long running operation
            doWorkEventArgs.Result = "Done"; 
          }
        else
          throw new ArgumentNullException("Argument is null");
        doWorkHandlerCounter++;
      });
      RunWorkerCompletedEventArgs? runWorkerCompletedEventArgs = null;
      int completedHandlerCounter = 0;
      RunWorkerCompletedEventHandler completedHandler = new RunWorkerCompletedEventHandler((sender, e) =>
      {
        runWorkerCompletedEventArgs = e;
        completedHandlerCounter++;
      });
      var runner = new RunMethodAsynchronously(doWorkHandler, completedHandler);
      var argument = new Arguments(100);

      // Act
      runner.RunAsync(argument);
      Thread.Sleep(argument.Value * 10);
      runner.Dispose();

      // Assert

      // Assert doWork
      Assert.AreEqual<int>(1, doWorkHandlerCounter);
      Assert.IsNotNull(doWorkEventArgs);
      Assert.IsNotNull(doWorkEventArgs.Argument);
      Assert.IsNotNull(doWorkEventArgs.Result);

      // Assert completed
      Assert.AreEqual<int>(1, completedHandlerCounter);
      Assert.IsNotNull(runWorkerCompletedEventArgs);
      Assert.IsNull(runWorkerCompletedEventArgs.Error);
      Assert.IsFalse(runWorkerCompletedEventArgs.Cancelled);
      Assert.IsNotNull(runWorkerCompletedEventArgs.Result);
      Assert.IsInstanceOfType(runWorkerCompletedEventArgs.Result, typeof(string));
      Assert.AreEqual<string>("Done", (string)runWorkerCompletedEventArgs.Result);
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
      runner.Dispose();

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
    }

    #region test instrumentation

    private class Arguments
    {
      public Arguments(int delay)
      {
        Value = delay;
      }

      public int Value { get; }
    }

    #endregion test instrumentation
  }
}