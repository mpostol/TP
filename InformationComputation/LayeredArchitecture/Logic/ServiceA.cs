//__________________________________________________________________________________________
//
//  Copyright 2022 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

using TP.InformationComputation.LayeredArchitecture.Logic.AbstractLayerInterface;

namespace TP.InformationComputation.LayeredArchitecture.Logic
{
  /// <summary>
  /// Class ServiceA - an example of the indirect circular reference (recursion) at design time
  /// </summary>
  internal class ServiceA : IService
  {
    public ServiceA(ServiceB? serviceB)
    {
      Service = serviceB;
    }

    public IService? Service { get; set; }
  }
}