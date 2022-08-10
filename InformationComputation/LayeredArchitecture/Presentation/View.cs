//__________________________________________________________________________________________
//
//  Copyright 2022 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

namespace TP.InformationComputation.LayeredArchitecture.Presentation
{
  /// <summary>
  /// Class View is an example of a view layer implementation that is a sublayer of the Presentation layer.
  /// /// </summary>
  internal class View
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="View"/> class for the production or testing purpose.
    /// </summary>
    /// <param name="viewModel"> - the view model layer if any. If <paramref name="viewModel"/> is null the production version of the <see cref="ViewModel"/> is created instead.</param>
    public View(ViewModel? viewModel = default(ViewModel))
    {
      MyViewModel = viewModel ?? new ViewModel();
    }

    private ViewModel? MyViewModel { get; set; } = default(ViewModel);
  }
}