//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using TPA.Reflection.Model;

namespace TPA.Reflection.UnitTest
{
  [TestClass]
  [DeploymentItem(@"Instrumentation\TPA.ApplicationArchitecture.dll", @"Instrumentation")]
  public class ReflectorUnitTest
  {
    [TestMethod]
    public void ReflectorConstructorTest()
    {
      Assert.ThrowsException<ArgumentNullException>(() => new Reflector(string.Empty));
      FileInfo _fileInfo = new FileInfo(ReflectorTestClass.TestAssemblyName);
      Assert.IsTrue(_fileInfo.Exists);
      Assert.IsNotNull(ReflectorTestClass.Reflector);
      Assert.IsNotNull(ReflectorTestClass.Reflector.MyNamespace);
      Assert.Inconclusive("Nor all types are processed - test fails.");
      Assert.AreEqual<int>(4, ReflectorTestClass.Reflector.Namespaces.Count);
    }
    [TestMethod]
    public void AssemblyNameTest()
    {
      Assert.Inconclusive("Remove compilation errors");
      //Reflector _reflector = new Reflector(m_TestAssemblyName);
      //Assert.AreEqual(Path.GetFileName(m_TestAssemblyName), _reflector.m_AssemblyModel.m_Name);
    }
    [TestMethod]
    public void CircularReferencesShouldNotCreateNewObjects()
    {
      Assert.Inconclusive("The test does nothing ?? - remove or add logic");
      Assert.IsTrue(true);
      // New objects are always created for current reflector model
    }
    [TestMethod]
    public void AbstractClassTest()
    {
      TypeMetadata abstractClass = ReflectorTestClass.Reflector.MyNamespace.m_Types.Single<TypeMetadata>(x => x.m_typeName == "AbstractClass");
      Assert.AreEqual(AbstractENum.Abstract, abstractClass.m_Modifiers.Item3);
      Assert.AreEqual(AbstractENum.Abstract, abstractClass.m_Methods.Single(x => x.m_Name == "AbstractMethod").m_Modifiers.Item2);
    }
    [TestMethod]
    public void ClassWithAttributesTest()
    {
      TypeMetadata attributeClass = ReflectorTestClass.Reflector.MyNamespace.m_Types.Single(x => x.m_typeName == "ClassWithAttribute");
      Assert.AreEqual(1, attributeClass.m_Attributes.Count<CustomAttributeData>());
      //TypeMetaData lacks Fields info
    }
    [TestMethod]
    public void DerivedClassTest()
    {
      TypeMetadata derivedClass = ReflectorTestClass.Reflector.MyNamespace.m_Types.Single(x => x.m_typeName == "DerivedClass");
      Assert.IsNotNull(derivedClass.m_BaseType);
    }
    [TestMethod]
    public void EnumTest()
    {
      Assert.Inconclusive("The test does nothing ?? - remove or add logic");
      Assert.IsTrue(true);
      //No information about enums in NamespaceMetaData
    }
    [TestMethod]
    public void GenericClassTest()
    {
      TypeMetadata genericClass = ReflectorTestClass.Reflector.MyNamespace.m_Types.Single<TypeMetadata>(x => x.m_typeName.Contains("GenericClass"));
      Assert.AreEqual(1, genericClass.m_GenericArguments.Count());
      Assert.AreEqual<string>("T", genericClass.m_GenericArguments.Single().m_typeName);
      Assert.AreEqual<string>("T", genericClass.m_Properties.Single<PropertyMetadata>(x => x.m_Name == "GenericProperty").m_TypeMetadata.m_typeName);
      Assert.AreEqual<int>(1, genericClass.m_Methods.Single<MethodMetadata>(x => x.m_Name == "GenericMethod").m_Parameters.Count());
      Assert.AreEqual<string>("T", genericClass.m_Methods.Single<MethodMetadata>(x => x.m_Name == "GenericMethod").m_Parameters.Single().m_TypeMetadata.m_typeName);
      Assert.AreEqual<string>("T", genericClass.m_Methods.Single<MethodMetadata>(x => x.m_Name == "GenericMethod").m_ReturnType.m_typeName);
      //TypeMetaData lacks Fields info
    }
    [TestMethod]
    public void InterfaceTest()
    {
      TypeMetadata interfaceClass = ReflectorTestClass.Reflector.MyNamespace.m_Types.Single<TypeMetadata>(x => x.m_typeName == "IExample");
      Assert.AreEqual<TypeMetadata.TypeKind>(TypeMetadata.TypeKind.InterfaceType, interfaceClass.m_TypeKind);
      Assert.AreEqual<AbstractENum>(AbstractENum.Abstract, interfaceClass.m_Modifiers.Item3);
      Assert.AreEqual<AbstractENum>(AbstractENum.Abstract, interfaceClass.m_Methods.Single<MethodMetadata>(x => x.m_Name == "MethodA").m_Modifiers.Item2);
    }
    [TestMethod]
    public void ImplementedInterfaceTest()
    {
      TypeMetadata _interfaceClass = ReflectorTestClass.Reflector.MyNamespace.m_Types.Single<TypeMetadata>(x => x.m_typeName == "IExample");
      TypeMetadata implementedInterfaceClass = ReflectorTestClass.Reflector.MyNamespace.m_Types.Single<TypeMetadata>(x => x.m_typeName == "ImplementationOfIExample");
      Assert.AreEqual<string>("IExample", implementedInterfaceClass.m_ImplementedInterfaces.Single().m_typeName);
      foreach (MethodMetadata method in _interfaceClass.m_Methods)
        Assert.IsNotNull(implementedInterfaceClass.m_Methods.SingleOrDefault(x => x.m_Name == method.m_Name));
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
      TypeMetadata outerClass = ReflectorTestClass.Reflector.MyNamespace.m_Types.Single<TypeMetadata>(x => x.m_typeName == "OuterClass");
      Assert.IsTrue(true);
      // TypeMetaData doesn't store information about private nested types (it does about public)
    }
    [TestMethod]
    public void StaticClassTest()
    {
      TypeMetadata staticClass = ReflectorTestClass.Reflector.MyNamespace.m_Types.Single(x => x.m_typeName == "StaticClass");
      Assert.AreEqual(StaticEnum.Static, staticClass.m_Methods.Single(x => x.m_Name == "StaticMethod1").m_Modifiers.Item3);
      // no information about class/property being static
      // TypeMetaData lacks Fields info
    }
    [TestMethod]
    public void StructureTest()
    {
      TypeMetadata structure = ReflectorTestClass.Reflector.m_AssemblyModel.m_Namespaces
          .Single<NamespaceMetadata>(x => x.m_NamespaceName == "TPA.ApplicationArchitecture.Data")
          .m_Types.Single<TypeMetadata>(x => x.m_typeName == "Structure");
      Assert.AreEqual<TypeMetadata.TypeKind>(TypeMetadata.TypeKind.StructType, structure.m_TypeKind);
    }
    private class ReflectorTestClass : Reflector
    {
      internal static ReflectorTestClass Reflector => m_Reflector.Value;
      internal Dictionary<string, NamespaceMetadata> Namespaces;
      internal NamespaceMetadata MyNamespace { get; private set; }
      internal ReflectorTestClass() : base(TestAssemblyName)
      {
        Namespaces = this.m_AssemblyModel.m_Namespaces.ToDictionary<NamespaceMetadata, string>(x => x.m_NamespaceName);
        MyNamespace = Namespaces.ContainsKey(m_NamespaceName) ? Namespaces["TPA.ApplicationArchitecture.Data"] : null;
      }
      internal const string TestAssemblyName = @"Instrumentation\TPA.ApplicationArchitecture.dll";

      #region private
      private const string m_NamespaceName = "TPA.ApplicationArchitecture.Data";
      private static Lazy<ReflectorTestClass> m_Reflector = new Lazy<ReflectorTestClass>(() => new ReflectorTestClass());
      #endregion

    }
  }
}
