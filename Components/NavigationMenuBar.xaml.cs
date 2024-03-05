using RecordKeepingApp.ViewModels;

namespace RecordKeepingApp.Components;

public partial class NavigationMenuBar : ContentView
{

    public NavigationMenuBar()
	{
		InitializeComponent();
        
	}

    async public void onMainPageButtonClicked(object sender, EventArgs e)
    {
        string n = "///" + nameof(MainPage);
        await Shell.Current.GoToAsync(n);
    }

    async public void onPropertyListButtonClicked(object sender, EventArgs e)
    {

        await Shell.Current.GoToAsync(nameof(PropertyListPage));
    }

}