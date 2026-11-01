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
using AdaptiveProgramming.Composition.Contracts;

namespace AdaptiveProgramming.Composition.UnitTest.Instrumentation
{
  /// <summary>
  /// Implementation of <see cref="ICustomLogger"/> for unit testing purposes.
  /// </summary>
  public class InStringCustomLogger : ICustomLogger
  {

    internal static ICustomLogger LoggerInstance { get; } = new InStringCustomLogger();
    internal static string LastLog { get; private set; } = "Rlr&LTxAx9F&2vOQ";

    #region ICustomLogger
    public void Log(string msg) { LastLog = msg; }
    #endregion

  }
}