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