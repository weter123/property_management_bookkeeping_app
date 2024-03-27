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
    public partial class InsertPaymentViewModel : BaseViewModel
    {
        public ObservableCollection<int> PropertyIds { get; } = new();

        #region Commands
        public Command AddNewPaymentCommand { get; }
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

        #endregion
        public InsertPaymentViewModel()
        {
            AddNewPaymentCommand = new Command(async () => await AddNewPaymentAsync());
            GetSelectedPropertyCommand = new Command(async () => await GetPropertyAsync(selectedItem));
        }

        // Task that pass payment data (provided by user) to be inserted into the SQL Database
        async Task AddNewPaymentAsync()
        {
            try
            {
                _ = int.TryParse(Amount, out int i);

                InputValidations.Validations result = InputValidations.ValidateInsertNewPaymentInput(SelectedItem, i, StartDate, EndDate);
                if (result.result != true)
                {
                    StatusMessage = result.message;
                    return;
                }
                FinalDate = StartDate.ToString("d") + " - " + EndDate.ToString("d");
                App.RecordRepo.AddNewPaymentRecord(SelectedItem, i, FinalDate);

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
                List<Property> properties = await App.RecordRepo.GetAllProperties();
                if (PropertyIds.Count != 0)
                {
                    PropertyIds.Clear();
                }

                foreach (Property property in properties)
                {
                    PropertyIds.Add(property.Page);
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
                
                await GetAllPropertyIdsAsync();

                MinimumDate = new DateTime(2023, 12, 31).ToString("d");
                MaximumDate = new DateTime(2025, 1, 1).ToString("d");
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }

        }
    }
}
