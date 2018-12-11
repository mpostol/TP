//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System.Diagnostics.Tracing;

namespace TPA.Logging.Consumer
{
  [EventSource(Name = "TPA-SemanticLogging")]
  public class SemanticEventSource : EventSource
  {
    public class Keywords
    {
      public const EventKeywords Page = (EventKeywords)1;
      public const EventKeywords DataBase = (EventKeywords)2;
      public const EventKeywords Diagnostic = (EventKeywords)4;
      public const EventKeywords Performance = (EventKeywords)8;
    }

    public class Tasks
    {
      public const EventTask Page = (EventTask)1;
      public const EventTask DBQuery = (EventTask)2;
    }

    /// <summary>
    /// Gets the log - implements singleton of the <see cref="SemanticEventSource"/>.
    /// </summary>
    /// <value>The log.</value>
    public static SemanticEventSource Log { get; } = new SemanticEventSource();

    [Event(1, Message = "Application Failure: {0}", Opcode = EventOpcode.Start, Task = Tasks.Page, Level = EventLevel.Error, Keywords = Keywords.Diagnostic)]
    internal void Failure(string message)
    {
      this.WriteEvent(1, message);
    }
    [Event(2, Message = "Starting up.", Keywords = Keywords.Performance, Level = EventLevel.Informational)]
    internal void Startup()
    {
      this.WriteEvent(2);
    }
    [Event(3, Message = "loading page {1} activityID={0}", Opcode = EventOpcode.Start, Task = Tasks.Page, Keywords = Keywords.Page, Level = EventLevel.Informational)]
    internal void PageStart(int ID, string url)
    {
      if (this.IsEnabled()) this.WriteEvent(3, ID, url);
    }
    private SemanticEventSource() { }

  }
}
