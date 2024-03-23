using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordKeepingApp.ViewModels
{
    public partial class InsertPropertyViewModel: BaseViewModel
    {

        public Command AddNewPropertiesCommand { get; }

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

        public InsertPropertyViewModel()
        {
            AddNewPropertiesCommand = new Command(async () => await AddNewPropertyAsync());
        }

        // Task that pass property data(provided by user) to be inserted int the SQL Database
        async Task AddNewPropertyAsync()
        {

            try
            {
                StatusMessage = "";
                _ = int.TryParse(Page, out int pageNumber);
                _ = int.TryParse(Amount, out int amountNumber);
                InputValidations.Validations result = InputValidations.ValidateInsertNewPropertyInput(pageNumber, amountNumber, DoorNo, Type, Name, Sequence, Phone);
                if (result.result != true)
                {
                    StatusMessage = result.message;
                    return;
                }

                App.RecordRepo.AddNewProperty(pageNumber, DoorNo, Type, Name, Sequence, amountNumber, Phone);
                StatusMessage = App.RecordRepo.StatusMessage;

            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
        }
    }
}
