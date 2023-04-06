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
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPD.Communication.ClientServerCommunication.WebSocketAPI
{
  public static class WebSocketServer
  {
    #region API

    public static async Task Server(int p2p_port, Action<WebSocketConnection> onConnection)
    {
      Uri _uri = new Uri($@"http://localhost:{p2p_port}/");
      await ServerLoop(_uri, onConnection);
    }

    #endregion API

    #region private

    private static async Task ServerLoop(Uri _uri, Action<WebSocketConnection> onConnection)
    {
      HttpListener _server = new HttpListener();
      _server.Prefixes.Add(_uri.ToString());
      _server.Start();
      while (true)
      {
        HttpListenerContext _hc = await _server.GetContextAsync();
        if (!_hc.Request.IsWebSocketRequest)
        {
          _hc.Response.StatusCode = 400;
          _hc.Response.Close();
        }
        HttpListenerWebSocketContext _context = await _hc.AcceptWebSocketAsync(null);
        WebSocketConnection ws = new ServerWebSocketConnection(_context.WebSocket, _hc.Request.RemoteEndPoint);
        onConnection?.Invoke(ws);
      }
    }

    private class ServerWebSocketConnection : WebSocketConnection
    {
      public ServerWebSocketConnection(WebSocket webSocket, IPEndPoint remoteEndPoint)
      {
        m_WebSocket = webSocket;
        m_remoteEndPoint = remoteEndPoint;
        Task.Factory.StartNew(() => ServerMessageLoop(webSocket));
      }

      #region WebSocketConnection

      protected override Task SendTask(string message)
      {
        return m_WebSocket.SendAsync(message.GetArraySegment(), WebSocketMessageType.Text, true, CancellationToken.None);
      }

      public override Task DisconnectAsync()
      {
        return m_WebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Shutdown procedure started", CancellationToken.None);
      }

      #endregion WebSocketConnection

      #region Object

      public override string ToString()
      {
        return m_remoteEndPoint.ToString();
      }

      #endregion Object

      private WebSocket m_WebSocket = null;
      private IPEndPoint m_remoteEndPoint;

      private void ServerMessageLoop(WebSocket ws)
      {
        byte[] buffer = new byte[1024];
        while (true)
        {
          ArraySegment<byte> _segments = new ArraySegment<byte>(buffer);
          WebSocketReceiveResult _receiveResult = ws.ReceiveAsync(_segments, CancellationToken.None).Result;
          if (_receiveResult.MessageType == WebSocketMessageType.Close)
          {
            onClose?.Invoke();
            ws.CloseAsync(WebSocketCloseStatus.NormalClosure, "I am closing", CancellationToken.None);
            return;
          }
          int count = _receiveResult.Count;
          while (!_receiveResult.EndOfMessage)
          {
            if (count >= buffer.Length)
            {
              onClose?.Invoke();
              ws.CloseAsync(WebSocketCloseStatus.InvalidPayloadData, "That's too long", CancellationToken.None);
              return;
            }
            _segments = new ArraySegment<byte>(buffer, count, buffer.Length - count);
            _receiveResult = ws.ReceiveAsync(_segments, CancellationToken.None).Result;
            count += _receiveResult.Count;
          }
          string _message = Encoding.UTF8.GetString(buffer, 0, count);
          onMessage?.Invoke(_message);
        }
      }
    }

    #endregion private
  }
}