using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MSNightMauiDemo.Observables;
using Newtonsoft.Json;

namespace MSNightMauiDemo.ViewModels;

public partial class ShoppingListViewModel : ObservableObject
{
    const string ShoppingListKey = "shopping_list";
    
    private IRelayCommand<Item>? _deleteItemCommand;
    private IRelayCommand<Item>? _incrementItemCommand;
    private IRelayCommand<Item>? _subtractItemCommand;
    [ObservableProperty]
    private ObservableCollection<Item> _shoppingList = new ObservableCollection<Item>();
    [ObservableProperty]
    private string _newItemName;

    public ShoppingListViewModel()
    {
        var savedShoppingList = Preferences.Get(ShoppingListKey, null);
        if (savedShoppingList != null)
        {
            var parsedSavedShoppingList = JsonConvert.DeserializeObject<ObservableCollection<Item>>(savedShoppingList);
            ShoppingList = parsedSavedShoppingList;
        }
    }

    [RelayCommand]
    private void AddItem()
    {
        ShoppingList.Add(new Item
        {
            Name = NewItemName,
            Count = 1
        });
        NewItemName = string.Empty;
        syncSavedShoppingList();
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
        syncSavedShoppingList();
    });
    
    public IRelayCommand<Item> IncrementItemCommand => _incrementItemCommand ?? new RelayCommand<Item>((item) =>
    {
        item.Count++;
        syncSavedShoppingList();
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
        syncSavedShoppingList();
    });

    private void syncSavedShoppingList()
    {
        var shoppingListJson = JsonConvert.SerializeObject(ShoppingList);
        Preferences.Set(ShoppingListKey, shoppingListJson);
    }
}