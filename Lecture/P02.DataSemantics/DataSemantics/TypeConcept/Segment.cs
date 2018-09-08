//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

namespace TP.DataSemantics.TypeConcept
{
  public class Segment : CoordinatesClass
  {
    public Segment NextSegment { get; set; } = null;
    public Segment(int x, int y) : base(x, y) { }

  }
}
