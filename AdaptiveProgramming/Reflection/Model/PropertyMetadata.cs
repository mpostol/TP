
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace TPA.Reflection.Model
{
  internal class PropertyMetadata
  {

    internal static IEnumerable<PropertyMetadata> EmitProperties(IEnumerable<PropertyInfo> props)
    {
      return from prop in props
             where prop.GetGetMethod().GetVisible() || prop.GetSetMethod().GetVisible()
             select new PropertyMetadata(prop.Name, TypeMetadata.EmitReference(prop.PropertyType));
    }

    #region private
    private string m_Name;
    private TypeMetadata m_TypeMetadata;
    private PropertyMetadata(string propertyName, TypeMetadata propertyType)
    {
      m_Name = propertyName;
      m_TypeMetadata = propertyType;
    }
    #endregion

  }
}