//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//___________________________________________________________________________________

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