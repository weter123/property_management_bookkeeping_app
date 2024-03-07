
using RecordKeepingApp.Models;
using RecordKeepingApp.ViewModels;


namespace RecordKeepingApp
{
    public partial class MainPage : ContentPage
    {
        private readonly MainViewModel vm;
        public MainPage(MainViewModel mainViewModel)
        {
            InitializeComponent();
            BindingContext = vm = mainViewModel;

        }
        protected override async void OnAppearing() 
        { 
            base.OnAppearing(); 
            await vm.LoadAsync(); 
        }
        /*
        protected override async void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);
            List<Payment> records = await App.RecordRepo.GetAllRecords();
            MainThread.BeginInvokeOnMainThread(() =>
            {
                recordList.ItemsSource = records;

            });
        }

        
        */
    }
}
