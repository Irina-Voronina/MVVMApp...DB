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
    public partial class ClientPage : ContentPage
    {
        public ClientViewModel ViewModel { get; private set; }
        public ClientPage(ClientViewModel vm)
        {
            InitializeComponent();
            ViewModel = vm;
            BindingContext = ViewModel;
        }

        public ClientPage()
        {
        }
    }
}