
using AppResources;
using AppResources.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;
using System.Reflection;
using TPA.Reflection.UnitTest.Providers;

namespace TPA.Reflection.UnitTest
{
  [TestClass]
  public class LocalizedDescriptionUnitTest
  {
    [DataRow(null, DisplayName = "Current culture")]
    [DataRow("pl-PL", DisplayName = "pl-PL culture")]
    [DataRow("en-GB", DisplayName = "en-GB culture")]
    [DataTestMethod]
    public void TestWhetherAttributesAreBeingLocalizedProperly(string testCulture)
    {
      //choose culture based on given test case
      ICultureInfoProvider _cultureProvider = new CustomCultureProvider(string.IsNullOrEmpty(testCulture)
          ? CultureInfo.CurrentCulture
          : CultureInfo.GetCultureInfo(testCulture));
      IAppResourcesProxy _resourceProxy = new AppResourcesProxy(_cultureProvider);
      LocalizedDescriptionAttribute.ResourcesProxy = _resourceProxy;

      //obtain properties
      PropertyInfo firstPropertyInfo =
          typeof(TestInstrumentation).GetProperty(nameof(TestInstrumentation.MyFirstTestProperty));
      PropertyInfo secondPropertyInfo =
          typeof(TestInstrumentation).GetProperty(nameof(TestInstrumentation.MySecondTestProperty));

      //obtain attributes
      LocalizedDescriptionAttribute _firstAttribute =
          firstPropertyInfo.GetCustomAttribute<LocalizedDescriptionAttribute>();
      LocalizedDescriptionAttribute _secondAttribute =
          secondPropertyInfo.GetCustomAttribute<LocalizedDescriptionAttribute>();

      //asserts
      Assert.AreEqual(_firstAttribute.Description, _resourceProxy.GetString(_firstAttribute.LocalizationKey));
      Assert.AreEqual(_secondAttribute.Description, _resourceProxy.GetString(_secondAttribute.LocalizationKey));
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
