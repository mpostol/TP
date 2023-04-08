//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2023, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//  by introducing yourself and telling us what you do with this community.
//_____________________________________________________________________________________________________________________________________

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