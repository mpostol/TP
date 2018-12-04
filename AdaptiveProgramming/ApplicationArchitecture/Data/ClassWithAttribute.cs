//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System;

namespace TPA.ApplicationArchitecture.Data
{
  [Serializable]
  public class ClassWithAttribute
  {

    [Obsolete]
    public float FieldWithAttribute;

  }

}
