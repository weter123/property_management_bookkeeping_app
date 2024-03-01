
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
        
        public void OnAddNewRentalButtonClicked(object sender, EventArgs args)
        {
            statusMessage.Text = "";
            _ = int.TryParse(page.Text, out int p);
            _ = int.TryParse(amount.Text, out int i);
            App.RecordRepo.AddNewProperty(p, doorNo.Text, type.Text, name.Text, sequence.Text, i, phone.Text);
            statusMessage.Text = App.RecordRepo.StatusMessage;
        }

        public async void OnGetButtonClicked(object sender, EventArgs args)
        {
            statusMessage.Text = "";

            List<Property> properties = await App.RecordRepo.GetAllProperties();
            propertyList.ItemsSource = properties;
        }
        */


    }
}
