using MVVMApp.Models;
using MVVMApp.ViewModels;
using Plugin.Messaging;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVMApp.ViewModels
{
    public class ClientViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        ClientsListViewModel lvm;
        public Client Client { get; private set; }

        public ICommand SendSmsCommand { get; }
        public ICommand SendEmailCommand { get; }
        public ICommand CallPhoneCommand { get; }

        public ClientViewModel()
        {
            Client = new Client();
            SendSmsCommand = new Command(SendSms);
            SendEmailCommand = new Command(SendEmail);
            CallPhoneCommand = new Command(CallPhone);
        }

        public ClientsListViewModel ListViewModel
        {
            get { return lvm; }
            set
            {
                if (lvm != value)
                {
                    lvm = value;
                    OnPropertyChanged("ListViewModel");
                }
            }
        }
        public string Transaction
        {
            get { return Client.Transaction; }
            set
            {
                if (Client.Transaction != value)
                {
                    Client.Transaction = value;
                    OnPropertyChanged("Transaction");
                }
            }
        }

        public string Adress
        {
            get { return Client.Adress; }
            set
            {
                if (Client.Adress != value)
                {
                    Client.Adress = value;
                    OnPropertyChanged("Adress");
                }
            }
        }

        public string Price
        {
            get { return Client.Price; }
            set
            {
                if (Client.Price != value)
                {
                    Client.Price = value;
                    OnPropertyChanged("Price");
                }
            }
        }
        public string Name
        {
            get { return Client.Name; }
            set
            {
                if (Client.Name != value)
                {
                    Client.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string Email
        {
            get { return Client.Email; }
            set
            {
                if (Client.Email != value)
                {
                    Client.Email = value;
                    OnPropertyChanged("Email");
                }
            }
        }
        public string Phone
        {
            get { return Client.Phone; }
            set
            {
                if (Client.Phone != value)
                {
                    Client.Phone = value;
                    OnPropertyChanged("Phone");
                }
            }
        }


        private void SendSms()
        {
            var smsMessenger = CrossMessaging.Current.SmsMessenger;
            if (smsMessenger.CanSendSms)
            {
                smsMessenger.SendSms(Phone, $"Привет, {Name}!");
            }
        }

        private void SendEmail()
        {
            var emailMessenger = CrossMessaging.Current.EmailMessenger;
            if (emailMessenger.CanSendEmail)
            {
                emailMessenger.SendEmail(Email, "Назначить встречу", $"Добрый день {Name}! Перезвоните мне 56649066!");
            }
        }

        private void CallPhone()
        {
            var phoneDialer = CrossMessaging.Current.PhoneDialer;
            if (phoneDialer.CanMakePhoneCall)
                phoneDialer.MakePhoneCall(Phone);
        }



        public bool IsValid
        {
            get
            {
                return
                    !string.IsNullOrEmpty(Transaction.Trim()) ||
                    !string.IsNullOrEmpty(Adress.Trim()) ||
                    !string.IsNullOrEmpty(Price.Trim()) ||
                    !string.IsNullOrEmpty(Name.Trim()) ||
                    !string.IsNullOrEmpty(Phone.Trim()) ||
                    !string.IsNullOrEmpty(Email.Trim());

            }
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}