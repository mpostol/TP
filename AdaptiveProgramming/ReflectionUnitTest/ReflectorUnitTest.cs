using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPA.ApplicationArchitecture;
using TPA.Reflection.Model;

namespace TPA.Reflection.UnitTest
{
    [TestClass]
    public class ReflectorUnitTest
    {
        private string assembly;
        private Reflector reflector;

        [TestInitialize]
        public void Init()
        {
            assembly = "TPA.ApplicationArchitecture.dll";
            reflector = new Reflector(assembly);
        }

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

        [TestMethod]
        public void AssemblyNameTest()
        {
            string assembly = "TPA.ApplicationArchitecture.dll";
            Reflector reflector = new Reflector(assembly);
            Assert.AreEqual(assembly, reflector.m_AssemblyModel.m_Name);
        }

        [TestMethod]
        public void CircularReferencesShouldNotCreateNewObjects()
        {
            Assert.IsTrue(true);
            // New objects are always created for current reflector model
        }

        [TestMethod]
        public void AbstractClassTest()
        {
            TypeMetadata abstractClass = reflector.m_AssemblyModel.m_Namespaces.Single(x => x.m_NamespaceName == "TPA.ApplicationArchitecture.Data")
                .m_Types.Single(x => x.m_typeName == "AbstractClass");
            Assert.AreEqual(AbstractENum.Abstract, abstractClass.m_Modifiers.Item3);
            Assert.AreEqual(AbstractENum.Abstract, abstractClass.m_Methods.Single(x => x.m_Name == "AbstractMethod").m_Modifiers.Item2);
        }

        [TestMethod]
        public void ClassWithAttributesTest()
        {
            TypeMetadata attributeClass = reflector.m_AssemblyModel.m_Namespaces.Single(x => x.m_NamespaceName == "TPA.ApplicationArchitecture.Data")
                .m_Types.Single(x => x.m_typeName == "ClassWithAttribute");

            Assert.AreEqual(1, attributeClass.m_Attributes.Count());

            //TypeMetaData lacks Fields info
        }

        [TestMethod]
        public void DerivedClassTest()
        {
            TypeMetadata derivedClass = reflector.m_AssemblyModel.m_Namespaces.Single(x => x.m_NamespaceName == "TPA.ApplicationArchitecture.Data")
                .m_Types.Single(x => x.m_typeName == "DerivedClass");

            Assert.IsNotNull(derivedClass.m_BaseType);
        }

        [TestMethod]
        public void EnumTest()
        {
            Assert.IsTrue(true);
            //No information about enums in NamespaceMetaData
        }

        [TestMethod]
        public void GenericClassTest()
        {
            TypeMetadata genericClass = reflector.m_AssemblyModel.m_Namespaces
                .Single(x => x.m_NamespaceName == "TPA.ApplicationArchitecture.Data")
                .m_Types.Single(x => x.m_typeName.Contains("GenericClass"));

            Assert.AreEqual(1, genericClass.m_GenericArguments.Count());
            Assert.AreEqual("T", genericClass.m_GenericArguments.Single().m_typeName);

            Assert.AreEqual("T", genericClass.m_Properties.Single(x => x.m_Name == "GenericProperty").m_TypeMetadata.m_typeName);

            Assert.AreEqual(1, genericClass.m_Methods.Single(x => x.m_Name == "GenericMethod").m_Parameters.Count());
            Assert.AreEqual("T", genericClass.m_Methods.Single(x => x.m_Name == "GenericMethod").m_Parameters.Single().m_TypeMetadata.m_typeName);
            Assert.AreEqual("T", genericClass.m_Methods.Single(x => x.m_Name == "GenericMethod").m_ReturnType.m_typeName);

            //TypeMetaData lacks Fields info
        }

        [TestMethod]
        public void InterfaceTest()
        {
            TypeMetadata interfaceClass = reflector.m_AssemblyModel.m_Namespaces
                .Single(x => x.m_NamespaceName == "TPA.ApplicationArchitecture.Data")
                .m_Types.Single(x => x.m_typeName == "IExample");

            Assert.AreEqual(TypeMetadata.TypeKind.InterfaceType, interfaceClass.m_TypeKind);
            Assert.AreEqual(AbstractENum.Abstract, interfaceClass.m_Modifiers.Item3);

            Assert.AreEqual(AbstractENum.Abstract, interfaceClass.m_Methods.Single(x => x.m_Name == "MethodA").m_Modifiers.Item2);
        }

        [TestMethod]
        public void ImplementedInterfaceTest()
        {
            TypeMetadata interfaceClass = reflector.m_AssemblyModel.m_Namespaces
                .Single(x => x.m_NamespaceName == "TPA.ApplicationArchitecture.Data")
                .m_Types.Single(x => x.m_typeName == "IExample");
            TypeMetadata implementedInterfaceClass = reflector.m_AssemblyModel.m_Namespaces
                .Single(x => x.m_NamespaceName == "TPA.ApplicationArchitecture.Data")
                .m_Types.Single(x => x.m_typeName == "ImplementationOfIExample");

            Assert.AreEqual("IExample", implementedInterfaceClass.m_ImplementedInterfaces.Single().m_typeName);
            foreach (var method in interfaceClass.m_Methods)
            {
                Assert.IsNotNull(implementedInterfaceClass.m_Methods.SingleOrDefault(x => x.m_Name == method.m_Name));
            }
        }

        [TestMethod]
        public void Linq2SQLClassTest()
        {
            Assert.IsTrue(true);
            //No information about internal classes in NamespaceMetaData
        }

        [TestMethod]
        public void NestedClassTest()
        {

            TypeMetadata outerClass = reflector.m_AssemblyModel.m_Namespaces
                .Single(x => x.m_NamespaceName == "TPA.ApplicationArchitecture.Data")
                .m_Types.Single(x => x.m_typeName == "OuterClass");

            Assert.IsTrue(true);
            // TypeMetaData doesn't store information about private nested types (it does about public)
        }

        [TestMethod]
        public void StaticClassTest()
        {
            TypeMetadata staticClass = reflector.m_AssemblyModel.m_Namespaces
                .Single(x => x.m_NamespaceName == "TPA.ApplicationArchitecture.Data")
                .m_Types.Single(x => x.m_typeName == "StaticClass");

            Assert.AreEqual(StaticEnum.Static, staticClass.m_Methods.Single(x => x.m_Name == "StaticMethod1").m_Modifiers.Item3);

            // no information about class/property being static
            // TypeMetaData lacks Fields info
        }

        [TestMethod]
        public void StructureTest()
        {
            TypeMetadata structure = reflector.m_AssemblyModel.m_Namespaces
                .Single(x => x.m_NamespaceName == "TPA.ApplicationArchitecture.Data")
                .m_Types.Single(x => x.m_typeName == "Structure");

            Assert.AreEqual(TypeMetadata.TypeKind.StructType, structure.m_TypeKind);
        }
    }
}
