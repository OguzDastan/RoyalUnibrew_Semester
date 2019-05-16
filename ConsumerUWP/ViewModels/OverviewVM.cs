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

        private OverviewList _selectedark;

        private ObservableCollection<OverviewList> _overviewlist = new ObservableCollection<OverviewList>();

        public OverviewVM()
        {
            _overviewlist.Add(new OverviewList("Etiket Operatør", "15-05-2019 / 07.30"));
            _overviewlist.Add(new OverviewList("Tappe Operatør", "15-05-2019 / 11.30"));
            _overviewlist.Add(new OverviewList("Trykkontrol", "15-05-2019 / 14.30"));
            _overviewlist.Add(new OverviewList("Etiket Operatør", "15-05-2019 / 15.45"));
            _overviewlist.Add(new OverviewList("Færdigvare Kontrol", "15-05-2019 / 18.30"));
            _overviewlist.Add(new OverviewList("Tappe Operatør", "16-05-2019 / 07.30"));
            _overviewlist.Add(new OverviewList("Trykkontrol", "16-05-2019 / 08.00"));

            ControlArkCommand = new RelayCommand(
                AddControllerToArk);


        }

        public OverviewList SelectedArk
        {
            get { return _selectedark; }
            set
            {
                _selectedark = value;
                OnPropertyChanged();
            }
        }

        // XAML binding til ListView
        public ObservableCollection<OverviewList> OverviewLists
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

        private void AddControllerToArk()
        {
            SelectedArk.Controller = Controller;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
