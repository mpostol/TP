
using System.Reflection;
using TPA.Reflection.Model;

namespace TPA.Reflection
{
    public class Reflector
    {

        public AssemblyMetadata m_AssemblyModel { get; private set; }

        public void Reflect(string assemblyFile)
        {
            Assembly assembly = Assembly.LoadFrom(assemblyFile);
            m_AssemblyModel = new AssemblyMetadata(assembly);
        }

        public void Reflect(Assembly assembly)
        {
            m_AssemblyModel = new AssemblyMetadata(assembly);
        }
    }
}
