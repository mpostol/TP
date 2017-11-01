namespace TPA.Logging.Consumer
{
  public class SemanticEventUser
  {
    public void LogFailure()
    {
      SemanticEventSource.Log.Failure(nameof(LogFailure));
    }
  }
}
