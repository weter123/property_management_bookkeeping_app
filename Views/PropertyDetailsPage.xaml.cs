namespace RecordKeepingApp.Views;
using RecordKeepingApp.ViewModels;
public partial class PropertyDetailsPage : ContentPage
{
    private readonly PropertyDetailsViewModel vm;
    public PropertyDetailsPage(PropertyDetailsViewModel propertyDetailsViewModel)
	{
		InitializeComponent();
        BindingContext = vm = propertyDetailsViewModel;

    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await vm.LoadAsync();
    }

    //private void OnUpdateButtonClicked(object sender, EventArgs e)
    //{
    //    updateButton.IsVisible = false;
    //    confirmButton.IsVisible = true;
    //}

    //private void OnConfirmButtonClicked(object sender, EventArgs e)
    //{
    //    updateButton.IsVisible = true;
    //    confirmButton.IsVisible = false;
    //}

}