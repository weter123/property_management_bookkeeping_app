using RecordKeepingApp.Models;
using RecordKeepingApp.ViewModels;
namespace RecordKeepingApp
{
    public partial class App : Application
    {
        public static RecordRepository RecordRepo { get; private set; }
        public NavigationViewModel _navigationViewModel { get; private set; }
        public App(RecordRepository repo)
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new MainPage());
            _navigationViewModel = new();
            MainPage = new AppShell(_navigationViewModel);
            RecordRepo = repo;
        }
    }
}
