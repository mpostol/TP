//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System;

namespace TP.Lecture.LessonExtensionMethods
{

  /// <summary>
  /// Class ExtensionMethods - defines a few extension methods.
  /// </summary>
  public static class ExtensionMethods
  {

    /// <summary>
    /// Counts words in <paramref name="str"/>.
    /// </summary>
    /// <param name="str">The string to be analyzed.</param>
    /// <returns>Number of word in the string as <see cref="System.Int32"/>.</returns>
    public static int WordCount(this string str)
    {
      return str.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
    }
    /// <summary>
    /// Determines if the <paramref name="i"/> is even number.
    /// </summary>
    /// <param name="i">The value to be processed.</param>
    /// <returns><c>true</c> if <paramref name="i"/> is even number, <c>false</c> otherwise.</returns>
    public static bool Even(this int i)
    {
      return i % 2 == 0;
    }
    /// <summary>
    /// Determines whether the specified <paramref name="value"/> object occurs within the <paramref name="sourceString" />.
    /// </summary>
    /// <param name="sourceString">The source string.</param>
    /// <param name="value">The string to seek.</param>
    /// <returns><c>true</c> if the value parameter occurs within this <paramref name="value" />, or if the <paramref name="value" /> is the empty string (""); otherwise, <c>false</c>.</returns>
    /// <exception cref="System.NotImplementedException">An extension method with the same name and signature as an interface or class method will never be called</exception>
    public static bool Contains(this string sourceString, string value)
    {
      throw new NotImplementedException("An extension method with the same name and signature as an interface or class method will never be called");
    }
    /// <summary>
    /// Allows calling the <see cref="IMyInterface.MyInterfaceMethod"/> method against the null reference.
    /// </summary>
    /// <param name="myInterface">An instance of the <see cref="IMyInterface"/>.</param>
    /// <exception cref="ArgumentNullException"> - it the <paramref name="myInterface"/> is null.</exception>
    public static void ProtectedMyInterfaceMethodCall(this IMyInterface myInterface)
    {
      if (myInterface == null)
        throw new ArgumentNullException($"{nameof(myInterface)} cannot be null.");
      myInterface.MyInterfaceMethod();
    }

  }

}

