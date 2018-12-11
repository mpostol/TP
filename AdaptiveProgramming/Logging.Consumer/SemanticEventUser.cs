//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

namespace TPA.Logging.Consumer
{
  public class SemanticEventUser
  {

    public void DataProcessing()
    {
      //Do something ...
      //And report an error
      SemanticEventSource.Log.Failure(nameof(DataProcessing));
    }
    public void LongDataProcessing()
    {
      //Do low level logging related to data processing
      for (int i = 0; i < 100; i++)
        SemanticEventSource.Log.Startup();
      //And report an error
      SemanticEventSource.Log.Failure(nameof(LongDataProcessing));
    }

  }
}
