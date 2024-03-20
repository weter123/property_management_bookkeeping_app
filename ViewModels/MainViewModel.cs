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

        [ObservableProperty]
        int totalAmount;


        public MainViewModel()
        {

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
                StatusMessage = ex.Message;
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
                await GetTotalPaymentAmountAsync();
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }

        }
    }   
}
