using MSNightMauiDemo.ViewModels;

namespace MSNightMauiDemo;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        RegisterRoutes();
        
        TabBar.Items.Add(new ShellContent()
        {
            Title = "Home",
            Icon = "icon_home",
            ContentTemplate = new DataTemplate(typeof(MainPage))
        });
        
        TabBar.Items.Add(new ShellContent()
        {
            Title = "Shoppinglist",
            Icon = "icon_list",
            ContentTemplate = new DataTemplate(typeof(ShoppingListPage))
        });
    }

    private void RegisterRoutes()
    {
        Routing.RegisterRoute(nameof(ShoppingListViewModel), typeof(ShoppingListPage));
    }
}