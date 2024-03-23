using CommunityToolkit.Mvvm.ComponentModel;
using RecordKeepingApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordKeepingApp.ViewModels
{
    public partial class NavigationViewModel : ObservableObject
    {
        public Command GoToMainPageCommand { get; }
        public Command GoToInsertPaymentPageCommand { get; }
        public Command GoToPropertyListPageCommand { get; }

        public Command GoToInsertPropertyPageCommand { get; }
        public NavigationViewModel() { 
            GoToMainPageCommand = new Command( async () => await GotToMainPageAsync());
            GoToInsertPaymentPageCommand = new Command(async () => await GoToInsertPaymentPageAsync());
            GoToPropertyListPageCommand = new Command(async () => await GoToPropertyListPageAsync());
            GoToInsertPropertyPageCommand = new Command(async () => await GoToInsertPropertyPageAsync());
        }

        async Task GotToMainPageAsync()
        {
            string n = "///" + nameof(MainPage);
            await Shell.Current.GoToAsync(n);
        }

        async Task GoToInsertPaymentPageAsync()
        {

            await Shell.Current.GoToAsync(nameof(InsertPaymentPage));
        }

        async Task GoToPropertyListPageAsync()
        {

            await Shell.Current.GoToAsync(nameof(PropertyListPage));
        }

        async Task GoToInsertPropertyPageAsync()
        {
            await Shell.Current.GoToAsync(nameof(InsertPropertyPage));
        }
    }
}
