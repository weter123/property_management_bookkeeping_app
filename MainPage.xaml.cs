
using RecordKeepingApp.Models;


namespace RecordKeepingApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

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
            int i;
            int.TryParse(newAmount.Text, out i);

            App.RecordRepo.AddNewWithdrawalRecord(newRecord.Text,  i, startDate.Date);
            statusMessage.Text = App.RecordRepo.StatusMessage;
        }
        
        public void OnGetButtonClicked(object sender, EventArgs args)
        {
            statusMessage.Text = "";

            List<Payment> paymentRecords = App.RecordRepo.GetAllPaymentRecords();
            List<Withdrawal> withdrawalRecords = App.RecordRepo.GetAllWithdrawalRecords();
            paymentList.ItemsSource = paymentRecords;
            withdrawalList.ItemsSource = withdrawalRecords;
        }

        async public void OnSecondButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new secondPage());
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
    }
}
