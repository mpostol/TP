using TPA.ApplicationArchitecture.BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPA.ApplicationArchitecture.Data.API;
using TPA.ApplicationArchitectureTests.BusinessLogic.Tests;

namespace TPA.ApplicationArchitecture.BusinessLogic.Tests
{
    [TestClass()]
    public class ModelTests
    {
        [TestMethod()]
        public void ModelTest()
        {
            Model model = new Model( new Linq2SQL() );
            model.Linq2SQL.Connect();
        }
    }
}


