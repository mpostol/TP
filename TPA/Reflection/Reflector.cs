
using System.Reflection;
using TPA.Reflection.Model;

namespace TPA.Reflection
{
  public class Reflector
  {

    internal AssemblyMetadata document { get; set; }

    public void Reflect(string assemblyFile)
    {
      Assembly assembly = Assembly.LoadFrom(assemblyFile);
      document = AssemblyMetadata.EmitAssembly(assembly);
    }
    public void Reflect(Assembly assembly)
    {
      document = AssemblyMetadata.EmitAssembly(assembly);
    }
  }
}
