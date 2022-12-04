//__________________________________________________________________________________________
//
//  Copyright 2022 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

namespace TP.InformationComputation.CustomTypes
{
  [TestClass]
  public class CoordinatesTest
  {
    [TestMethod]
    public void ValueTypeTest()
    {
      //CoordinatesStruct noValue = null;
      CoordinatesStruct coordinate1 = CoordinatesStruct.GetCoordinates(1, 2);
      CoordinatesStruct coordinate2 = CoordinatesStruct.GetCoordinates(1, 2);
      CoordinatesNoChange(coordinate1);
      Assert.AreEqual(coordinate1, coordinate2);
      Assert.AreEqual(coordinate1.x, coordinate2.x);
      Assert.AreEqual(coordinate1.y, coordinate2.y);
      CoordinatesChange(ref coordinate1);
      Assert.AreNotEqual(coordinate1, coordinate2);
      Assert.AreNotEqual(coordinate1.x, coordinate2.x);
      Assert.AreNotEqual(coordinate1.y, coordinate2.y);
    }

    [TestMethod]
    public void ReferenceTypeTest()
    {
      CoordinatesClass? noValue = null;
      Assert.IsNull(noValue);
      CoordinatesClass coordinateReference1 = new CoordinatesClass(1, 2);
      CoordinatesClass coordinateReference2 = new CoordinatesClass(1, 2);
      Assert.AreEqual(coordinateReference1.x, coordinateReference2.x);
      Assert.AreEqual(coordinateReference1.y, coordinateReference2.y);
      Assert.AreNotEqual(coordinateReference1, coordinateReference2);
      Assert.AreNotSame(coordinateReference1, coordinateReference2);
      CoordinatesChange(coordinateReference1);
      Assert.AreNotEqual(coordinateReference1.x, coordinateReference2.x);
      Assert.AreNotEqual(coordinateReference1.y, coordinateReference2.y);
    }

    #region instrumentation

    private static Random RandomGenerator = new Random(DateTime.Now.Millisecond);

    private static void CoordinatesNoChange(CoordinatesStruct coordinates)
    {
      coordinates.x = RandomGenerator.Next();
      coordinates.y = RandomGenerator.Next();
    }

    private static void CoordinatesChange(ref CoordinatesStruct coordinates)
    {
      coordinates.x = RandomGenerator.Next();
      coordinates.y = RandomGenerator.Next();
    }

    private static void CoordinatesChange(CoordinatesClass coordinates)
    {
      coordinates.x = RandomGenerator.Next();
      coordinates.y = RandomGenerator.Next();
    }

    #endregion instrumentation
  }
}