//__________________________________________________________________________________________
//
//  Copyright 2022 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

namespace TP.InformationComputation.ObjectOrientedProgramming
{
  public class Segment : CoordinatesClass
  {
    public Segment NextSegment { get; set; }

    public Segment(int x, int y) : base(x, y)
    { 
      NextSegment = this;
    }
  }

  public class CoordinatesClass
  {
    public int x, y;

    public CoordinatesClass(int p1, int p2)
    {
      x = p1;
      y = p2;
    }
  }
}