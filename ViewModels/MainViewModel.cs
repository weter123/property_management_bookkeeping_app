using RecordKeepingApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.Maui.ApplicationModel.Permissions;
using System.Xml.Linq;
using CommunityToolkit.Mvvm.ComponentModel;

namespace RecordKeepingApp.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        public ObservableCollection<Payment> Payments { get; } = new();

        public Command GetPaymentsCommand { get; }
        public Command AddNewPaymentCommand { get; }

        RecordRepository recordRepository;

        [ObservableProperty]
        string amount;

        [ObservableProperty]
        string name;

        [ObservableProperty]
        string address;

        [ObservableProperty]
        DateTime startDate;

        [ObservableProperty]
        DateTime endDate;

        [ObservableProperty]
        String finalDate;

        public MainViewModel(RecordRepository repo)
        {
            this.recordRepository = repo;
            GetPaymentsCommand = new Command(async () => await GetAllPaymentsAysnc());
            AddNewPaymentCommand = new Command(async () => await AddNewPropertyAsync());
        }

        async Task GetAllPaymentsAysnc()
        {
            try
            {
                StatusMessage = "Got All";
                List<Payment> payments = await App.RecordRepo.GetAllRecords();
                if (Payments.Count != 0)
                    {
                        Payments.Clear();
                    }

                foreach (Payment payment in payments)
                {
                    Payments.Add(payment);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"unable to get properties: {ex.Message}");
                //await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
            }
        }

        async Task AddNewPropertyAsync()
        {

            try
            {
                StatusMessage = "";
                int.TryParse(Amount, out int i);

                FinalDate = StartDate.ToString("d") + " - " + EndDate.ToString("d");
                App.RecordRepo.AddNewPaymentRecord(Name, Address, i, FinalDate);
                
                await GetAllPaymentsAysnc();

                StatusMessage = App.RecordRepo.StatusMessage;

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"unable to add payment: {ex.Message}");
                //await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
            }
        }
    }
    
}
