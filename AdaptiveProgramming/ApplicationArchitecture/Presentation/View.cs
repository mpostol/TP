//__________________________________________________________________________________________
//
//  Copyright 2021 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started 
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

namespace TPA.ApplicationArchitecture.Presentation
{
  /// <summary>
  /// Class View = it is an example of the view layer implementation.
  /// /// </summary>
  internal class View
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="View"/> class.
    /// </summary>
    /// <param name="viewModel"> - the view model layer if any. If <paramref name="viewModel"/> is null the production version of the <see cref="ViewModel"/> is created instead.</param>
    public View(ViewModel viewModel = null)
    {
      MyViewModel = viewModel ?? new ViewModel();
    }

    private ViewModel MyViewModel { get; set; } = default(ViewModel);
  }
}