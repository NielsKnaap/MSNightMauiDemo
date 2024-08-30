using CommunityToolkit.Mvvm.ComponentModel;

namespace MSNightMauiDemo.Observables;

public partial class Item : ObservableObject
{
    [ObservableProperty] 
    private string _name;
    [ObservableProperty] 
    private int _count;
}