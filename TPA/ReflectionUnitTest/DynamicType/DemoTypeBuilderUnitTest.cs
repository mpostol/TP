using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPA.Reflection.DynamicType;
using System.Reflection;

namespace TPA.Reflection.UnitTest.DynamicType
{
    [TestClass]
    public class DemoTypeBuilderUnitTest
    {
        [TestMethod]
        public void TestCreateInstance()
        {
            object instance = DemoTypeBuilder.createInstance();
            Assert.IsNotNull(instance);
            Assert.IsTrue(instance.GetType().Name == "DemoType");

            Type type = instance.GetType();
            FieldInfo fieldInfo = type.GetField("number");
            Assert.IsNotNull(fieldInfo.GetValue(instance));
            Assert.AreEqual(fieldInfo.GetValue(instance).GetType(), typeof(int));
        }
    }
}
