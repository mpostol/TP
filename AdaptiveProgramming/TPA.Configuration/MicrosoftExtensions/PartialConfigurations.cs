
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace TPA.Configuration.MicrosoftExtensions
{
  public static class PartialConfigurations
  {
    public static string DefaultConnectionString { get; } = @"Server=(localdb)\\mssqllocaldb;Database=SampleData-0B3B0919-C8B3-481C-9833-36C21776A565;Trusted_Connection=True;MultipleActiveResultSets=true";

    public static IReadOnlyDictionary<string, string> InMemoryConfiguration { get; } =
        new Dictionary<string, string>()
        {
          ["Profile:UserName"] = Environment.UserName,
          [$"ConnectionString"] = DefaultConnectionString,
          [$"MainWindow:Height"] = "40",
          [$"MainWindow:Width"] = "60",
          [$"MainWindow:Top"] = "0",
          [$"MainWindow:Left"] = "0",
        };
    public static Dictionary<string, string> GetSwitchMappings(IReadOnlyDictionary<string, string> configurationStrings)
    {
      return configurationStrings
        .Select(item => new KeyValuePair<string, string>("-" + item.Key.Substring(item.Key.LastIndexOf(':') + 1), item.Key))
        .ToDictionary(item => item.Key, item => item.Value);
    }
    public static IConfiguration GetInMemoryConfiguration()
    {
      ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
      configurationBuilder.AddInMemoryCollection(InMemoryConfiguration);
      return configurationBuilder.Build();
    }
    public static IConfiguration GetInMemoryConfiguration(string[] args)
    {
      ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
      configurationBuilder
        .AddInMemoryCollection(InMemoryConfiguration)
        .AddCommandLine(args, GetSwitchMappings(InMemoryConfiguration));
      return configurationBuilder.Build();
    }
    public static AppConfiguration GetApplicationConfiguration(IConfiguration configuration)
    {
      AppConfiguration appConfiguration = configuration.Get<AppConfiguration>();
      return appConfiguration;
    }
  }
}
