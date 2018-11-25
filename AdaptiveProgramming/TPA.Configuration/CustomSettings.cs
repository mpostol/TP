using System;
using System.ComponentModel;
using System.Globalization;

namespace TPA.Configuration
{
  [TypeConverter(typeof(CustomSettingsConverter))]
  public class CustomSettings
  {
    public int ParameterInt { get; set; }
    public float ParameterFload { get; set; }
  }

  public class CustomSettingsConverter : TypeConverter
  {
    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
      return base.ConvertFrom(context, culture, value);
    }
    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      return base.ConvertTo(context, culture, value, destinationType);
    }
    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    {
      return true;
    }
    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
    {
      return true;
    }
    public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
    {
      return base.GetStandardValues(context);
    }
    public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
    {
      return false;
    }
  }
}
