using System;

namespace TP.Lecture.LessonExtensionMethods
{
  public static class ExtensionMethods
  {

    public static int WordCount(this String str)
    {
      return str.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
    }
    public static int MethodA(this int i)
    {
      return -i;
    }
    /// <summary>
    /// Determines whether [contains] [the specified value].
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns><c>true</c> if [contains] [the specified value]; otherwise, <c>false</c>.</returns>
    /// <exception cref="System.NotImplementedException">Existing method cannot be override</exception>
    public static bool Contains(this String value)
    {
      throw new NotImplementedException("Existing method cannot be override");
    }
    public static int MethodA(this IMyInterface myInterface, int i)
    {
      return -i;
    }

    public static string MethodA(this IMyInterface myInterface, string s)
    {
      return $"s={s}";
    }
  }
  /// <summary>
  /// Define an interface named IMyInterface.
  /// </summary>
  public interface IMyInterface
  {
    // Any class that implements IMyInterface must define a method
    // that matches the following signature.
    void MethodB();
  }
  //public class A : IMyInterface
  //{

  //}
  public class B : IMyInterface
  {
    public void MethodB()
    {
      throw new NotImplementedException();
    }
    public int MethodA(int i) { return -i; }
  }
  public class C : IMyInterface
  {
    public void MethodB()
    {
      throw new NotImplementedException();
    }
    public object MethodA(object obj)
    {
      return obj;
    }
  }
}

