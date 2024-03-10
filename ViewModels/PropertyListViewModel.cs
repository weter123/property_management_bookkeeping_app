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
        public Command AddNewPropertiesCommand { get; }

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


        public PropertyListViewModel() {

            GetPropertiesCommand = new Command(async () => await GetAllPropertiesAsync());
            AddNewPropertiesCommand = new Command(async () => await AddNewPropertyAsync());
        }

        async Task GetAllPropertiesAsync()
        {        
            try
            {
                StatusMessage = "got all";
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
                Debug.WriteLine($"unable to get properties: {ex.Message}");
                //await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
            }
        }

        async Task AddNewPropertyAsync()
        {

            try
            {
                StatusMessage = "";
                _ = int.TryParse(Page, out int p);
                _ = int.TryParse(Amount, out int i);
                App.RecordRepo.AddNewProperty(p, DoorNo, Type, Name, Sequence, i, Phone);
                StatusMessage = App.RecordRepo.StatusMessage;

                await GetAllPropertiesAsync();

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"unable to get add propert: {ex.Message}");
                //await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
            }
        }

        public async Task LoadAsync()
        {
            await GetAllPropertiesAsync();
        }
    }
}
