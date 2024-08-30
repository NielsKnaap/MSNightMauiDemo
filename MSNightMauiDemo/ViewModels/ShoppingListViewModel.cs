using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using MSNightMauiDemo.Observables;

namespace MSNightMauiDemo.ViewModels;

public partial class ShoppingListViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Item> _shoppingList = new ObservableCollection<Item>();

}