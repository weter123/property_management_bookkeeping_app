using RecordKeepingApp.ViewModels;
using RecordKeepingApp.Views;

namespace RecordKeepingApp
{
    public partial class AppShell : Shell
    {
        private readonly NavigationViewModel viewModel;
        public AppShell(NavigationViewModel viewModel)
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(PropertyListPage), typeof(PropertyListPage));
            Routing.RegisterRoute(nameof(PropertyDetailsPage), typeof(PropertyDetailsPage));
            Routing.RegisterRoute(nameof(InsertPaymentPage), typeof(InsertPaymentPage));
            Routing.RegisterRoute(nameof(InsertPropertyPage), typeof(InsertPropertyPage));
            BindingContext = this.viewModel = viewModel;
        }

    }
}
