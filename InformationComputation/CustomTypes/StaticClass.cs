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
  /// Class StaticClass - demonstrates:
  ///   - initialization issues for static class
  ///   - custom serialization
  ///   - state representation
  ///   - API representation
  /// </summary>
  public static class StaticClass//: ISerializable - 'StaticClass': static classes cannot implement interfaces
  {
    //Initialization:

    /// <summary>
    /// Static classes cannot have instance constructors
    /// </summary>
    //public StaticClass() { }

    /// <summary>
    /// 'StaticClass.StaticClass(double)': a static constructor must be parameterless
    /// </summary>
    //static StaticClass(double x) { }

    /// <summary>
    /// It is called automatically before any member is referenced. A static constructor is used to initialize any static data, 
    /// or to perform a particular action that needs to be performed only once.
    /// </summary>
    static StaticClass()
    {
      MaxIncome = 987654.321;
      MinIncome = 123456.789;
    }

    /// <summary>
    /// Static initializer of the class.
    /// </summary>
    /// <param name="MaxIncome">The maximum income.</param>
    /// <param name="MinIncome">The minimum income.</param>
    public static void StaticClassInitializer(double maxIncome, double minIncome)
    {
      MaxIncome = maxIncome;
      MinIncome = minIncome;
    }

    /// <summary>
    /// Gets or sets the maximum income.
    /// </summary>
    /// <value>The maximum income.</value>
    public static double MaxIncome { get; set; }

    /// <summary>
    /// Gets or sets the minimum income.
    /// </summary>
    /// <value>The minimum income.</value>
    public static double MinIncome { get; set; }

    /// <summary>
    /// Gets the average income.
    /// </summary>
    /// <value>The average income.</value>
    public static double AverageIncome
    {
      get { return (MaxIncome + MinIncome) / 2; }
    }
  }
}