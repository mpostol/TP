//__________________________________________________________________________________________
//
//  Copyright 2021 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started 
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TPD.Communication.ClientServerCommunication.WebSocketAPI;

namespace TPD.Communication.ClientServerCommunication
{
  [TestClass]
  public class WebSocketAPIUnitTest
  {
    [TestMethod]
    public async Task WebSocketUsageTestMethod()
    {
      WebSocketConnection _wserver = null;
      WebSocketConnection _wclient = null;
      const int _delay = 10;

      //create server
      Uri uri = new Uri("ws://localhost:6966");
      List<string> logOutput = new List<string>();
      Task server = Task.Run(async () => await WebSocketServer.Server(uri.Port,
          _ws =>
          {
            _wserver = _ws; _wserver.onMessage = (data) =>
                  {
                    logOutput.Add($"Received message from client: { data}");
                  };
          }));
      await Task.Delay(_delay); //To make sure that the server is listening for messages
      //connect client
      _wclient = await WebSocketClient.Connect(uri, message => logOutput.Add(message));

      Assert.IsNotNull(_wserver);
      Assert.IsNotNull(_wclient);

      //send testing data from client to the server (use serialization if possible)
      Task clientSendTask = _wclient.SendAsync("test");
      Assert.IsTrue(clientSendTask.Wait(new TimeSpan(0, 0, 1))); //To make sure that the send operation has been finished successfully
      await Task.Delay(_delay); //To make sure that the message has been received by the server

      //test correctness of the data
      Assert.AreEqual($"Received message from client: test", logOutput[1]);

      //respond from the server
      _wclient.onMessage = (data) =>
      {
        logOutput.Add($"Received message from server: { data}");
      };
      Task serverSendTask =_wserver.SendAsync("test 2");
      Assert.IsTrue(serverSendTask.Wait(new TimeSpan(0, 0, 1))); //To make sure that the send operation has been finished successfully
      await Task.Delay(_delay); //To make sure that the message has been received by the server
      Assert.AreEqual($"Received message from server: test 2", logOutput[2]); //test correctness of the response
      await _wclient?.DisconnectAsync();
      await _wserver?.DisconnectAsync();
    }
  }
}