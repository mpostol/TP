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

namespace AdaptiveProgramming.Logging.UnitTest
{
  [TestClass]
  public class TelemetryInterfaceTestClass
  {
    
    [TestMethod]
    public void TelemetryInterfaceTest()
    {
      TelemetryInstance telemetry = new TelemetryInstance();
      Assert.ThrowsException<NotImplementedException>(() => telemetry.TrackDependency("test", "test", "test", "test", DateTimeOffset.Now, TimeSpan.Zero, "test", true));
      Assert.ThrowsException<NotImplementedException>(() => telemetry.TrackEvent("test"));
      Assert.ThrowsException<NotImplementedException>(() => telemetry.TrackException(new Exception()));
      Assert.ThrowsException<NotImplementedException>(() => telemetry.TrackMetric("test", 1.0));
      Assert.ThrowsException<NotImplementedException>(() => telemetry.TrackPageView("test"));
      Assert.ThrowsException<NotImplementedException>(() => telemetry.TrackRequest("test", DateTimeOffset.Now, TimeSpan.Zero, "test", true));
      Assert.ThrowsException<NotImplementedException>(() => telemetry.TrackTrace("test", new Dictionary<string, string>()));
    }

    #region instrumentation

    private class TelemetryInstance : ITelemetry
    {
      public void TrackDependency(string dependencyTypeName, string target, string dependencyName, string data, DateTimeOffset startTime, TimeSpan duration, string resultCode, bool success)
      {
        throw new NotImplementedException();
      }

      public void TrackEvent(string eventName, Dictionary<string, string> properties = null, IDictionary<string, double> metrics = null)
      {
        throw new NotImplementedException();
      }

      public void TrackException(Exception exception, IDictionary<string, string> properties = null, IDictionary<string, double> metrics = null)
      {
        throw new NotImplementedException();
      }

      public void TrackMetric(string name, double value, IDictionary<string, string> properties = null)
      {
        throw new NotImplementedException();
      }

      public void TrackPageView(string name)
      {
        throw new NotImplementedException();
      }

      public void TrackRequest(string name, DateTimeOffset startTime, TimeSpan duration, string responseCode, bool success)
      {
        throw new NotImplementedException();
      }

      public void TrackTrace(string message, IDictionary<string, string> properties)
      {
        throw new NotImplementedException();
      }
    }

    #endregion

  }
}