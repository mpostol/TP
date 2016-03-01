
using System;
using System.Collections;

namespace TP.Lecture
{
  public static class BasicTypesStruct
  {

    public struct CoOrdsStruct
    {
      public int x, y;
      internal CoOrdsStruct( int p1, int p2 )
      {
        x = p1;
        y = p2;
      }
    }
    public class CoOrdsClass
    {
      public int x, y;
      public CoOrdsClass( int p1, int p2 )
      {
        x = p1;
        y = p2;
      }
    }
    public static CoOrdsStruct GetCoOrdsStruct()
    {
      CoOrdsStruct _co; //no new example
      _co.x = 1;
      _co.y = 2;
      return _co;
    }
    public static CoOrdsStruct GetCoOrdsStruct( int p1, int p2 )
    {
      CoOrdsStruct _co = new CoOrdsStruct( p1, p2 );
      return _co;
    }

  }
}
