using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MSNightMauiDemo.Observables;

namespace MSNightMauiDemo.ViewModels;

public partial class ShoppingListViewModel : ObservableObject
{
    private IRelayCommand<Item> _deleteItemCommand;
    [ObservableProperty]
    private ObservableCollection<Item> _shoppingList = new ObservableCollection<Item>();

    public ShoppingListViewModel()
    {
        ShoppingList.Add(new Item
        {
            Name = "Melk",
            Count = 2
        });
        ShoppingList.Add(new Item
        {
            Name = "Eieren",
            Count = 2
        });
    }

    public IRelayCommand<Item> DeleteItemCommand => _deleteItemCommand ?? new RelayCommand<Item>((item) =>
    {
        ShoppingList.Remove(item);
    });
}