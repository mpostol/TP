
using System;
using System.Reflection;
using TPA.ApplicationArchitecture.BusinessLogic;

namespace TPA.ApplicationArchitecture.Presentation
{
    class View
  {
    public View()
    {
      Console.WriteLine($"Starting View Rel {Assembly.GetExecutingAssembly().GetName().Version}");
    }

    ViewModel ViewModel { get; set; }

  }
}
