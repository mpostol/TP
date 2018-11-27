//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System;
using System.Diagnostics;
using System.Reflection.Emit;

namespace TPA.Reflection.CodeGeneration
{
  public class DynamicMethodFactory
  {

    #region public
    /// <summary>
    /// Initializes a new instance of the <see cref="DynamicMethodFactory"/> class.
    /// </summary>
    public DynamicMethodFactory()
    {
      // Create an array that specifies the parameter types for the dynamic method. In this example the only parameter is an int, so the array has only one element.
      Type[] _methodArgs = { typeof(int) };
      // Create a DynamicMethod. In this example the method is named SquareIt. It is not necessary to give dynamic 
      // methods names. They cannot be invoked by name, and two dynamic methods can have the same name. However, the 
      // name appears in calls stacks and can be useful for debugging. 
      //
      // In this example the return type of the dynamic method is long. The method is associated with the module that 
      // contains the Example class. Any loaded module could be specified. The dynamic method is like a module-level
      // static method.
      DynamicMethod squareIt = new DynamicMethod("SquareIt", typeof(long), _methodArgs, typeof(DynamicMethodFactory).Module);
      // Emit the method body. In this example ILGenerator is used to emit the MSIL. DynamicMethod has an associated type DynamicILInfo that can be used in conjunction with 
      // unmanaged code generators.
      //
      // The MSIL loads the argument, which is an int, onto the stack, converts the int to a long, duplicates the top item on the stack, and multiplies the top two items on the
      // stack. This leaves the squared number on the stack, and all the method has to do is return.
      ILGenerator il = squareIt.GetILGenerator();
      il.Emit(OpCodes.Ldarg_0);
      il.Emit(OpCodes.Conv_I8);
      il.Emit(OpCodes.Dup);
      il.Emit(OpCodes.Mul);
      il.Emit(OpCodes.Ret);
      // Create a delegate that represents the dynamic method. Creating the delegate completes the method, and any further  attempts to change the method (for example, by adding more
      // MSIL) are ignored. The following code uses a generic delegate that can produce delegate types matching any single-parameter method that has a return type.
      //
      m_InvokeSquareIt = (SquareItInvoker)squareIt.CreateDelegate(typeof(SquareItInvoker));
    }
    /// <summary>
    /// Calls the dynamic method.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>System.Int64.</returns>
    public long DynamicMethodCall(int value)
    {
      return m_InvokeSquareIt(value);
    }
    #endregion

    #region private
    /// <summary>
    /// Declare delegates that can be used to execute the completed SquareIt dynamic method.
    /// </summary>
    /// <param name="input">The input.</param>
    /// <returns>System.Int64.</returns>
    private delegate long SquareItInvoker(int input);
    private readonly SquareItInvoker m_InvokeSquareIt;
    #endregion

    #region UT Instrumentation
    [Conditional("DEBUG")]
    internal void TestConsitency(Action<bool> returnValue)
    {
      returnValue(m_InvokeSquareIt != null);
    }
    #endregion

  }

}
