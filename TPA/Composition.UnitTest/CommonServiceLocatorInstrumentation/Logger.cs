
using System;

namespace TPA.Composition.UnitTest.CommonServiceLocatorInstrumentation
{

  public class Logger : ILogger
  {
    public void Log(string msg) { }
  }
  public class AdvancedLogger : ILogger
  {
    public void Log(string msg)
    {
      throw new NotImplementedException();
    }
  }
}
