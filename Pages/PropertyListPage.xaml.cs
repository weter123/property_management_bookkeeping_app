
using RecordKeepingApp.Models;
using RecordKeepingApp.ViewModels;
namespace RecordKeepingApp
{

    public partial class PropertyListPage : ContentPage
    {
        private readonly PropertyListViewModel vm;
        public PropertyListPage(PropertyListViewModel propertyListViewModel)
        {
            InitializeComponent();
            BindingContext = vm = propertyListViewModel;

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await vm.LoadAsync();
        }

        /*
        protected async void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);
            List<Property> properties = await App.RecordRepo.GetAllProperties();
            MainThread.BeginInvokeOnMainThread(() =>
            {
                propertyList.ItemsSource = properties;

            });
        }
        */


    }
}
