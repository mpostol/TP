//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;

namespace TPA.Logging.Consumer
{

  [Export(typeof(ITelemetry))]
  [PartCreationPolicy(CreationPolicy.Shared)]
  /// <summary>
  /// The wrapper of the <see cref="TelemetryClient"/> sending events, metrics and other telemetry to the Application Insights service.
  /// Learn more:
  /// https://docs.microsoft.com/en-us/azure/application-insights/app-insights-api-custom-events-metrics
  /// </summary>
  sealed public class ApplicationInsightsTelemetry : ITelemetry
  {

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationInsightsTelemetry"/> class.
    /// </summary>
    /// <param name="instrumentationKey">The instrumentation key.</param>
    /// <exception cref="ArgumentNullException">Instrumentation key can not be empty..</exception>
    [ImportingConstructor]
    public ApplicationInsightsTelemetry([Import("instrumentationKey")] string instrumentationKey)
    {
      if (instrumentationKey.Equals(String.Empty))
        throw new ArgumentNullException("Instrumentation key can not be empty..");
      TelemetryConfiguration = new TelemetryConfiguration(instrumentationKey);
      TelemetryClient = new TelemetryClient(TelemetryConfiguration);
    }
    #endregion

    #region ITelemetryTracker methods
    public void StopTrackRequest(string requestName, Stopwatch stopwatch)
    {
      throw new NotImplementedException();
    }
    public void TrackDependency(string dependencyTypeName, string target, string dependencyName, string data, DateTimeOffset startTime, TimeSpan duration, string resultCode, bool success)
    {
      TelemetryClient.TrackDependency(dependencyTypeName, target, dependencyName, data, startTime, duration, resultCode, success);
    }
    /// <summary>
    /// In Application Insights, a custom event is a data point that you can display in Metrics Explorer as an aggregated count, and in Diagnostic Search as individual occurrences. (It isn't related to MVC or other framework "events.")
    /// Insert TrackEvent calls in your code to count various events.How often users choose a particular feature, how often they achieve particular goals, or maybe how often they make particular types of mistakes.
    /// For example, in a game app, send an event whenever a user wins the game:
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="properties"></param>
    /// <param name="metrics"></param>
    public void TrackEvent(string eventName, Dictionary<string, string> properties = null, IDictionary<string, double> metrics = null)
    {
      try
      {
        TelemetryClient.TrackEvent(eventName, properties, metrics);
      }
      catch (Exception e)
      {
        this.TrackException(e);
      }
    }
    public void TrackException(Exception exception, IDictionary<string, string> properties = null, IDictionary<string, double> metrics = null)
    {
      TelemetryClient.TrackException(exception, properties, metrics);
    }
    /// <summary>
    /// Application Insights can chart metrics that are not attached to particular events. For example, you could monitor a queue length at regular intervals. 
    /// With metrics, the individual measurements are of less interest than the variations and trends, and so statistical charts are useful.
    /// https://docs.microsoft.com/en-us/azure/application-insights/app-insights-how-do-i
    /// </summary>
    public void TrackMetric(string name, double value, IDictionary<string, string> properties = null)
    {
      try
      {
        MetricTelemetry metricTelemetry = new MetricTelemetry();
        metricTelemetry.Name = name;
        metricTelemetry.Sum = value;
        TelemetryClient.TrackMetric(metricTelemetry);
      }
      catch (Exception e)
      {
        this.TrackException(e);
      }
    }
    public void TrackPageView(string name)
    {
      try
      {
        TelemetryClient.TrackPageView(name);
      }
      catch (Exception e)
      {
        this.TrackException(e);
      }
    }
    /// <summary>
    /// Send information about a request handled by the application.
    /// </summary>
    public void TrackRequest(string name, DateTimeOffset startTime, TimeSpan duration, string responseCode, bool success)
    {
      try
      {
        TelemetryClient.TrackRequest(name, startTime, duration, responseCode, success);
      }
      catch (Exception e)
      {
        this.TrackException(e);
      }
    }
    public void TrackTrace(string message, IDictionary<string, string> properties)
    {
      TelemetryClient.TrackTrace(message, properties);
    }
    #endregion

    #region Fields
    private TelemetryConfiguration TelemetryConfiguration { get; set; }
    private TelemetryClient TelemetryClient { get; set; }
    #endregion

  }

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
