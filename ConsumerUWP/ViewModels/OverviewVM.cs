using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ConsumerUWP.Annotations;
using GalaSoft.MvvmLight.Command;
using Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ConsumerUWP.ViewModels
{
    class OverviewVM : INotifyPropertyChanged
    {

        private string _controller;

        private ProcessOrderArk _selectedark;

        private ObservableCollection<ProcessOrderArk> _overviewlist = new ObservableCollection<ProcessOrderArk>();

        public OverviewVM()
        {
            OverviewLists = new ObservableCollection<ProcessOrdre>();
            ObservableCollection<ProcessOrderArk> alleProcesser = ProcessOrderArk.LoadAllArks();

            var doing =
                from ark in alleProcesser
                where ark.Process == 'd'
                orderby ark.ProcessDate
                select ark;

            foreach (ProcessOrderArk item in doing)
            {
                OverviewLists.Add(item);
            }

            /*
            ControlArkCommand = new RelayCommand(
                AddControllerToArk);
            */

        }

        public ProcessOrderArk SelectedArk
        {
            get { return _selectedark; }
            set
            {
                _selectedark = value;
                OnPropertyChanged();
            }
        }


        // XAML binding til ListView
        public ObservableCollection<ProcessOrderArk> OverviewLists
        {
            get { return _overviewlist; }
            set { _overviewlist = value; }
        }

        public string Controller
        {
            get { return _controller; }
            set
            {
                _controller = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand ControlArkCommand
        {
            get;
            private set;
        }
        /*
        private void AddControllerToArk()
        {
            SelectedArk.Controller = Controller;
        }
        */
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
