using RecordKeepingApp.ViewModels;
using RecordKeepingApp.Views;

namespace RecordKeepingApp.Components;

public partial class NavigationMenuBar : ContentView
{

    public NavigationMenuBar()
	{
		InitializeComponent();
        
	}

    async public void OnMainPageButtonClicked(object sender, EventArgs e)
    {
        string n = "///" + nameof(MainPage);
        await Shell.Current.GoToAsync(n);
    }

    async public void OnPropertyListButtonClicked(object sender, EventArgs e)
    {

        await Shell.Current.GoToAsync(nameof(PropertyListPage));
    }

    async public void OnInsertPaymentButtonClicked(object sender, EventArgs e)
    {

        await Shell.Current.GoToAsync(nameof(InsertPaymentPage));
    }

}