
using System.Globalization;
using System.Linq;
using System.Reflection;
using AppResources;
using AppResources.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPA.Reflection.UnitTest.Providers;

namespace TPA.Reflection.UnitTest
{
    [TestClass]
    public class LocalizedDescriptionUnitTest
    {
        [DataRow(null,DisplayName = "Current culture")]
        [DataRow("pl-PL",DisplayName = "pl-PL culture")]
        [DataRow("en-GB",DisplayName = "en-GB culture")]
        [DataTestMethod]
        public void TestWhetherAttributesAreBeingLocalizedProperly(string testCulture)
        {
            //choose culture based on given test case
            ICultureInfoProvider cultureProvider = new CustomCultureProvider(string.IsNullOrEmpty(testCulture)
                ? CultureInfo.CurrentCulture
                : CultureInfo.GetCultureInfo(testCulture));
            IAppResourcesProxy resourceProxy = new AppResourcesProxy(cultureProvider);
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
