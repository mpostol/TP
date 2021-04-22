using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace TPA.ApplicationArchitecture.Data.API.Tests
{
    [TestClass()]
    public class FactoryTests
    {
        [TestMethod()]
        public void CreateLinq2SQLTest()
        {
            ILinq2SQL linq2SQL = ILinq2SQL.CreateLinq2SQL();

            Assert.IsNotNull(linq2SQL);
            
        }
    }
}