//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2023, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//  by introducing yourself and telling us what you do with this community.
//_____________________________________________________________________________________________________________________________________

namespace TPA.ApplicationArchitecture.BusinessLogic
{
  /// <summary>
  /// Class ServiceB - an example of the indirect circular (recursion) reference at design time
  /// </summary>
  internal class ServiceB
  {
    public ServiceC ServiceC { get; set; }
  }
}