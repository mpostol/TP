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

namespace TPA.Composition
{
  /// <summary>
  /// Provides data processing functionality with optional logging support.
  /// </summary>
  public class MEFServiceLocatorUser
  {
    public void DataProcessing()
    {
      if (logger != null)
        logger.Log("Executing DataProcessingWithSimpleLog");
    }

    public ICustomILogger? logger { get; set; }
  }
}