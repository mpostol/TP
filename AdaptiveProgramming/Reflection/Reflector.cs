
using System.Reflection;
using TPA.Reflection.Model;

namespace TPA.Reflection
{
  //TODO add UT - testing data is required
  public class Reflector
  {
    public Reflector(string assemblyFile)
    {
      if (string.IsNullOrEmpty(assemblyFile))
        throw new System.ArgumentNullException();
      Assembly assembly = Assembly.LoadFrom(assemblyFile);
      m_AssemblyModel = new AssemblyMetadata(assembly);
    }
    public Reflector(Assembly assembly)
    {
      m_AssemblyModel = new AssemblyMetadata(assembly);
    }
    internal AssemblyMetadata m_AssemblyModel { get; private set; }

  }
}
