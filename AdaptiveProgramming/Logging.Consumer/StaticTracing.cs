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
using System.Diagnostics;

namespace TPA.Logging.Consumer
{
  public class StaticTracing
  {
    public void Processing()
    {
      Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
      Trace.AutoFlush = true;
      Trace.Indent();
      Trace.WriteLine($"Entering {nameof(Processing)}");
      Console.WriteLine("Hello World.");
      Trace.WriteLine($"Exiting {nameof(Processing)}");
      Trace.Unindent();
      Trace.Flush();
    }
  }
}