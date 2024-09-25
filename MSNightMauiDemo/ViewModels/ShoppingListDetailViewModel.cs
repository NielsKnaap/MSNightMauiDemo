using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MSNightMauiDemo.Observables;

namespace MSNightMauiDemo.ViewModels;

public partial class ShoppingListDetailViewModel : ObservableObject, IQueryAttributable
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(ButtonText))]
    private Item? _selectedItem;

    [RelayCommand]
    private void CheckItem()
    {
        SelectedItem.Done = true;
        OnPropertyChanged(nameof(ButtonText));
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        SelectedItem = query["SelectedItem"] as Item;
    }

    public string ButtonText => SelectedItem != null && SelectedItem.Done ? "Reset" : "Done";
}