using MobileApp.Models;
using MobileApp.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class ItemsPage : ContentPage
  {
    private ItemsViewModel viewModel;

    public ItemsPage()
    {
      InitializeComponent();

      BindingContext = viewModel = new ItemsViewModel();
    }

    private async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
    {
      if (!(args.SelectedItem is Item))
        return;
      Item item = (Item)args.SelectedItem;
      await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

      // Manually deselect item.
      ItemsListView.SelectedItem = null;
    }

    private async void AddItem_Clicked(object sender, EventArgs e)
    {
      await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
    }

    protected override void OnAppearing()
    {
      base.OnAppearing();

      if (viewModel.Items.Count == 0)
        viewModel.LoadItemsCommand.Execute(null);
    }
  }
}