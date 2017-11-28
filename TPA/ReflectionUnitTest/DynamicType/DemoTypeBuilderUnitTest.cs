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
        public void TestCreateInstanceWithPublicField()
        {
            object instance = DemoTypeBuilder.createInstanceWithPublicField();
            Assert.IsNotNull(instance);

            Type type = instance.GetType();
            Assert.IsNotNull(type);
            Assert.IsTrue(type.Name == "DemoType");
            
            FieldInfo fieldInfo = type.GetField("number");
            Assert.IsNotNull(fieldInfo.GetValue(instance));
            Assert.AreEqual(fieldInfo.GetValue(instance).GetType(), typeof(int));
            Assert.AreEqual(fieldInfo.GetValue(instance), 0);
        }

        [TestMethod]
        public void TestCreateInstanceWithPublicFieldAndDefaultConstructor()
        {
            object instance = DemoTypeBuilder.createInstanceWithPublicFieldAndDefaultConstructor();
            Assert.IsNotNull(instance);

            Type type = instance.GetType();
            Assert.IsNotNull(type);
            Assert.IsTrue(type.Name == "DemoType2");

            FieldInfo fieldInfo = type.GetField("number");
            Assert.IsNotNull(fieldInfo.GetValue(instance));
            Assert.AreEqual(fieldInfo.GetValue(instance).GetType(), typeof(int));
            Assert.AreEqual(fieldInfo.GetValue(instance), 7);

            instance = Activator.CreateInstance(type, 21);
            Assert.IsNotNull(fieldInfo.GetValue(instance));
            Assert.AreEqual(fieldInfo.GetValue(instance).GetType(), typeof(int));
            Assert.AreEqual(fieldInfo.GetValue(instance), 21);
        }
    }
}
