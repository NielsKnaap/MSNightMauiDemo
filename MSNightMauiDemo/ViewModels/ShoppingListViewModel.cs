using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MSNightMauiDemo.Observables;
using Newtonsoft.Json;

namespace MSNightMauiDemo.ViewModels;

public partial class ShoppingListViewModel : ObservableObject
{
    const string ShoppingListKey = "shopping_list";
    
    [ObservableProperty]
    private ObservableCollection<Item> _shoppingList = new ObservableCollection<Item>();
    [ObservableProperty]
    private string _newItemName;
    [ObservableProperty]
    private Item? _selectedItem;

    public ShoppingListViewModel()
    {
        var savedShoppingList = Preferences.Get(ShoppingListKey, null);
        if (savedShoppingList != null)
        {
            var parsedSavedShoppingList = JsonConvert.DeserializeObject<ObservableCollection<Item>>(savedShoppingList);
            ShoppingList = parsedSavedShoppingList;
        }
    }

    partial void OnSelectedItemChanged(Item? item)
    {
        if (item == null)
        {
            return;
        }
        
        var parameter = new Dictionary<string, object>
        {
            { "SelectedItem", item }
        };
        Shell.Current.GoToAsync(nameof(ShoppingListDetailViewModel), parameter);
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
    private void DeleteItem(Item item)
    {
        ShoppingList.Remove(item);
        syncSavedShoppingList();
    }

    [RelayCommand]
    private void IncrementItem(Item item)
    {
        item.Count++;
        syncSavedShoppingList();
    }

    [RelayCommand]
    private void SubtractItem(Item item)
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
    }
    
    [RelayCommand]
    private void ToggleDoneState(Item item)
    {
        item.Done = !item.Done;
        syncSavedShoppingList();
    }
    
    [RelayCommand]
    private void NavigateToDetailPage(Item item)
    {
        item.Done = !item.Done;
        syncSavedShoppingList();
    }

    private void syncSavedShoppingList()
    {
        var shoppingListJson = JsonConvert.SerializeObject(ShoppingList);
        Preferences.Set(ShoppingListKey, shoppingListJson);
    }
}