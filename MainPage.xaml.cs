﻿
using RecordKeepingApp.Models;


namespace RecordKeepingApp
{
    public partial class MainPage : ContentPage
    {
        RecordRepository recordsRepository;
        public MainPage()
        {
            InitializeComponent();
            
        }

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
            int i;
            int.TryParse(newAmount.Text, out i);

            App.RecordRepo.AddNewWithdrawalRecord(newRecord.Text,  i, startDate.Date);
            statusMessage.Text = App.RecordRepo.StatusMessage;
        }
        
        public async void OnGetButtonClicked(object sender, EventArgs args)
        {
            statusMessage.Text = "";

            List<Payment> paymentRecords = await  App.RecordRepo.GetAllRecords();
            recordList.ItemsSource = paymentRecords;
        }

        async public void OnSecondButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RentalsPage());
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
