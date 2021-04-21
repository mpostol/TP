using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace TPA.ApplicationArchitecture.Data.API.Tests
{
    [TestClass()]
    public class FactoryTests
    {
        [TestMethod()]
        public void CreateLinq2SQLTest()
        {
            var linq2SQL = Factory.CreateLinq2SQL();

            Assert.IsNotNull(linq2SQL);
            Assert.IsInstanceOfType(linq2SQL, typeof(ILinq2SQL));
        }
    }
}