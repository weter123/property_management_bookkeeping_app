

using RecordKeepingApp.Models;
using RecordKeepingApp.ViewModels;
using RecordKeepingApp.Views;
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

        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var property = e.CurrentSelection.FirstOrDefault() as Property;
                if (property == null)
                {
                    return;
                }
                await Shell.Current.GoToAsync(nameof(PropertyDetailsPage), true, new Dictionary<string, object>
                {
                    { "Property", property }
                });
            }
            catch (Exception ex)
            { 

                ErrorHandler.HandleException(ex);
            }

        }

    }
}
