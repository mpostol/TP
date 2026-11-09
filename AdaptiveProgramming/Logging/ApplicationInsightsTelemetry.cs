
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

using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;

namespace AdaptiveProgramming.Logging
{
  public class ApplicationInsightsTelemetry : ITelemetry
  {
    public ApplicationInsightsTelemetry()
    {
      TelemetryConfiguration configuration = TelemetryConfiguration.CreateDefault();
      configuration.ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https://westus2-1.in.applicationinsights.azure.com/;LiveEndpoint=https://westus2.livediagnostics.monitor.azure.com/"; //Assigned something to pass creation test
      client = new TelemetryClient(configuration);
    }

    #region ITelemetry
    /// <summary>
    /// Send information about an external dependency (outgoing call) in the application.
    /// </summary>
    /// <param name="dependencyTypeName"> External dependency type. Very low cardinality value for logical grouping and interpretation of fields. Examples are SQL, Azure table, and HTTP.</param>
    /// <param name="target">External dependency target.</param>
    /// <param name="dependencyName">Name of the command initiated with this dependency call. Low cardinality value. Examples are stored procedure name and URL path template.</param>
    /// <param name="data"> Command initiated by this dependency call. Examples are SQL statement and HTTP URL's with all query parameters.</param>
    /// <param name="startTime">The time when the dependency was called.</param>
    /// <param name="duration">The time taken by the external dependency to handle the call.</param>
    /// <param name="resultCode">Result code of dependency call execution.</param>
    /// <param name="success">True if the dependency call was handled successfully.</param>
    public void TrackDependency(string dependencyTypeName, string target, string dependencyName, string data, DateTimeOffset startTime, TimeSpan duration, string resultCode, bool success)
    {
      try
      {
        client.TrackDependency(dependencyTypeName, target, dependencyName, data, startTime, duration, resultCode, success);
      }
      catch (Exception e)
      {
        TrackException(e);
      }
    }
    public void TrackEvent(string eventName, Dictionary<string, string> properties)
    {
      try
      {
        client.TrackEvent(eventName, properties);
      }
      catch (Exception e)
      {
        TrackException(e);
      }
    }
    public void TrackException(Exception exception, IDictionary<string, string> properties)
    {
      try
      {
        client.TrackException(exception, properties);
      }
      catch (Exception e)
      {
        TrackException(e);
      }
    }
    public void TrackMetric(string name, double value, IDictionary<string, string> properties)
    {
      try
      {
        client.TrackMetric(name, value, properties);
      }
      catch (Exception e)
      {
        TrackException(e);
      }
    }
    public void TrackRequest(string name, DateTimeOffset startTime, TimeSpan duration, string responseCode, bool success)
    {
      try
      {
        client.TrackRequest(name, startTime, duration, responseCode, success);

      }
      catch (Exception e)
      {
        TrackException(e);
      }
    }
    public void TrackTrace(string message, IDictionary<string, string> properties)
    {
      try
      {
        client.TrackTrace(message, properties);
      }
      catch (Exception e)
      {
        TrackException(e);
      } 
    }

    #endregion

    private void TrackException(Exception exception)
    {
      client.TrackException(exception, null);
    }

    #region private

    private readonly TelemetryClient client; // = new TelemetryClient(TelemetryConfiguration.CreateDefault());

    #endregion
  }
}
