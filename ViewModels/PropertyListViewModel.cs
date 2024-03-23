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

        public Command GetPropertiesCommand { get; }

        public PropertyListViewModel() {

            GetPropertiesCommand = new Command(async () => await GetAllPropertiesAsync());
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
