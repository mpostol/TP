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
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPD.Communication.ClientServerCommunication.WebSocketAPI
{
  public static class WebSocketClient
  {
    #region API

    public static async Task<WebSocketConnection> Connect(Uri peer, Action<string> log)
    {
      ClientWebSocket m_ClientWebSocket = new ClientWebSocket();
      await m_ClientWebSocket.ConnectAsync(peer, CancellationToken.None);
      switch (m_ClientWebSocket.State)
      {
        case WebSocketState.Open:
          log($"Opening WebSocket connection to remote server {peer}");
          WebSocketConnection _socket = new ClintWebSocketConnection(m_ClientWebSocket, peer, log);
          return _socket;

        default:
          log?.Invoke($"Cannot connect to remote node status {m_ClientWebSocket.State}");
          throw new WebSocketException($"Cannot connect to remote node status {m_ClientWebSocket.State}");
      }
    }

    #endregion API

    #region private

    private class ClintWebSocketConnection : WebSocketConnection
    {
      public ClintWebSocketConnection(ClientWebSocket clientWebSocket, Uri peer, Action<string> log)
      {
        m_ClientWebSocket = clientWebSocket;
        m_Peer = peer;
        m_Log = log;
        Task.Factory.StartNew(() => ClientMessageLoop());
      }

      #region WebSocketConnection

      protected override Task SendTask(string message)
      {
        return m_ClientWebSocket.SendAsync(message.GetArraySegment(), WebSocketMessageType.Text, true, CancellationToken.None); ;
      }

      public override Task DisconnectAsync()
      {
        return m_ClientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Shutdown procedure started", CancellationToken.None);
      }

      #endregion WebSocketConnection

      #region Object

      public override string ToString()
      {
        return m_Peer.ToString();
      }

      #endregion Object

      #region private

      private ClientWebSocket m_ClientWebSocket = null;
      private Uri m_Peer = null;
      private readonly Action<string> m_Log;

      private void ClientMessageLoop()
      {
        try
        {
          byte[] buffer = new byte[1024];
          while (true)
          {
            ArraySegment<byte> segment = new ArraySegment<byte>(buffer);
            WebSocketReceiveResult result = m_ClientWebSocket.ReceiveAsync(segment, CancellationToken.None).Result;
            if (result.MessageType == WebSocketMessageType.Close)
            {
              onClose?.Invoke();
              m_ClientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "I am closing", CancellationToken.None).Wait();
              return;
            }
            int count = result.Count;
            while (!result.EndOfMessage)
            {
              if (count >= buffer.Length)
              {
                onClose?.Invoke();
                m_ClientWebSocket.CloseAsync(WebSocketCloseStatus.InvalidPayloadData, "That's too long", CancellationToken.None).Wait();
                return;
              }
              segment = new ArraySegment<byte>(buffer, count, buffer.Length - count);
              result = m_ClientWebSocket.ReceiveAsync(segment, CancellationToken.None).Result;
              count += result.Count;
            }
            string _message = Encoding.UTF8.GetString(buffer, 0, count);
            onMessage?.Invoke(_message);
          }
        }
        catch (Exception _ex)
        {
          m_Log($"Connection has been broken because of an exception {_ex}");
          m_ClientWebSocket.CloseAsync(WebSocketCloseStatus.InternalServerError, "Connection has been broken because of an exception", CancellationToken.None).Wait();
        }
      }

      #endregion private
    }

    #endregion private
  }
}