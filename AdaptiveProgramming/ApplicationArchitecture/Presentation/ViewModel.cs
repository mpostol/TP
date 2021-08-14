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
  internal class ViewModel
  {
    internal ViewModel(Model model = default(Model))
    {
      MyModel = model ?? new Model(); //creates production version of the Model layer if required
    }

    private Model MyModel { get; set; }
  }
}