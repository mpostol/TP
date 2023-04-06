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