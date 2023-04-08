//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2023, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//  by introducing yourself and telling us what you do with this community.
//_____________________________________________________________________________________________________________________________________

using System;

namespace TP.Introduction
{
  #region abstraction

  internal interface IInterface
  {
    void MethodDeclaration();
  }

  internal abstract class Language
  {
    #region Encapsulation

    public virtual void LanguageMethod() { }

    private void HiddenMethod() { } // Hermetization

    #endregion Encapsulation
  }

  #endregion abstraction

  internal class LanguageCSharp : Language, IInterface //inheritance
  {
    #region constructor

    public LanguageCSharp() { }

    #endregion constructor

    #region IInterface

    public void MethodDeclaration()

    #region implementation

    {
      throw new NotImplementedException();
    }

    #endregion implementation

    public override void LanguageMethod()
    {
      base.LanguageMethod();
    }

    #endregion IInterface
  }
}