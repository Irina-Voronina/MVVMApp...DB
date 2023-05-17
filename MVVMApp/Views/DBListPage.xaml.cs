using MVVMApp.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MVVMApp.Views;
using MVVMApp;


namespace MVVMApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DBListPage : ContentPage
    {
        private readonly object selectedClient;

        public DBListPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            clientsList.ItemsSource = App.Database.GetItems();
            base.OnAppearing();
        }


        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Client selectedClient = (Client)e.SelectedItem;
            DBClientPage clientPage = new DBClientPage();
            clientPage.BindingContext = selectedClient;
            await Navigation.PushAsync(clientPage);
        }

        private async void CreateClient(object sender, EventArgs e)
        {
            Client client = new Client();
            DBClientPage clientPage = new DBClientPage();
            clientPage.BindingContext = client;
            await Navigation.PushAsync(clientPage);
        }
    }
}