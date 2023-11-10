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

namespace TP.GraphicalData.ViewModel
{
  /// <summary>
  /// An interface used to replace any Window and avoid referencing the layer above. 
  /// </summary>
  /// <remarks>
  /// It abstracts the functionality showing the window on the screen.
  /// </remarks>
  public interface IWindow
  {
    /// <summary>
    /// Opens a window and returns without waiting for the newly opened window to close.
    /// </summary>
    void Show();
  }
}