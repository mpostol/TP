//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2024, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//_____________________________________________________________________________________________________________________________________

using System.Globalization;

namespace TP.ConcurrentProgramming.Synchronization.Test
{
  [TestClass]
  public class ManagerUnitTest
  {
    [TestMethod]
    public void DefaultParametersTestMethod()
    {
      CultureInfo thredCultureInfo = Thread.CurrentThread.CurrentCulture;
      Thread newThread = Manager.InstantiateStartThread(() =>
      {
        thredCultureInfo = Thread.CurrentThread.CurrentCulture;
        for (int i = 0; i < 100; i++)
        {
          Thread.Sleep(1);
        }
      });
      Assert.AreEqual<string>("Thread 1", newThread.Name);
      Assert.AreEqual<ThreadPriority>(ThreadPriority.Normal, newThread.Priority);
      Assert.IsTrue(newThread.IsAlive);
      Assert.IsTrue(newThread.IsBackground);
      newThread.Join();
      Assert.IsFalse(newThread.IsAlive);
      Assert.AreEqual<string>(CultureInfo.InvariantCulture.ToString(), thredCultureInfo.ToString());
    }
  }
}