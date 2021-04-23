//___________________________________________________________________________________
//
//  Copyright (C) 2021, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

namespace TPA.ApplicationArchitecture.Data.API
{
  /// <summary>
  /// Class ILinq2SQL - an example of the abstract API of the Data layer
  /// </summary>
  public abstract class ILinq2SQL
  {
    /// <summary>
    /// A place holder to implement the connection functionality.
    /// </summary>
    public abstract void Connect();

    /// <summary>
    /// A factory method to provide new instance of the <see cref="ILinq2SQL"/>.
    /// </summary>
    /// <returns>ILinq2SQL.</returns>
    public static ILinq2SQL CreateLinq2SQL()
    {
      return new Linq2SQL();
    }
  }
}