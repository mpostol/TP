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