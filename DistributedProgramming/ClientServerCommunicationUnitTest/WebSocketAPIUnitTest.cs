//____________________________________________________________________________
//
//  Copyright 2021 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TPD.Communication.ClientServerCommunication.WebSocketAPI;

namespace TPD.Communication.ClientServerCommunication
{
    [TestClass]
    public class WebSocketAPIUnitTest
    {
        private WebSocketConnection _wserver = null;
        private WebSocketConnection _wclient = null;
        private int _delay = 10;

        [TestCleanup]
        public async Task Cleanup()
        {
            await _wclient?.DisconnectAsync();
            await _wserver?.DisconnectAsync();
        }

        [TestMethod]
        public async Task WebSocketUsageTestMethod()
        {
            //TODO WebSockets example #170

            //create server
            //Assert.Inconclusive("WebSockets example #170");
            var uri = new Uri("ws://localhost:6966");
            var logOutput = new List<string>();
            Action<string> log = (message) => logOutput.Add(message);
            Task server = Task.Run(async () => await WebSocketServer.Server(uri.Port,
                _ws =>
                {
                    _wserver = _ws; _wserver.onMessage = (data) =>
                    {
                        log($"Received message from client: { data}");
                    };
                }));
            await Task.Delay(_delay);


            //connect client

            _wclient = await WebSocketClient.Connect(uri, log);


            Assert.IsNotNull(_wserver);
            Assert.IsNotNull(_wclient);

            //send testing data from client to the server (use serialization if possible)


            await _wclient.SendAsync("test");
            await Task.Delay(_delay);


            //test correctness of the data
            Assert.AreEqual($"Received message from client: test", logOutput[1]);

            //respond from the server
            _wclient.onMessage = (data) =>
            {
                log($"Received message from server: { data}");
            };
            await _wserver.SendAsync("test 2");
            await Task.Delay(_delay);

            //test correctness of the response
            Assert.AreEqual($"Received message from server: test 2", logOutput[2]);
        }
    }
}