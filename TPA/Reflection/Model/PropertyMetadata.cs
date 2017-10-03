
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace TPA.Reflection.Model
{
  internal class PropertyMetadata
  {
    private string name;
    private TypeMetadata typeMetadata;

    private PropertyMetadata(string propertyName, TypeMetadata propertyType)
    {
      this.name = propertyName;
      this.typeMetadata = propertyType;
    }
    internal static IEnumerable<PropertyMetadata> EmitProperties(IEnumerable<PropertyInfo> props)
    {
      return from prop in props
             where prop.GetGetMethod().GetVisible() || prop.GetSetMethod().GetVisible()
             select new PropertyMetadata(prop.Name, TypeMetadata.EmitReference(prop.PropertyType));
    }

  }
}