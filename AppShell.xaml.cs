using RecordKeepingApp.ViewModels;
using RecordKeepingApp.Views;

namespace RecordKeepingApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(PropertyListPage), typeof(PropertyListPage));
            Routing.RegisterRoute(nameof(PropertyDetailsPage), typeof(PropertyDetailsPage));
        }
    }
}
