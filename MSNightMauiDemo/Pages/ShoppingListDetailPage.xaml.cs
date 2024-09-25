using MSNightMauiDemo.ViewModels;

namespace MSNightMauiDemo.Pages;

public partial class ShoppingListDetailPage : ContentPage
{
    public ShoppingListDetailPage(ShoppingListDetailViewModel shoppingListDetailViewModel)
    {
        InitializeComponent();
        BindingContext = shoppingListDetailViewModel;
    }
}