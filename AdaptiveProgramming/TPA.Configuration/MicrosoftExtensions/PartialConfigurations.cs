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

using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

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