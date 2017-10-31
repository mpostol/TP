
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
    public void DataProcessingWithSimpleLog()
    {
      IServiceLocator _locator = ServiceLocator.Current;
      ILogger _logger = _locator.GetInstance<ILogger>();
      _logger.Log("Executing DataProcessingWithSimpleLog");
    }
  }
}
