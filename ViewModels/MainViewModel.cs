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

        #region Commands
        public Command GetPaymentsCommand { get; } 
        public Command AddNewPaymentCommand { get; }
        public Command GetPropertyIdsCommand { get; }
        public Command GetSelectedPropertyCommand { get; }
        #endregion

        #region ObservableProperty
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

        [ObservableProperty]
        string minimumDate;

        [ObservableProperty]
        string maximumDate;

        [ObservableProperty]
        int totalAmount;

        #endregion
        public MainViewModel()
        {
            //GetPaymentsCommand = new Command(async () => await GetAllPaymentsAsync());
            AddNewPaymentCommand = new Command(async () => await AddNewPaymentAsync());
            //GetPropertyIdsCommand = new Command(async () => await GetAllPropertyIdsAsync());
            GetSelectedPropertyCommand = new Command(async () => await GetPropertyAsync(selectedItem));
        }

        #region Tasks
        // Task that requests list of payments (PaymentProperty objects) to be injected in MainPage's CollectionView
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

        // Task that pass payment data (provided by user) to be inserted into the SQL Database
        async Task AddNewPaymentAsync()
        {
            try
            {
                StatusMessage = "";
                _ = int.TryParse(Amount, out int i);
                if (SelectedItem == 0)
                {
                    StatusMessage = "Please select a property";
                    return;
                }
                if (StartDate == DateTime.MinValue)
                {
                    StatusMessage = "Please select a start date";
                    return;
                }
                if (EndDate == DateTime.MinValue)
                {
                    StatusMessage = "Please select an end date";
                    return;
                }
                if (i <= 0)
                {
                    StatusMessage = "Please enter a valid amount";
                    return;
                }

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

        // Task requests list of property Ids from the database to populate the Picker
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

        // Task requests property data matching the selected page Id from the Picker.
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

        async Task GetTotalPaymentAmountAsync()
        {
            try
            {
                TotalAmount = await App.RecordRepo.GetTotalPaymentAmount();
            }

            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
        }

        #endregion 

        // Method that load data when called
        public async Task LoadAsync()
        {
            try
            {
                await GetAllPaymentsAsync();
                await GetAllPropertyIdsAsync();
                await GetTotalPaymentAmountAsync();

                MinimumDate = new DateTime(2023, 1, 1).ToString("d");
                MaximumDate = new DateTime(2024, 12, 31).ToString("d");
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }

        }
    }   
}
