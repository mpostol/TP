//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2026, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//  by introducing yourself and telling us what you do with this community.
//_____________________________________________________________________________________________________________________________________

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
      ICustomILogger _logger = _locator.GetInstance<ICustomILogger>();
      _logger.Log("Executing DataProcessingWithSimpleLog");
    }

    public void DataProcessing(string? fullName)
    {
      IServiceLocator _locator = ServiceLocator.Current;
      ICustomILogger _logger = _locator.GetInstance<ICustomILogger>(fullName);
    }

    public void DataProcessingNullReferenceException()
    {
      IServiceLocator _locator = ServiceLocator.Current;
      Exception _exception = _locator.GetInstance<Exception>();
      throw _exception;
    }
  }
}