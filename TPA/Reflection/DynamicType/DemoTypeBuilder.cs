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
        public static object createInstanceWithPublicField()
        {
            //specify name of dynamic assembly
            AssemblyName assemblyName = new AssemblyName("DemoAssembly");
            //create dynamic assembly
            AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.RunAndSave);
            //create module for specified assembly
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule(assemblyName.Name, assemblyName.Name + ".dll");
            //create a public type in specified module
            TypeBuilder typeBuilder = moduleBuilder.DefineType("DemoType", TypeAttributes.Public);
            //create a public field in specified type
            FieldBuilder fieldBuilder = typeBuilder.DefineField("number", typeof(int), FieldAttributes.Public);
            //load Type object for created type
            Type type = typeBuilder.CreateType();
            //save assembly on disk
            assemblyBuilder.Save(assemblyName.Name + ".dll");
            //return instance of created type
            return Activator.CreateInstance(type);
        }

        public static object createInstanceWithPublicFieldAndDefaultConstructor()
        {
            AssemblyName assemblyName = new AssemblyName("DemoAssembly2");
            AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.RunAndSave);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule(assemblyName.Name, assemblyName.Name + ".dll");
            TypeBuilder typeBuilder = moduleBuilder.DefineType("DemoType2", TypeAttributes.Public);
            FieldBuilder fieldBuilder = typeBuilder.DefineField("number", typeof(int), FieldAttributes.Public);
            
            Type[] parameterTypes = { typeof(int) };
            ConstructorBuilder ctor1 = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, parameterTypes);
            ILGenerator ctor1IL = ctor1.GetILGenerator();
            //push reference to the new instance on stack
            ctor1IL.Emit(OpCodes.Ldarg_0);
            ctor1IL.Emit(OpCodes.Call, typeof(object).GetConstructor(Type.EmptyTypes));
            //push the instance on stack
            ctor1IL.Emit(OpCodes.Ldarg_0);
            //push the argument on stack
            ctor1IL.Emit(OpCodes.Ldarg_1);
            //assign pushed value to the field
            ctor1IL.Emit(OpCodes.Stfld, fieldBuilder);
            ctor1IL.Emit(OpCodes.Ret);

            ConstructorBuilder ctor2 = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, Type.EmptyTypes);
            ILGenerator ctor2IL = ctor2.GetILGenerator();
            //push reference to the new instance on stack
            ctor2IL.Emit(OpCodes.Ldarg_0);
            //push default valueof the field
            ctor2IL.Emit(OpCodes.Ldc_I4_S, 7);
            //call parametrized contructor ctor1
            ctor2IL.Emit(OpCodes.Call, ctor1);
            ctor2IL.Emit(OpCodes.Ret);

            Type type = typeBuilder.CreateType();
            assemblyBuilder.Save(assemblyName.Name + ".dll");
            return Activator.CreateInstance(type);
        }

    }
}
