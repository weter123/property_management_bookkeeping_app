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
}