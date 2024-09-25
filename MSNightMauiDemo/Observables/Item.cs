using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MSNightMauiDemo.Observables;

public partial class Item : ObservableObject
{
    [ObservableProperty] 
    private string _name;
    [ObservableProperty] 
    private int _count;
    [ObservableProperty] 
    private bool _done;

    [RelayCommand]
    private void SubtractCounter()
    {
        if (Count > 1)
        {
            Count--;
        }
    }
    
    [RelayCommand]
    private void IncrementCounter()
    {
        Count++;
    }
}