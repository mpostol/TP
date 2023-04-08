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
using System.Threading.Tasks;

namespace TPD.Communication.ClientServerCommunication.WebSocketAPI
{
  public abstract class WebSocketConnection
  {
    public virtual Action<string> onMessage { set; protected get; } = x => { };
    public virtual Action onClose { set; protected get; } = () => { };
    public virtual Action onError { set; protected get; } = () => { };

    public async Task SendAsync(string message)
    {
      await SendTask(message);
    }

    public abstract Task DisconnectAsync();

    protected abstract Task SendTask(string message);
  }
}