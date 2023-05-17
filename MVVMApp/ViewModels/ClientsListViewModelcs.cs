using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using MVVMApp.ViewModels;
using MVVMApp.Models;
using MVVMApp.Views;
using Xamarin.Forms;

namespace MVVMApp.ViewModels
{
    public class ClientsListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ClientViewModel> Clients { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CreateClientCommand { protected set; get; }
        public ICommand DeleteClientCommand { protected set; get; }
        public ICommand SaveClientCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }

        ClientViewModel selectedClient;

        public INavigation Navigation { get; set; }

        public ClientsListViewModel()
        {
            Clients = new ObservableCollection<ClientViewModel>();
            CreateClientCommand = new Command(CreateClient);
            DeleteClientCommand = new Command(DeleteClient);
            SaveClientCommand = new Command(SaveClient);
            BackCommand = new Command(Back);

        }

        public ClientViewModel SelectedClient
        {
            get { return selectedClient; }
            set
            {
                if (selectedClient != value)
                {
                    ClientViewModel tempClient = value;
                    selectedClient = null;
                    OnPropertyChanged("SelectedClient");
                    Navigation.PushAsync(new ClientPage(tempClient));
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        private void CreateClient()
        {
            Navigation.PushAsync(new ClientPage(new ClientViewModel() { ListViewModel = this }));
        }


        private void Back()
        {
            Navigation.PopAsync();
        }

        private void SaveClient(object clientObject)
        {
            ClientViewModel client = clientObject as ClientViewModel;
            if (client != null && client.IsValid && !Clients.Contains(client))
            {
                Clients.Add(client);
            }
            Back();
        }

        private void DeleteClient(object clientObject)
        {
            ClientViewModel client = clientObject as ClientViewModel;
            if (client != null)
            {
                Clients.Remove(client);
            }
            Back();
        }

    }
}


