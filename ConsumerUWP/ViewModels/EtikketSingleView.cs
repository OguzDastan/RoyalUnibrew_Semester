using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ConsumerUWP.Annotations;
using GalaSoft.MvvmLight.Command;

namespace ConsumerUWP.ViewModels
{
    class EtikketSingleView
    {
        private string _controller;
        private int _id;

        private ProcessOrderArk _selectedark;

        public ObservableCollection<ProcessOrderArk> _overviewlist1 = new ObservableCollection<ProcessOrderArk>();
        public EtikketSingleView()
        {
            OverviewLists1 = new ObservableCollection<ProcessOrderArk>();

        }

        // XAML binding til ListView
        public ObservableCollection<ProcessOrderArk> OverviewLists1
        {
            get { return _overviewlist1; }
            set { _overviewlist1 = value; }
        }

        public RelayCommand MyCmd
        {
            get;
            private set;
        }

        public int ArkId
        {
            get { return _id; }
            set { _id = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
