
namespace TPA.Configuration.MicrosoftExtensions
{
  public class AppConfiguration
  {

    public ProfileConfiguration Profile { get; set; }
    public string ConnectionString { get; set; }
    public WindowConfiguration MainWindow { get; set; }
    public class WindowConfiguration
    {
      public int Height { get; set; }
      public int Width { get; set; }
      public int Left { get; set; }
      public int Top { get; set; }
    }
    public class ProfileConfiguration
    {
      public string UserName { get; set; }
    }
  }
}
