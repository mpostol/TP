//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2024, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//  by introducing yourself and telling us what you do with this community.
//_____________________________________________________________________________________________________________________________________

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

    /// <summary>
    /// The perform calculation variable
    /// </summary>
    /// <returns>System.Int32.</returns>
    public PerformCalculation PerformCalculationVar = null;

    /// <summary>
    /// An example of event
    /// </summary>
    public event EventHandler PerformSumMethodCalled;

    /// <summary>
    /// Initializes a new instance of the <see cref="DelegateExample"/> class.
    /// </summary>
    public DelegateExample()
    {
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