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

using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace TPD.Communication.ClientServerCommunication.RESTAPI
{
  //TODO client derived from  https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/console-webapiclient
  public class WebClient : IDisposable
  {
    private readonly HttpClient m_Client = new HttpClient();

    //TODO move it to UT.
    //private static async Task Main(string[] args)
    //{
    //  string repositories = await ProcessRepositories();

    //  foreach (char repo in repositories)
    //  {
    //    Console.WriteLine(repo.Name);
    //    Console.WriteLine(repo.Description);
    //    Console.WriteLine(repo.GitHubHomeUrl);
    //    Console.WriteLine(repo.Homepage);
    //    Console.WriteLine(repo.Watchers);
    //    Console.WriteLine(repo.LastPush);
    //    Console.WriteLine();
    //  }
    //}

    public async Task GetResponseApiGithubAsync(Stream destinationStream)
    {
      m_Client.DefaultRequestHeaders.Accept.Clear();
      m_Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
      m_Client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
      using (Stream _streamTask = await m_Client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos"))
      {
        int _maxLength = 1000;
        byte[] buffer = new byte[_maxLength];
        await _streamTask.CopyToAsync(destinationStream);
      }
      //var repositories = await JsonSerializer.DeserializeAsync<type>(await streamTask);
      //return repositories;
    }

    #region IDisposable Support

    private bool disposedValue = false; // To detect redundant calls

    protected virtual void Dispose(bool disposing)
    {
      if (disposedValue)
        return;
      if (disposing)
        m_Client.Dispose();
      disposedValue = true;
    }

    // This code added to correctly implement the disposable pattern.
    public void Dispose()
    {
      // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
      Dispose(true);
    }

    #endregion IDisposable Support
  }
}