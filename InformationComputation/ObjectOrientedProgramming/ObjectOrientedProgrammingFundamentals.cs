//__________________________________________________________________________________________
//
//  Copyright 2022 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

namespace TP.InformationComputation.ObjectOrientedProgramming
{
  #region abstraction

  public interface IInterface
  {
    void MethodDeclaration();
  }

  public abstract class AbstractClass
  {
    #region Encapsulation

    public virtual void PublicMethod()
    { }

    private void HiddenMethod()
    { } // Encapsulation - Encapsulation refers to a definition's ability to hide the visibility of the properties, methods, and other members that intentionally shall not be referred to outside of this definition.

    #endregion Encapsulation
  }

  #endregion abstraction

  public class ConcreteClass : AbstractClass, IInterface //inheritance
  {
    #region constructor

    public ConcreteClass()
    { }

    #endregion constructor

    #region IInterface

    public void MethodDeclaration()

    #region implementation

    {
      throw new NotImplementedException();
    }

    #endregion implementation

    public override void PublicMethod()
    {
      base.PublicMethod();
    }

    #endregion IInterface
  }
}