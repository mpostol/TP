//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System;

namespace TP.Introduction
{
  #region abstraction
  interface IInterface
  {
    void MethodDeclaration();
  }
  abstract class Language
  {
    #region Encapsulation
    public virtual void LanguageMethod() { }
    private void HiddenMethod() { } // Hermetization
    #endregion
  }
  #endregion
  class LanguageCSharp : Language, IInterface //inheritance
  {

    #region constructor
    public LanguageCSharp() { }
    #endregion

    #region IInterface

    public void MethodDeclaration()
    #region implementation
    {
      throw new NotImplementedException();
    }
    #endregion

    public override void LanguageMethod()
    {
      base.LanguageMethod();
    }

    #endregion

  }
}
