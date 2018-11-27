//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System;
using System.Collections.Generic;

namespace TPA.Composition.UnitTest.CommonServiceLocatorInstrumentation
{

  public class Logger : ILogger
  {
    public List<string> MemoryLog = new List<string>();
    public static Logger LoggerInstance { get; } = new Logger();
    public void Log(string msg)
    {
      MemoryLog.Add(msg);
    }
    private Logger() { }
  }
  public class AdvancedLogger : ILogger
  {
    public void Log(string msg)
    {
      throw new NotImplementedException();
    }
  }
}
