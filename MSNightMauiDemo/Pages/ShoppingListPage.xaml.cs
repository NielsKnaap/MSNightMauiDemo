using MSNightMauiDemo.ViewModels;

namespace MSNightMauiDemo;

public partial class ShoppingListPage : ContentPage
{
    public ShoppingListPage(ShoppingListViewModel shoppingListViewModel)
    {
        InitializeComponent();
        BindingContext = shoppingListViewModel;
    }
}