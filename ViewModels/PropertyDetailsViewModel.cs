using CommunityToolkit.Mvvm.ComponentModel;
using RecordKeepingApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordKeepingApp.ViewModels
{
    [QueryProperty(nameof(Property), "Property")]
    public partial class PropertyDetailsViewModel : BaseViewModel
    {

        public ObservableCollection<Payment> Payments { get; } = new();

        public Command GetPropertyPaymentsCommand { get; }
        public Command UpdatePropertyCommand { get; }

        [ObservableProperty]
        Property property;

        [ObservableProperty]
        bool updateVisible;

        [ObservableProperty]
        bool confirmVisible;

        public PropertyDetailsViewModel() {
            GetPropertyPaymentsCommand = new Command(async () => await GetAllPropertyPaymentsAsync());
            UpdatePropertyCommand = new Command(async () => await UpdatePropertyAsync());
        }

        // Task to get all payments for a property
        async Task GetAllPropertyPaymentsAsync()
        {
            try
            {
                StatusMessage = "";
                List<Payment> payments = await App.RecordRepo.GetAllPropertyPayments(Property.Page);
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
                ErrorHandler.HandleException(ex);
            }
        }
        
        async Task UpdatePropertyAsync()
        {
            try { 
                if (UpdateVisible)
                {
                    UpdateVisible = false;
                    ConfirmVisible = true;
                } else
                {
                    UpdateVisible = true;
                    ConfirmVisible = false;
                }
            }
            catch (Exception ex) {
                ErrorHandler.HandleException(ex);
            }
        }
        // Method to load data into the page
        public async Task LoadAsync()
        {
            try
            {
                await GetAllPropertyPaymentsAsync();
                UpdateVisible = true;
                ConfirmVisible = false;
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }

        }





    }
}
