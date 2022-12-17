//__________________________________________________________________________________________
//
//  Copyright 2022 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

#nullable disable
namespace TP.InformationComputation.ObjectOrientedProgramming
{
  [TestClass]
  public class SegmentTest
  {
    [TestMethod]
    public void SegmentTestMethod()
    {
      // first -> Segment[0, 0]
      Segment first = new Segment(0, 0, null);
      Assert.IsNotNull(first);
      Assert.AreEqual(0, first.x);
      Assert.AreEqual(0, first.y);
      Assert.IsNull(first.NextSegment);
      // first -> Segment[1, 1] -> Segment[0, 0]
      first = new Segment(1, 1, first);
      Assert.IsNotNull(first);
      Assert.AreEqual(1, first.x);
      Assert.AreEqual(1, first.y);
      Assert.IsNotNull(first.NextSegment);
      Assert.AreEqual(0, first.NextSegment.y);
      Assert.AreEqual(0, first.NextSegment.y);
      Assert.IsNull(first.NextSegment.NextSegment);
    }
  }
}
#nullable restore
