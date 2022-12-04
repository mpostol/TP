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
  /// <summary>
  /// An example of the value type
  /// </summary>
  public struct CoordinatesStruct
  {
    public int x, y;

    internal CoordinatesStruct(int p1, int p2)
    {
      x = p1;
      y = p2;
    }

    public static CoordinatesStruct GetCoordinates()
    {
      CoordinatesStruct _co; //no new example but value exist
      _co.x = 1;
      _co.y = 2;
      return _co;
    }

    public static CoordinatesStruct GetCoordinates(int p1, int p2)
    {
      CoordinatesStruct _co = new CoordinatesStruct(p1, p2);
      return _co;
    }
  }

  /// <summary>
  /// An example of the reference type
  /// </summary>
  public class CoordinatesClass
  {
    public int x, y;

    public CoordinatesClass(int p1, int p2)
    {
      x = p1;
      y = p2;
    }

    public static CoordinatesClass GetCoordinates(int p1, int p2)
    {
      CoordinatesClass _co = new CoordinatesClass(p1, p2);
      return _co;
    }
  }
}