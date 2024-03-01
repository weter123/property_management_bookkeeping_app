using RecordKeepingApp.Models;
namespace RecordKeepingApp
{
    public partial class App : Application
    {
        public static RecordRepository RecordRepo { get; private set; }
        public App(RecordRepository repo)
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new MainPage());
            MainPage = new AppShell();
            RecordRepo = repo;
        }
    }
}
