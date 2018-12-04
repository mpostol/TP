//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System;
using System.Reflection;
using TPA.ApplicationArchitecture.BusinessLogic;

namespace TPA.ApplicationArchitecture.Presentation
{
  internal class View
  {
    public View()
    {
      Console.WriteLine($"Starting View Rel {Assembly.GetExecutingAssembly().GetName().Version}");
    }

    private ViewModel ViewModel { get; set; }

  }
}
