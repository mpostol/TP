//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System;
using CommonServiceLocator;

namespace TPA.Composition
{
  public class ServiceLocatorUser
  {
    public ServiceLocatorUser()
    {
      if (!ServiceLocator.IsLocationProviderSet)
        throw new ActivationException("I cannot compose my stuff because the ServiceLocator.Current is null");
    }
    public void DataProcessing()
    {
      IServiceLocator _locator = ServiceLocator.Current;
      ILogger _logger = _locator.GetInstance<ILogger>();
      _logger.Log("Executing DataProcessingWithSimpleLog");
    }
    public void DataProcessing(string fullName)
    {
      IServiceLocator _locator = ServiceLocator.Current;
      ILogger _logger = _locator.GetInstance<ILogger>(fullName);
    }
    public void DataProcessingNullReferenceException()
    {
      IServiceLocator _locator = ServiceLocator.Current;
      Exception _exception = _locator.GetInstance<Exception>();
      throw _exception;
    }
  }
}
