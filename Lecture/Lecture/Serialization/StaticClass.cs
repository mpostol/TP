namespace TP.Lecture.Serialization
{
  /// <summary>
  /// Class StaticClass - demonstrates:
  ///   - initialization issues for static class
  ///   - castom serialization
  ///   - state representation
  ///   - API representation
  /// </summary>
  public static class StaticClass//: ISerializable - Error CS0714  'StaticClass': static classes cannot implement interfaces

  {

    //Initialization:

    /// <summary>
    /// Error CS0710  Static classes cannot have instance constructors
    /// </summary>
    /// <param name="x">The x.</param>
    //public StaticClass(){}
    /// <summary>
    /// Error CS0132	'StaticClass.StaticClass(double)': a static constructor must be parameterless  
    /// </summary>
    //static StaticClass (double x)
    //{

    //}
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
    public static double AnyOperationOnLocalFields()
    {
      return (m_Field11 + m_Field12) / 2;
    }

    #region static
    private static double m_Field11 = 0;
    private static double m_Field12 = 0;
    #endregion
  }
}
