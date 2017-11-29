using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace TPA.Reflection.DynamicType
{
    public static class DemoTypeBuilder
    {
        public static object CreateInstanceWithPublicField()
        {
            //specify name of dynamic assembly
            AssemblyName assemblyName = new AssemblyName("DemoAssembly");
            //define dynamic assembly
            AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.RunAndSave);
            //define module for specified assembly
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule(assemblyName.Name, assemblyName.Name + ".dll");
            //define a public type in specified module
            TypeBuilder typeBuilder = moduleBuilder.DefineType("DemoType", TypeAttributes.Public);
            //define a public field in specified type
            FieldBuilder fieldBuilder = typeBuilder.DefineField("m_number", typeof(int), FieldAttributes.Public);
            //load Type object for defined type
            Type type = typeBuilder.CreateType();
            //save assembly on disk
            assemblyBuilder.Save(assemblyName.Name + ".dll");
            //return instance of created type
            return Activator.CreateInstance(type);
        }

        public static object CreateInstanceWithPublicFieldAndDefaultConstructor()
        {
            AssemblyName assemblyName = new AssemblyName("DemoAssembly2");
            AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.RunAndSave);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule(assemblyName.Name, assemblyName.Name + ".dll");
            TypeBuilder typeBuilder = moduleBuilder.DefineType("DemoType2", TypeAttributes.Public);
            FieldBuilder fieldBuilder = typeBuilder.DefineField("m_number", typeof(int), FieldAttributes.Public);

            //define default constructor
            ConstructorBuilder ctor1 = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, Type.EmptyTypes);
            ILGenerator ctor1IL = ctor1.GetILGenerator();
            //push reference to the new instance on the stack
            ctor1IL.Emit(OpCodes.Ldarg_0);
            //call the base class constructor
            ctor1IL.Emit(OpCodes.Call, typeof(object).GetConstructor(Type.EmptyTypes));
            //push the instance on the stack
            ctor1IL.Emit(OpCodes.Ldarg_0);
            //push the default field value on the stack
            ctor1IL.Emit(OpCodes.Ldc_I4_S, 7);
            //assign pushed value to the field
            ctor1IL.Emit(OpCodes.Stfld, fieldBuilder);
            ctor1IL.Emit(OpCodes.Ret);

            Type type = typeBuilder.CreateType();
            assemblyBuilder.Save(assemblyName.Name + ".dll");
            return Activator.CreateInstance(type);
        }

        public static object CreateInstanceWithNonDefaultConstructorAndPublicPropertyAndPrivateField()
        {
            AssemblyName assemblyName = new AssemblyName("DemoAssembly3");
            AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.RunAndSave);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule(assemblyName.Name, assemblyName.Name + ".dll");
            TypeBuilder typeBuilder = moduleBuilder.DefineType("DemoType3", TypeAttributes.Public);
            FieldBuilder fieldBuilder = typeBuilder.DefineField("m_number", typeof(int), FieldAttributes.Private);

            //define a non-default constructor with parameters
            Type[] parameterTypes = { typeof(int) };
            ConstructorBuilder ctor1 = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, parameterTypes);
            ILGenerator ctor1IL = ctor1.GetILGenerator();
            ctor1IL.Emit(OpCodes.Ldarg_0);
            ctor1IL.Emit(OpCodes.Call, typeof(object).GetConstructor(Type.EmptyTypes));
            ctor1IL.Emit(OpCodes.Ldarg_0);
            //push the provided argument value on the stack
            ctor1IL.Emit(OpCodes.Ldarg_1);
            ctor1IL.Emit(OpCodes.Stfld, fieldBuilder);
            ctor1IL.Emit(OpCodes.Ret);

            //define a property named MyNumber which gets and sets the private field m_number
            PropertyBuilder propertyBuilder = typeBuilder.DefineProperty("MyNumber", PropertyAttributes.HasDefault, typeof(int), null);
            //define the getter and setter methods
            MethodAttributes attributes = MethodAttributes.Public |
                MethodAttributes.SpecialName | MethodAttributes.HideBySig;
            MethodBuilder getterMethodBuilder = typeBuilder.DefineMethod(
                "get_MyNumber",
                attributes,
                typeof(int),
                Type.EmptyTypes);
            ILGenerator getterIL = getterMethodBuilder.GetILGenerator();
            getterIL.Emit(OpCodes.Ldarg_0);
            //push the field value to the stack
            getterIL.Emit(OpCodes.Ldfld, fieldBuilder);
            //return the field value which has been pushed to the stack
            getterIL.Emit(OpCodes.Ret);
            MethodBuilder setterMethodBuilder = typeBuilder.DefineMethod(
                "set_MyNumber",
                attributes,
                null,
                new Type[] { typeof(int) });
            ILGenerator setterIL = setterMethodBuilder.GetILGenerator();
            setterIL.Emit(OpCodes.Ldarg_0);
            //push the argument value to the stack
            setterIL.Emit(OpCodes.Ldarg_1);
            //store the pushed value in the field
            setterIL.Emit(OpCodes.Stfld, fieldBuilder);
            setterIL.Emit(OpCodes.Ret);
            //set the getter and setter methods
            propertyBuilder.SetGetMethod(getterMethodBuilder);
            propertyBuilder.SetSetMethod(setterMethodBuilder);


            Type type = typeBuilder.CreateType();
            assemblyBuilder.Save(assemblyName.Name + ".dll");
            return Activator.CreateInstance(type, new object[] { 66 });
        }

        public static object CreateInstanceWithPublicMethod()
        {
            AssemblyName assemblyName = new AssemblyName("DemoAssembly4");
            AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.RunAndSave);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule(assemblyName.Name, assemblyName.Name + ".dll");
            TypeBuilder typeBuilder = moduleBuilder.DefineType("DemoType4", TypeAttributes.Public);

            //define a public method which returns its integer argument incremented
            MethodBuilder methodBuilder = typeBuilder.DefineMethod(
                "MyMethod",
                MethodAttributes.Public,
                typeof(int),
                new Type[] {typeof(int)});
            ILGenerator myMethodIL = methodBuilder.GetILGenerator();
            //push the argument value on the stack
            myMethodIL.Emit(OpCodes.Ldarg_1);
            //push the value 1 on the stack
            myMethodIL.Emit(OpCodes.Ldc_I4_S, 1);
            //add these two values
            myMethodIL.Emit(OpCodes.Add);
            //return the result
            myMethodIL.Emit(OpCodes.Ret);
            

            Type type = typeBuilder.CreateType();
            assemblyBuilder.Save(assemblyName.Name + ".dll");
            return Activator.CreateInstance(type);
        }

    }
}
