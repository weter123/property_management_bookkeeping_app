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

        public ObservableCollection<int> PropertyIds { get; } = new();

        public Command GetPaymentsCommand { get; }
        public Command AddNewPaymentCommand { get; }
        public Command GetPropertyIdsCommand { get; }

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

        [ObservableProperty]
        List<int> pages;

        [ObservableProperty]
        int selectedItem;

        public MainViewModel(RecordRepository repo)
        {
            this.recordRepository = repo;
            GetPaymentsCommand = new Command(async () => await GetAllPaymentsAsync());
            AddNewPaymentCommand = new Command(async () => await AddNewPaymentAsync());
            GetPropertyIdsCommand = new Command(async () => await GetAllPropertyIdsAsync());
        }

        async Task GetAllPaymentsAsync()
        {
            try
            {
                StatusMessage = "";
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
        async Task AddNewPaymentAsync()
        {

            try
            {
                StatusMessage = "";
                int.TryParse(Amount, out int i);

                FinalDate = StartDate.ToString("d") + " - " + EndDate.ToString("d");
                App.RecordRepo.AddNewPaymentRecord(Name, Address, i, FinalDate);
                
                await GetAllPaymentsAsync();

                StatusMessage = App.RecordRepo.StatusMessage;

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"unable to add payment: {ex.Message}");
                //await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
            }
        }

        async Task GetAllPropertyIdsAsync()
        {
            try
            {
                StatusMessage = "";
                List<Property> pages = await App.RecordRepo.GetAllPropertyIds();
                if (PropertyIds.Count != 0)
                {
                    PropertyIds.Clear();
                }

                foreach (Property page in pages)
                {
                    PropertyIds.Add(page.Page);
                }
            }

            catch (Exception ex)
            {
                Debug.WriteLine($"unable to get properties: {ex.Message}");
                //await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
            }
        }

        public async Task LoadAsync()
        {
            await GetAllPaymentsAsync();
            await GetAllPropertyIdsAsync();
        }
    }
    
}
