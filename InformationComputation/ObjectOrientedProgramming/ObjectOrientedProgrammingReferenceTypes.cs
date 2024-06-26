﻿//__________________________________________________________________________________________
//
//  Copyright 2022 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

namespace TP.InformationComputation.ObjectOrientedProgramming.ReferenceTypes
{
  public abstract class DrawingAbstractClass : IDrawing
  {
    public abstract double Area();
  }

  /// <summary>
  /// The Circle class hold data about a circle.
  /// </summary>
  public class Circle : DrawingAbstractClass
  {
    #region constructor

    public Circle(double radius)
    {
      Radius = radius;
    }

    #endregion constructor

    #region extension

    public double Radius { get; set; }

    #endregion extension

    #region Drawing implementation (polymorphism)

    public override double Area()
    {
      return (Math.PI) * Math.Pow(Radius, 2);
    }

    #endregion Drawing implementation (polymorphism)
  }
  /// <summary>
  /// The Square class hold data about a square.
  /// </summary>
  public class Square : DrawingAbstractClass
  {
    #region constructor

    public Square(double length)
    {
      Length = length;
    }

    #endregion constructor

    #region extension

    public double Length { get; set; }

    #endregion extension

    #region Drawing implementation (polymorphism)

    public override double Area()
    {
      return Math.Pow(Length, 2);
    }

    #endregion Drawing implementation (polymorphism)
  }
  /// <summary>
  /// The Rectangle class hold data about a rectangle.
  /// </summary>
  public class Rectangle : DrawingAbstractClass
  {
    #region constructor

    public Rectangle(double height, double width)
    {
      Height = height;
      Width = width;
    }

    #endregion constructor

    #region extension

    public double Height { get; set; }
    public double Width { get; set; }

    #endregion extension

    #region Drawing implementation (polymorphism)

    public override double Area()
    {
      return Height * Width;
    }

    #endregion Drawing implementation (polymorphism)
  }
}