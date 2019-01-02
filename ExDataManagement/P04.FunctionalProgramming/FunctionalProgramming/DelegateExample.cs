//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System;

namespace TP.FunctionalProgramming
{

  public class DelegateExample
  {

    /// <summary>
    /// Delegate PerformCalculation - the declaration of a delegate type 
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    public delegate int PerformCalculation(int x, int y);
    public event EventHandler PerformSumMethodCalled;
    /// <summary>
    /// The perform calculation variable
    /// </summary>
    /// <returns>System.Int32.</returns>
    public PerformCalculation PerformCalculationVar;
    /// <summary>
    /// Initializes a new instance of the <see cref="DelegateExample"/> class.
    /// </summary>
    public DelegateExample()
    {
      PerformCalculationVar = new PerformCalculation(PerformSumMethod);
      PerformCalculationVar = new PerformCalculation(PerformSubtractMethod);
      //PerformCalculationVar = new PerformCalculation(PerformSubtractDoubleMethod); //No overload for 'DelegateExample.PerformSubtractDoubleMethod(double, double)' matches delegate 'DelegateExample.PerformCalculation'
    }
    public int PerformCalculationMethod(int x, int y)
    {
      return (PerformCalculationVar?.Invoke(x, y)).GetValueOrDefault();
    }
    public int PerformSumMethod(int x, int y)
    {
      PerformSumMethodCalled?.Invoke(this, System.EventArgs.Empty);
      checked { return x + y; }
    }
    public double PerformSumMethod(double x, double y)
    {
      checked { return x + y; }
    }
    public static int PerformSubtractMethod(int x, int y)
    {
      checked { return x - y; }
    }
    public static double PerformSubtractDoubleMethod(double x, double y)
    {
      checked { return x - y; }
    }

  }
}
