using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TPA.ApplicationArchitecture.BusinessLogic.Tests
{
    [TestClass()]
    public class ModelTests
    {
        [TestMethod()]
        public void DefaultModelTest()
        {
            Model model = new Model();
            model.Linq2SQL.Connect();

            Assert.IsNotNull(model.Linq2SQL);
        }

        [TestMethod()]
        public void ModelTest()
        {
            Model model = new Model(new TestLinq2SQL());
            Assert.IsInstanceOfType(model.Linq2SQL, typeof(TestLinq2SQL));    
        }

        [TestMethod()]
        public void ConsoleOutputTextOfLinq2SQLField()
        {
            Model model = new Model(new TestLinq2SQL());

            var currentConsoleOut = Console.Out;

            string Linq2SQLConnectMessage = "Text to write for UT";

            using (var consoleOutput = new ConsoleOutput())
            {

                model.Linq2SQL.Connect();
                Assert.AreEqual(Linq2SQLConnectMessage, consoleOutput.GetOuput());
            }

            Assert.AreEqual(currentConsoleOut, Console.Out);
        }


    }
}
