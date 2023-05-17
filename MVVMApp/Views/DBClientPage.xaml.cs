using MVVMApp.Models;
using MVVMApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVMApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DBClientPage : ContentPage
    {

        public DBClientPage()
        {
            InitializeComponent();
        }

        private void SaveClient(System.Object sender, EventArgs e)
        {
            var client = (Client)BindingContext;
            if (!String.IsNullOrEmpty(client.Name))
            {
                App.Database.SaveItem(client);
            }
            this.Navigation.PopAsync();
        }

        private void DeleteClient(object sender, EventArgs e)
        {
            var client = (Client)BindingContext;
            App.Database.DeleteItem(client.Id);
            this.Navigation.PopAsync();
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
        public ClientViewModel ViewModel { get; private set; }

    }
}

