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

        [ObservableProperty]
        Property property;

        public PropertyDetailsViewModel() {
            GetPropertyPaymentsCommand = new Command(async () => await GetAllPropertyPaymentsAsync());

        }

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

        public async Task LoadAsync()
        {
            try
            {
                await GetAllPropertyPaymentsAsync();
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }

        }





    }
}
