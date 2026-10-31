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

using TPA.Composition;

namespace TPA.Composition.UnitTest.Instrumentation
{
  /// <summary>
  /// Implementation of <see cref="ICustomLogger"/> for unit testing purposes.
  /// </summary>
  public class ImplementationOfCustomLogger : ICustomLogger
  {

    internal static ICustomLogger LoggerInstance { get; } = new ImplementationOfCustomLogger();
    internal static string? LastLog { get; private set; }

    #region ICustomLogger
    public void Log(string msg) { LastLog = msg; }
    #endregion  
  }
}