//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using System;

namespace TPD.AsynchronousProgramming
{
  public class InstanceCreationCompletedEventArgs<type> : EventArgs
  {
    public type Result { get; internal set; }

    public InstanceCreationCompletedEventArgs(type instance)
    {
      Result = instance;
    }
  }
}