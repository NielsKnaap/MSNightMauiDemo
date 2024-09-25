using MSNightMauiDemo.ViewModels;

namespace MSNightMauiDemo;

public partial class ShoppingListPage : ContentPage
{
    private ShoppingListViewModel _viewModel;
    
    public ShoppingListPage(ShoppingListViewModel shoppingListViewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = shoppingListViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.SelectedItem = null;
    }
}