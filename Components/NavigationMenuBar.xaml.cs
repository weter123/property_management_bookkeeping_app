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
        await Shell.Current.GoToAsync(nameof(MainPage));
    }

    async public void onPropertyListButtonClicked(object sender, EventArgs e)
    {

        await Shell.Current.GoToAsync(nameof(PropertyListPage));
    }

}