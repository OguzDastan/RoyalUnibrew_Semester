using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
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
        private int _id;

        private ProcessOrderArk _selectedark;

        public ObservableCollection<ProcessOrderArk> _overviewlist = new ObservableCollection<ProcessOrderArk>();



        public OverviewVM()
        {
            OverviewLists = new ObservableCollection<ProcessOrderArk>();
            ObservableCollection<ProcessOrderArk> alleProcesser = ProcessOrderArk.LoadAllArks();

            var doingStatus =
                from ark in alleProcesser
                where ark.Process == 'd'
                orderby ark.ProcessDate
                select ark;

            foreach (ProcessOrderArk item in doingStatus)
            {
                OverviewLists.Add(item);
            }

            GaaTilArkCommand = new RelayCommand(StoreOdreNrToId);
            /*
            GaaTilArkCommand = new RelayCommand(
                ButtonBase_OnClick);
                */
            /*
            ControlArkCommand = new RelayCommand(
                StoreOdreNrToId);
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



        public RelayCommand GaaTilArkCommand
        {
            get;
            private set;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private void StoreOdreNrToId()
        {
            Id = SelectedArk.ProcessOrderNR;
            var parameters = new ProcessOrderArk {ProcessOrderNR = Id};
            Debug.WriteLine(Id);
            Frame f = new Frame();
            f.Navigate(typeof(EtiketteArkVM), parameters);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Frame curr = new Frame();
            int id = SelectedArk.ProcessOrderNR;
            curr.Navigate(typeof(ConsumerUWP.EtiketteArk), id);
        }

        public RelayCommand ControlArkCommand
        {
            get;
            private set;
        }
        /*
        private void StoreOdreNrToId()
        {
            SelectedArk.Controller = Controller;
        }

        public RelayCommand ControlArkCommand
        {
            get;
            private set;
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
