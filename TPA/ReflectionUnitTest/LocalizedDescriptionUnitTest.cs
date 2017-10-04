
using System.Globalization;
using System.Linq;
using System.Reflection;
using AppResources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPA.Reflection.UnitTest.Providers;

namespace TPA.Reflection.UnitTest
{
    [TestClass]
    public class LocalizedDescriptionUnitTest
    {
        [TestMethod]
        public void TestWhetherAttributesAreBeingLocalizedProperly()
        {

            var resourceProxy = new AppResourcesProxy(new CustomCultureProvider(CultureInfo.GetCultureInfo("pl-PL")));
            //TODO I'm not sure about this, can I do this any better?
            LocalizedDescriptionAttribute.ResourcesProxy = resourceProxy;
            
            //obtain properties
            PropertyInfo firstPropertyInfo =
                typeof(TestInstrumentation).GetProperty(nameof(TestInstrumentation.MyFirstTestProperty));
            PropertyInfo secondPropertyInfo =
                typeof(TestInstrumentation).GetProperty(nameof(TestInstrumentation.MySecondTestProperty));

            //obtain attributes
            LocalizedDescriptionAttribute firstAttribute =
                firstPropertyInfo.GetCustomAttribute<LocalizedDescriptionAttribute>();
            LocalizedDescriptionAttribute secondAttribute =
                secondPropertyInfo.GetCustomAttribute<LocalizedDescriptionAttribute>();

            //asserts
            Assert.AreEqual(firstAttribute.Description, resourceProxy.GetString(firstAttribute.LocalizationKey));
            Assert.AreEqual(secondAttribute.Description, resourceProxy.GetString(secondAttribute.LocalizationKey));
        }

        private class TestInstrumentation
        {
            [LocalizedDescription("TestString1")]
            public int MyFirstTestProperty { get; set; }

            [LocalizedDescription("TestString2")]
            public int MySecondTestProperty { get; set; }
        }
    }
}
