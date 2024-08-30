using MSNightMauiDemo.ViewModels;

namespace MSNightMauiDemo;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        RegisterRoutes();
        
        // Comment out the TabBar region to use Flyout. Also check AppShell.xaml
        #region TabBar
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
        #endregion
        
        // Comment out the Flyout region to use TabBar. Also check AppShell.xaml
        #region Flyout
        // Items.Add(new ShellContent()
        // {
        //     Title = "Home",
        //     Icon = "icon_home",
        //     ContentTemplate = new DataTemplate(typeof(MainPage))
        // });
        //
        // Items.Add(new ShellContent()
        // {
        //     Title = "Shoppinglist",
        //     Icon = "icon_list",
        //     ContentTemplate = new DataTemplate(typeof(ShoppingListPage))
        // });
        #endregion
    }

    private void RegisterRoutes()
    {
        Routing.RegisterRoute(nameof(ShoppingListViewModel), typeof(ShoppingListPage));
    }
}