//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

namespace TP.DataSemantics.TypeConcept
{

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
      CoordinatesStruct _co; //no new example
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
