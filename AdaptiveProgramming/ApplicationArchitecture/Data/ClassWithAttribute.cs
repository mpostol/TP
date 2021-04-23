//____________________________________________________________________________
//
//  Copyright (C) 2021, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System;

namespace TPA.ApplicationArchitecture.Data
{
  [Serializable]
  internal class ClassWithAttribute
  {

    [Obsolete]
    internal float FieldWithAttribute;

  }

}
