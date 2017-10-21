using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPA.AsynchronousBehavior.Threading;

namespace ThreadingUnitTest
{
  [TestClass]
  public class CriticalSectionExampleUnitTest
  {
    [TestInitialize]
    public void TestInitialize()
    {
      m_ThreadsExample = new CriticalSectionExample();
    }
    [TestMethod]
    public void CheckWhetherThreadsAreNotSynchronized()
    {
      m_ThreadsExample.StartThreads(false);
      Assert.IsFalse(m_ThreadsExample.IsConsistent);
    }
    [TestMethod]
    public void CheckWhetherThreadsAreSynchronized()
    {
      m_ThreadsExample.StartThreads(true);
      Assert.IsFalse(m_ThreadsExample.IsConsistent);
    }
    [TestMethod]
    public void CheckWhetherThreadsUsingThreadPoolAreNotSynchronized()
    {
      m_ThreadsExample.StartThreadsUsingThreadPool(false);
      Assert.IsFalse(m_ThreadsExample.IsConsistent);
    }
    [TestMethod]
    public void CheckWhetherThreadsUsingThreadPoolAreSynchronized()
    {
      m_ThreadsExample.StartThreadsUsingThreadPool(true);
      Assert.IsFalse(m_ThreadsExample.IsConsistent);
    }
    private CriticalSectionExample m_ThreadsExample;

  }
}
