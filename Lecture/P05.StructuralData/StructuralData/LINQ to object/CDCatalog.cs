//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

namespace TP.StructuralData.LINQ_to_object
{
  public partial class CDCatalog : ICDCatalog
  {

    public int Id { get; set; }
    public string Title { get; set; }
    public string Country { get; set; }
    public decimal Price { get; set; }
    public ushort Year { get; set; }
    public Person Person { get; set; }
  }
}
