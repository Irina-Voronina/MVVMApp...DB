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
    public partial class ClientsListPage : ContentPage
    {
        public ClientsListPage()
        {
            InitializeComponent();
            BindingContext = new ClientsListViewModel() { Navigation = this.Navigation };
        }
    }
}