//__________________________________________________________________________________________
//
//  Copyright 2022 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

using TP.InformationComputation.ObjectOrientedProgramming.Instrumentation;

namespace TP.InformationComputation.ObjectOrientedProgramming.ReferenceTypes
{
  /// <summary>
  /// Object-oriented programming using reference types test
  /// </summary>
  [TestClass]
  public class ObjectOrientedProgrammingReferenceTypesTest
  {
    [TestMethod]
    public void ExtensionTest()
    {
      Circle circle = new Circle(5);
      Assert.AreEqual(5, circle.Radius);
      Square square = new Square(1234.5678);
      Assert.AreEqual(1234.5678, square.Length);
      Rectangle rectangle = new Rectangle(78.38, 43.38);
      Assert.AreEqual(78.38, rectangle.Height);
      Assert.AreEqual(43.38, rectangle.Width);
    }

    [TestMethod]
    public void CircleDrawingTest()
    {
      IDrawing drawing = new Circle(5);
      AdditionalAssertions.AreEqual(78.54, drawing);
      //Assert.AreEqual(5, interfaceVar.Radius); // 'IDrawing' does not contain a definition for 'Radius'
    }

    [TestMethod]
    public void SquareDrawingTest()
    {
      IDrawing drawing = new Square(1234.5678);
      AdditionalAssertions.AreEqual(1524157.65, drawing);
      //Assert.AreEqual(1234.5678, square.Length); //'IDrawing' does not contain a definition for 'Length'
    }

    [TestMethod]
    public void RectangleDrawiTestMethod()
    {
      IDrawing drawing = new Rectangle(78.38, 43.38);
      AdditionalAssertions.AreEqual(3400.12, drawing);
      //Assert.AreEqual(78.38, rectangle.Height); //'IDrawing' does not contain a definition for 'Height'
      //Assert.AreEqual(43.38, rectangle.Width); //'IDrawing' does not contain a definition for 'Height'
    }
  }
}