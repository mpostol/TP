using System;
using System.ComponentModel;

namespace TPA.Configuration
{
  [Serializable]
  public class CustomSettings: TypeConverter
  {
    public int ParameterInt { get; set; }
    public float ParameterFload { get; set; }
  }
}
