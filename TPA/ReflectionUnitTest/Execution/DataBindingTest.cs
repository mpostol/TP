using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TPA.Reflection.Execution;
using TPA.Reflection.UnitTest.Execution;

namespace TPA.Reflection.UnitTest
{
    [TestClass]
    public class DataBindingTest
    {
        const string StringPropName = "StringProperty";
        const string IntPropName = "IntProperty";

        const string StringPropConsumerName = "StringPropertyConsumer";
        const string IntPropConsumerName = "IntPropertyConsumer";
        const string ValueTypePropConsumerName = "ValuePropertyConsumer";

        [TestMethod]
        public void TestDifferentExceptions()
        {
            DataSource dataSource = new DataSource();
            DataConsumer dataConsumer = new DataConsumer();

            Assert.ThrowsException<ArgumentException>(() => new DataBinding(dataSource, StringPropName, dataConsumer, IntPropConsumerName), "Properties types don't match");
            Assert.ThrowsException<ArgumentException>(() => new DataBinding(dataSource, StringPropName + "A", dataConsumer, IntPropConsumerName), "No such Property in Data Source");
            Assert.ThrowsException<ArgumentException>(() => new DataBinding(dataSource, StringPropName, dataConsumer, IntPropConsumerName + "A"), "No such Property in Data Consumer");
        }

        [TestMethod]
        public void CheckAssignmentToAppropriateTypes()
        {
            DataSource dataSource = new DataSource() { StringProperty = "Source", IntProperty = 3 };
            DataConsumer dataConsumer = new DataConsumer() { StringPropertyConsumer = "Consumer", IntPropertyConsumer = 4 };

            DataBinding binding = new DataBinding(dataSource, StringPropName, dataConsumer, StringPropConsumerName);

            Assert.AreEqual(dataSource.StringProperty, dataConsumer.StringPropertyConsumer);
            dataSource.StringProperty = "New String";
            Assert.AreEqual("New String", dataConsumer.StringPropertyConsumer);

            DataBinding bindingInt = new DataBinding(dataSource, IntPropName, dataConsumer, IntPropConsumerName);
            Assert.AreEqual(dataSource.IntProperty, dataConsumer.IntPropertyConsumer);
            dataSource.IntProperty = 15;
            Assert.AreEqual(15, dataConsumer.IntPropertyConsumer);
        }

        [TestMethod]
        public void CheckAssignmentFromInheritand()
        {
            DataSource dataSource = new DataSource() { IntProperty = 3 };
            DataConsumer dataConsumer = new DataConsumer() { ValuePropertyConsumer = 6 };

            DataBinding binding = new DataBinding(dataSource, IntPropName, dataConsumer, ValueTypePropConsumerName);

            Assert.AreEqual(dataSource.IntProperty, dataConsumer.ValuePropertyConsumer);
            dataSource.IntProperty = 87;
            Assert.AreEqual(87, dataConsumer.ValuePropertyConsumer);
        }
    }
}
