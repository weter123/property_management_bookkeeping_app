using RecordKeepingApp.ViewModels;

namespace RecordKeepingApp.Views;

public partial class InsertPropertyPage : ContentPage
{
    private readonly InsertPropertyViewModel vm;
    public InsertPropertyPage(InsertPropertyViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = vm = viewModel;
	}
}