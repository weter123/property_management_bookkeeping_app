
using RecordKeepingApp.Models;
using RecordKeepingApp.ViewModels;


namespace RecordKeepingApp
{
    public partial class MainPage : ContentPage
    {
        private readonly MainViewModel vm;
        public MainPage(MainViewModel mainViewModel)
        {
            InitializeComponent();
            BindingContext = vm = mainViewModel;

        }
        /*
        protected override async void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);
            List<Payment> records = await App.RecordRepo.GetAllRecords();
            MainThread.BeginInvokeOnMainThread(() =>
            {
                recordList.ItemsSource = records;

            });
        }

        public void OnAddNewPaymentButtonClicked(object sender, EventArgs args)
        {
            statusMessage.Text = "";
            int i;
            int.TryParse(newAmount.Text, out i);
 
            App.RecordRepo.AddNewPaymentRecord(newRecord.Text, newAddress.Text, i, startDate.Date, endDate.Date);
            statusMessage.Text = App.RecordRepo.StatusMessage;
        }
        
        public void OnAddNewWithdrawalButtonClicked(object sender, EventArgs args)
        {
            statusMessage.Text = "";
            _ = int.TryParse(newAmount.Text, out int i);

            App.RecordRepo.AddNewWithdrawalRecord(newRecord.Text,  i, startDate.Date);
            statusMessage.Text = App.RecordRepo.StatusMessage;
        }
        
        public async void OnGetButtonClicked(object sender, EventArgs args)
        {
            statusMessage.Text = "";

            List<Payment> paymentRecords = await  App.RecordRepo.GetAllRecords();
            recordList.ItemsSource = paymentRecords;
        }
        
        public void OnPaymentButtonClicked(object sender, EventArgs e)
        {
            payment.BackgroundColor = Color.FromRgb(81, 43, 212);
            withdrawl.BackgroundColor = Colors.Gray;
            primaryEntry.Text = "Name: ";
            mainDateLabel.Text = "From: ";
            amountLabel.Text = " Payment: ";
            addressEntry.IsVisible = true;
            endDateEntry.IsVisible = true;
            paymentButton.IsVisible = true;
            withdrawalButton.IsVisible = false;
        }

        public void OnWithdrawlButtonClicked(object sender, EventArgs e)
        {
            withdrawl.BackgroundColor = Color.FromRgb(81, 43, 212); 
            payment.BackgroundColor = Colors.Gray;
            primaryEntry.Text = "Comment: ";
            mainDateLabel.Text = "Withdrawal Date: ";
            amountLabel.Text = " Withdrawal: ";
            addressEntry.IsVisible = false;
            endDateEntry.IsVisible = false;
            paymentButton.IsVisible = false;
            withdrawalButton.IsVisible = true;
        }
        */
    }
}
