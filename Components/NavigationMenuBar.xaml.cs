namespace RecordKeepingApp.Components;

public partial class NavigationMenuBar : ContentView
{
	public NavigationMenuBar()
	{
		InitializeComponent();
	}

    async public void onMainPageButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

    async public void onPropertyListButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PropertyListPage());
    }

}