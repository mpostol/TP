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