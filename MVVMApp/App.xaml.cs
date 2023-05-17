using MVVMApp.Models;
using MVVMApp.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVMApp
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "clients.db";
        public static ClientRepository database;
        public static ClientRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new ClientRepository(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return database;
            }
        }

        public App CurrentApp { get; private set; }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new DBListPage());
        }
        protected override void OnStart()
        {
            CurrentApp = this;
        }
        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}