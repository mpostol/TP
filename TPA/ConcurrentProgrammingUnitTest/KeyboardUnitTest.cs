using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPA.AsynchronousBehavior.ConcurrentProgramming;

namespace ConcurrentProgrammingUnitTest
{
    [TestClass]
    public class KeyboardUnitTest
    {

        [TestMethod]
        public void CheckWhetherKeyboardGeneratesKeystrokes()
        {
            using (Keyboard _keyboard = new Keyboard())
            {
                List<char> _chars = new List<char>();
                for (int i = 0; i < 3; i++)
                    _chars.Add(_keyboard.ReadKeyFromKeyboardBufferAsync().Result);
                Assert.IsTrue(_chars.Count == 3);
            }
        }

        [TestMethod]
        public void CheckWhetherKeyboardGeneratesKeystrokesUsingAPM()
        {
            using (Keyboard _keyboard = new Keyboard())
            {
                List<char> _chars = new List<char>();

                for (int i = 0; i < 3; i++)
                {
                    IAsyncResult asyncResult = _keyboard.BeginReadKeyFromKeyboardBuffer(null, null);
                    _chars.Add(_keyboard.EndReadKeyFromKeyboardBuffer(asyncResult));
                }

                Assert.IsTrue(_chars.Count == 3);
            }
        }

        [TestMethod]
        public async Task CheckWhetherKeyboardGeneratesKeystrokesUsingEAP()
        {
            using (Keyboard _keyboard = new Keyboard())
            {
                List<char> _chars = new List<char>();
                SemaphoreSlim semaphore = new SemaphoreSlim(0);

                _keyboard.ReadKeyFromKeyboardBufferCompleted += (sender, args) =>
                {
                    _chars.Add(args.Result);
                    semaphore.Release();
                };

                for (int i = 0; i < 3; i++)
                {
                    _keyboard.ReadKeyFromKeyboardBufferAsyncUsingEAP();
                    await semaphore.WaitAsync();
                }

                Assert.IsTrue(_chars.Count == 3);
            }

        }
    }
}
