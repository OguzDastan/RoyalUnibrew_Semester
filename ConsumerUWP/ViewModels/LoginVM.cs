using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using GalaSoft.MvvmLight.Command;
using Models;
using User = Models.User;
using ConsumerUWP;
using ConsumerUWP.Annotations;
using Microsoft.VisualBasic.CompilerServices;

namespace ConsumerUWP.ViewModels
{
    class LoginVM : INotifyPropertyChanged
    {
        public RelayCommand LoginCommand { get; set; }

        private string _uname;
        private string _pword;

        public string Uname
        {
            get { return _uname; }
            set
            {
                _uname = value;
                OnPropertyChanged();
            }
        }

        public string Pword {
            get { return _pword; }
            set
            {
                _pword = value;
                OnPropertyChanged();
            }
        }

        public LoginVM()
        {
            LoginCommand = new RelayCommand(login);
        }

        public void login()
        {
            bool looged = Session.Current.Login(Uname, Pword);
            Debug.WriteLine("Logging in as: "+Uname+" and curr username = "+Session.CurrentUser.UserName);
            if (Session.CurrentUser.AccessLevel == User.AccessLevels.ADMIN)
            {
                Frame curr = (Frame) Window.Current.Content;
                curr.Navigate(typeof(Admin_Overview));
            }
            else if (Session.CurrentUser.AccessLevel == User.AccessLevels.USER)
            {
                Frame curr = (Frame)Window.Current.Content;
               curr.Navigate(typeof(Operator_Overview));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
