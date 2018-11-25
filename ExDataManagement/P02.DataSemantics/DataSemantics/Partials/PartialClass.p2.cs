//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________


namespace TP.DataSemantics.Partials
{
  //[System.ObsoleteAttribute]
  public partial class PartialClass : IPartialInterface
  {

    public void MethodPart2()
    {
      throw new System.NotImplementedException();
    }
    partial void PartialMethod()
    {
      throw new System.NotImplementedException();
    }

  }
}
