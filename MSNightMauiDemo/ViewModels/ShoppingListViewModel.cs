using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MSNightMauiDemo.Observables;

namespace MSNightMauiDemo.ViewModels;

public partial class ShoppingListViewModel : ObservableObject
{
    private IRelayCommand<Item> _deleteItemCommand;
    private IRelayCommand<Item>? _incrementItemCommand;
    private IRelayCommand<Item>? _subtractItemCommand;
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
    [RelayCommand]
    private void ToggleDoneState(Item item)
    {
        item.Done = !item.Done;
        syncSavedShoppingList();
    }

    public IRelayCommand<Item> DeleteItemCommand => _deleteItemCommand ?? new RelayCommand<Item>((item) =>
    {
        ShoppingList.Remove(item);
    });
    
    public IRelayCommand<Item> IncrementItemCommand => _incrementItemCommand ?? new RelayCommand<Item>((item) =>
    {
        item.Count++;
    });
    
    public IRelayCommand<Item> SubtractItemCommand => _subtractItemCommand ?? new RelayCommand<Item>((item) =>
    {
        if (item.Count == 1)
        {
            DeleteItemCommand.Execute(item);
        }
        else
        {
            item.Count--;
        }
    });
}