//____________________________________________________________________________
//
//  Copyright (C) Year of Copyright, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System.Collections.Generic;

namespace TP.StructuralData.Data
{
  public interface IPerson
  {
    ushort Age { get; }
    string FirstName { get; }
    string LastName { get; }
    IEnumerable<ICDCatalog> CDs { get; }

  }
}