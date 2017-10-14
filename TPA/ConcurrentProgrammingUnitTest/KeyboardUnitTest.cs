using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPA.AsynchronousBehavior.ConcurrentProgramming;

namespace ConcurrentProgrammingUnitTest
{
    [TestClass]
    public class KeyboardUnitTest
    {
        private Keyboard _keyboard;

        [TestInitialize]
        public void Init()
        {
            _keyboard = new Keyboard();
        }

        [TestMethod]
        public void CheckWhetherKeyboardGeneratesKeystrokes()
        {
            List<char> chars = new List<char>();

            _keyboard.StartTyping();
            for (int i = 0; i < 3; i++)
                chars.Add(_keyboard.ReadKeyFromKeyboardBufferAsync().Result);
            _keyboard.StopTyping();


            Assert.IsTrue(chars.Count == 3);
        }
    }
}
