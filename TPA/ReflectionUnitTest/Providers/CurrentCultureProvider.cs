using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppResources.Interfaces;

namespace TPA.Reflection.UnitTest.Providers
{
    public class CurrentCultureProvider : ICultureInfoProvider
    {
        public CultureInfo RequestedCulture => CultureInfo.CurrentCulture;
    }
}
