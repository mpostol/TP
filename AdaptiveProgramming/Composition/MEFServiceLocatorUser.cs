
using System.ComponentModel.Composition;

namespace TPA.Composition
{
  public class MEFServiceLocatorUser
  {

    public void DataProcessing()
    {
      if (Logger != null)
        Logger.Log("Executing DataProcessingWithSimpleLog");
    }

    [Import(typeof(ILogger))]
    public ILogger Logger { get; set; }

  }
}
