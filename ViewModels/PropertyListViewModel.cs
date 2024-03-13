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
    public partial class PropertyListViewModel : BaseViewModel
    {
        public ObservableCollection<Property> Properties { get; } = new();

        #region Commands
        public Command GetPropertiesCommand { get; }
        public Command AddNewPropertiesCommand { get; }
        #endregion

        #region ObservableProperty
        [ObservableProperty]
        string page;

        [ObservableProperty]
        string amount;

        [ObservableProperty]
        string doorNo;

        [ObservableProperty]
        string type;

        [ObservableProperty]
        string name;

        [ObservableProperty]
        string sequence;

        [ObservableProperty]
        string phone;
        #endregion

        public PropertyListViewModel() {

            GetPropertiesCommand = new Command(async () => await GetAllPropertiesAsync());
            AddNewPropertiesCommand = new Command(async () => await AddNewPropertyAsync());
        }

        #region Tasks
        // Task that requests list of properties to be injected in PropertyList's CollectionView
        async Task GetAllPropertiesAsync()
        {        
            try
            {
                List<Property> properties = await App.RecordRepo.GetAllProperties();

                if(Properties.Count != 0)
                {
                    Properties.Clear();
                }
                
                foreach( Property property in properties)
                {
                    Properties.Add(property);
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
        }
        // Task that pass property data(provided by user) to be inserted int the SQL Database
        async Task AddNewPropertyAsync()
        {

            try
            {
                StatusMessage = "";
                _ = int.TryParse(Page, out int pageNumber);
                _ = int.TryParse(Amount, out int amountNumber);

                if(pageNumber <= 0)
                {
                    StatusMessage = "Please enter a valid property page";
                    return;
                }
                if (pageNumber <= 0)
                {
                    StatusMessage = "Please enter a valid amount";
                    return;
                }
                if (string.IsNullOrEmpty(DoorNo))
                {
                    StatusMessage = "Please insert a door number";
                    return;
                }
                if (string.IsNullOrEmpty(Type))
                {
                    StatusMessage = "Please insert a type";
                    return;
                }
                if (string.IsNullOrEmpty(Name))
                {
                    StatusMessage = "Please insert a name";
                    return;
                }
                if (string.IsNullOrEmpty(Sequence))
                {
                    StatusMessage = "Please insert a sequence";
                    return;
                }
                if (string.IsNullOrEmpty(Phone))
                {
                    StatusMessage = "Please insert a phone number";
                    return;
                }

                App.RecordRepo.AddNewProperty(pageNumber, DoorNo, Type, Name, Sequence, amountNumber, Phone);
                StatusMessage = App.RecordRepo.StatusMessage;

                await GetAllPropertiesAsync();

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
                await GetAllPropertiesAsync();
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
            
        }
    }
}
