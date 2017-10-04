
using System.ComponentModel;
using AppResources;
using AppResources.Interfaces;

namespace TPA.Reflection
{
    public class LocalizedDescriptionAttribute : DescriptionAttribute
    {
        public static IAppResourcesProxy ResourcesProxy { get; set; } = new DefaultAppResourcesProxy();

        public string LocalizationKey { get;}

        public LocalizedDescriptionAttribute(string description) 
            : base(ResourcesProxy.GetString(description))
        {
            LocalizationKey = description;
        }
    }
}
