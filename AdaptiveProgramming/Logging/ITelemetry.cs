
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

namespace AdaptiveProgramming.Logging
{

  public interface ITelemetry
  {
    /// <summary>
    /// Pages, screens, blades, or forms
    /// </summary>
    /// <param name="name"></param>
    void TrackPageView(string name);

    /// <summary>
    /// User actions and other events. Used to track user behavior or to monitor performance.
    /// </summary>
    void TrackEvent(string eventName, Dictionary<string, string> properties = null, IDictionary<string, double> metrics = null);

    /// <summary>
    /// Performance measurements such as queue lengths not related to specific events.
    /// </summary>
    void TrackMetric(string name, double value, IDictionary<string, string> properties = null);

    /// <summary>
    /// Logging exceptions for diagnosis. Trace where they occur in relation to other events and examine stack traces.
    /// </summary>
    void TrackException(Exception exception, IDictionary<string, string> properties = null, IDictionary<string, double> metrics = null);

    /// <summary>
    /// Logging the frequency and duration of server requests for performance analysis.
    /// </summary>
    void TrackRequest(string name, DateTimeOffset startTime, TimeSpan duration, string responseCode, bool success);

    /// <summary>
    /// Diagnostic log messages. You can also capture third-party logs.
    /// </summary>
    void TrackTrace(string message, IDictionary<string, string> properties);

    /// <summary>
    /// Logging the duration and frequency of calls to external components that your app depends on.
    /// </summary>
    void TrackDependency(string dependencyTypeName, string target, string dependencyName, string data, DateTimeOffset startTime, TimeSpan duration, string resultCode, bool success);
  }
}

