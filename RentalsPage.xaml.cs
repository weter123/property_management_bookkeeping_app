namespace RecordKeepingApp;

public partial class RentalsPage : ContentPage
{
	public RentalsPage()
	{
		InitializeComponent();
	}

    public void OnAddNewRentalButtonClicked(object sender, EventArgs args)
    {
        
    }

    async public void OnSecondButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RentalsPage());
    }
}
