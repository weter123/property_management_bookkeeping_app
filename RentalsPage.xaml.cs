
using RecordKeepingApp.Models;
namespace RecordKeepingApp
{

    public partial class RentalsPage : ContentPage
    {
        public RentalsPage()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);
            List<Property> properties = await App.RecordRepo.GetAllProperties();
            MainThread.BeginInvokeOnMainThread(() =>
            {
                RentalsList.ItemsSource = properties;

            });
        }

        public void OnAddNewRentalButtonClicked(object sender, EventArgs args)
        {
            statusMessage.Text = "";
            int p;
            int.TryParse(page.Text, out p);
            int i;
            int.TryParse(amount.Text, out i);
            App.RecordRepo.AddNewProperty(p, doorNo.Text, type.Text, name.Text, sequence.Text, i, phone.Text);
            statusMessage.Text = App.RecordRepo.StatusMessage;
        }

        async public void OnSecondButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RentalsPage());
        }
    }
}
