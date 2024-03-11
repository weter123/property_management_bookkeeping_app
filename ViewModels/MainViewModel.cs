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
using System.Transactions;

namespace RecordKeepingApp.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {

        public ObservableCollection<PaymentProperty> Payments { get; } = new();

        public ObservableCollection<int> PropertyIds { get; } = new();

        public Command GetPaymentsCommand { get; }
        public Command AddNewPaymentCommand { get; }
        public Command GetPropertyIdsCommand { get; }
        public Command GetSelectedPropertyCommand { get; }

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

        public MainViewModel()
        {
            GetPaymentsCommand = new Command(async () => await GetAllPaymentsAsync());
            AddNewPaymentCommand = new Command(async () => await AddNewPaymentAsync());
            GetPropertyIdsCommand = new Command(async () => await GetAllPropertyIdsAsync());
            GetSelectedPropertyCommand = new Command(async () => await GetPropertyAsync(selectedItem));
        }

        async Task GetAllPaymentsAsync()
        {
            try
            {
                StatusMessage = "";
                List<PaymentProperty> payments = await App.RecordRepo.GetAllPayments();
                if (Payments.Count != 0)
                {
                    Payments.Clear();
                }

                foreach (PaymentProperty payment in payments)
                {
                    Payments.Add(payment);
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
        }
        async Task AddNewPaymentAsync()
        {

            try
            {
                StatusMessage = "";
                _ = int.TryParse(Amount, out int i);

                FinalDate = StartDate.ToString("d") + " - " + EndDate.ToString("d");
                App.RecordRepo.AddNewPaymentRecord(SelectedItem, i, FinalDate);

                await GetAllPaymentsAsync();

                StatusMessage = App.RecordRepo.StatusMessage;
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
        }

        async Task GetAllPropertyIdsAsync()
        {
            try
            {
                StatusMessage = "";
                List<Property> pages = await App.RecordRepo.GetAllProperties();
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
                ErrorHandler.HandleException(ex);
            }
        }

        async Task GetPropertyAsync(int pageId)
        {
            try
            {
                StatusMessage = "";
                Property property = await App.RecordRepo.GetOneProperty(pageId);
                Name = property.Renter;
                Address = property.DoorNumber;
                StatusMessage = string.Format("Found page {0}. Renter's name: {1}", pageId, property.Renter);
            }

            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
        }

        public async Task LoadAsync()
        {
            try
            {
                await GetAllPaymentsAsync();
                await GetAllPropertyIdsAsync();
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }

        }
    }   
}
