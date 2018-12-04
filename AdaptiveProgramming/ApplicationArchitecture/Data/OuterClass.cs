//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

namespace TPA.ApplicationArchitecture.Data
{
  public class OuterClass
  {
    private class InnerClass
    {
      public int InnerProperty { get; set; }
    }

    private readonly InnerClass InnerClassInstance;

  }
}
