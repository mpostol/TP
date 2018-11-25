
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
    private string m_Name;
    private TypeMetadata m_TypeMetadata;

  }
}