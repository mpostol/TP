//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2023, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//  by introducing yourself and telling us what you do with this community.
//_____________________________________________________________________________________________________________________________________

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
      Assembly assembly = Assembly.ReflectionOnlyLoadFrom(assemblyFile);
      m_AssemblyModel = new AssemblyMetadata(assembly);
    }

    public Reflector(Assembly assembly)
    {
      m_AssemblyModel = new AssemblyMetadata(assembly);
    }

    internal AssemblyMetadata m_AssemblyModel { get; private set; }
  }
}