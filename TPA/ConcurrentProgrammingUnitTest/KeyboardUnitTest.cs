
using System.Collections.Generic;
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

    }
}
