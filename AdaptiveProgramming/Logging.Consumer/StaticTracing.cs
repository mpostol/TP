
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
      Trace.WriteLine("Exiting {nameof(Processing)}");
      Trace.Unindent();
      Trace.Flush();
    }
  }
}
