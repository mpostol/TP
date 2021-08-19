//__________________________________________________________________________________________
//
//  Copyright 2021 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

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