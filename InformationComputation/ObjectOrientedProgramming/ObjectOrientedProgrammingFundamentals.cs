//__________________________________________________________________________________________
//
//  Copyright 2022 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//  File: ObjectOrientedProgrammingFundamentals.cs
//__________________________________________________________________________________________

namespace TP.InformationComputation.ObjectOrientedProgramming
{
  #region abstraction

  public interface IInterface
  {
    void MethodDeclaration();
  }

  /// <summary>
  /// Abstraction is a definition whose some members don't have an implementation part.
  /// </summary>
  public abstract class AbstractClass
  {
    public virtual void PublicMethod()
    { }

    /// <summary>
    /// An example of abstract method that does not have a block. The block must be provided by the derived class that is inherited from it.
    /// </summary>
    protected abstract double AbstractMethod();

    #region Encapsulation

    private void HiddenMethod()
    { } // Encapsulation - Encapsulation refers to a definition's ability

    // to hide the visibility of the properties, methods,
    // and other members that intentionally shall not be referred
    // to outside of this definition.

    #endregion Encapsulation
  }

  #endregion abstraction

  public class ConcreteClass : AbstractClass, IInterface //inheritance enables you to create new classes
                                                         //that reuse, extend, implement, and modify
                                                         //the behavior defined in other classes.
  {
    #region constructor

    public ConcreteClass()
    { }

    #endregion constructor

    #region IInterface implementation

    public void MethodDeclaration()

    {
      throw new NotImplementedException();
    }

    #endregion IInterface implementation

    public override void PublicMethod()
    {
      base.PublicMethod();
    }

    #region AbstractClass

    protected override double AbstractMethod()
    {
      throw new NotImplementedException();
    }

    #endregion AbstractClass
  }
}