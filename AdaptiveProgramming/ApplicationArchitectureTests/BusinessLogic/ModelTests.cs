using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            model.Linq2SQL.Connect();

            Assert.IsInstanceOfType(model.Linq2SQL, typeof(TestLinq2SQL));
        }
    }
}
