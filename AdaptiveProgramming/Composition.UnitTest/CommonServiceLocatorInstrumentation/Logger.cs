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

using Microsoft.Testing.Platform.Logging;

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

    #region ILogger

    public Task LogAsync<TState>(LogLevel logLevel, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
      throw new NotImplementedException();
      // return ((ILogger)LoggerInstance).LogAsync(logLevel, state, exception, formatter);
    }

    public void Log<TState>(LogLevel logLevel, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
      throw new NotImplementedException();
      // ((ILogger)LoggerInstance).Log(logLevel, state, exception, formatter);
    }

    public bool IsEnabled(LogLevel logLevel)
    {
      throw new NotImplementedException();
      //return ((ILogger)LoggerInstance).IsEnabled(logLevel);
    }

    #endregion

    private Logger() { }
  }

  public class AdvancedLogger : ILogger
  {
    public bool IsEnabled(LogLevel logLevel)
    {
      throw new NotImplementedException();
    }

    public void Log(string msg)
    {
      throw new NotImplementedException();
    }

    public void Log<TState>(LogLevel logLevel, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
      throw new NotImplementedException();
    }

    public Task LogAsync<TState>(LogLevel logLevel, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
      throw new NotImplementedException();
    }
  }
}