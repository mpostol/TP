//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2026, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//  by introducing yourself and telling us what you do with this community.
//_____________________________________________________________________________________________________________________________________

using AdaptiveProgramming.Composition;

namespace TPA.Composition.UnitTest.Instrumentation
{
  /// <summary>
  /// Logger implementation that stores log messages in memory. It implements the ILogger interface and provides a singleton instance for logging.
  /// </summary>
  public class InMemoryLogger : ICustomLogger
  {
    /// <summary>
    /// Singleton instance of the Logger class. It provides a single point of access to the logger functionality.
    /// </summary>
    public static InMemoryLogger LoggerInstance { get; } = new InMemoryLogger();

    public void Log(string msg)
    {
      MemoryLog.Add(msg);
    }

    #region Debug infrastructure
    internal int Count => MemoryLog.Count;
    #endregion

    #region private
    private readonly List<string> MemoryLog = [];
    private InMemoryLogger() { }
    #endregion  
  }
}