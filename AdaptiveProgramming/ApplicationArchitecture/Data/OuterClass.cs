//____________________________________________________________________________
//
//  Copyright (C) 2021, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

namespace TPA.ApplicationArchitecture.Data
{
  internal class OuterClass
  {
    internal class InnerClass
    {
      internal int InnerProperty { get; set; }
    }

    private readonly InnerClass InnerClassInstance;
  }
}