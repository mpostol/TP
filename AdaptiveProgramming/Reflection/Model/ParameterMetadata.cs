
namespace TPA.Reflection.Model
{
  internal class ParameterMetadata
  {

    public ParameterMetadata(string name, TypeMetadata typeMetadata)
    {
      this.m_Name = name;
      this.m_TypeMetadata = typeMetadata;
    }
    
    //private vars
    internal string m_Name;
    internal TypeMetadata m_TypeMetadata;

  }
}