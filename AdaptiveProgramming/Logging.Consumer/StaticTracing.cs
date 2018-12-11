//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

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
