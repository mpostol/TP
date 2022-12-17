//__________________________________________________________________________________________
//
//  Copyright 2022 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//
//  path: TP\InformationComputation\ObjectOrientedProgramming\DiamondPattern.cs
//__________________________________________________________________________________________

namespace TP.InformationComputation.ObjectOrientedProgramming
{
  /// <summary>
  /// In this example of classes, a diamond pattern has been implemented as a set of classes. Check out the unit tests to learn how the diamond graph of objects is instantiated at run time. 
  /// Not always objects structures at the run time must be exactly the same as a structures of classes related to each other. 
  /// </summary>
  /// <remarks>
  /// 
  ///    Top
  ///    /  \
  /// Left  Right
  ///    \  /
  ///   Bottom
  ///
  ///</remarks>
  public class Top
  {
    public Top(Left leftEntity, Right rightEntity)
    {
      LeftEntity = leftEntity;
      RightEntity = rightEntity;
    }

    public Left LeftEntity { get; set; }
    public Right RightEntity { get; set; }
  }

  public class Left
  {
    public Left(Bottom bottomEntity)
    {
      BottomEntity = bottomEntity;
    }

    public Bottom BottomEntity { get; set; }
  }

  public class Right
  {
    public Right(Bottom bottomEntity)
    {
      BottomEntity = bottomEntity;
    }

    public Bottom BottomEntity { get; set; }
  }

  public class Bottom
  {
  }
}