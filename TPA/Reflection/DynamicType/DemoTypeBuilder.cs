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
        public static object createInstance()
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
    }
}
