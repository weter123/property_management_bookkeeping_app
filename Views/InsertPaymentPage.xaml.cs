using RecordKeepingApp.ViewModels;

namespace RecordKeepingApp.Views;

public partial class InsertPaymentPage : ContentPage
{
	private readonly InsertPaymentViewModel vm;
	public InsertPaymentPage(InsertPaymentViewModel insertPaymentViewModel)
	{
		InitializeComponent();
		BindingContext = vm = insertPaymentViewModel;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await vm.LoadAsync();
    }
}