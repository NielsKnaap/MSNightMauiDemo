using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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