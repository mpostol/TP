using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPA.ApplicationArchitecture;

namespace TPA.Reflection.UnitTest
{
    [TestClass]
    public class ReflectorUnitTest
    {
        [TestMethod]
        public void ReflectorConstructorTest()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Reflector(""));

            try
            {
                Reflector reflector = new Reflector("TPA.ApplicationArchitecture.dll");
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }
    }
}
