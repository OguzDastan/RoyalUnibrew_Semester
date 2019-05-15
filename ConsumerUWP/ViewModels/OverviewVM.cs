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

namespace ConsumerUWP.ViewModels
{
    class OverviewVM : INotifyPropertyChanged
    {

        private string _controller;

        // her huskes den valgte bog :-)
        private OverviewList _selectedBook;

        // Her gemmes alle bøger - observable coolection betyder at den kan notificere GUI om ændringer
        private ObservableCollection<OverviewList> _overviewlist = new ObservableCollection<OverviewList>();

        public OverviewVM()
        {
            _overviewlist.Add(new OverviewList("Etiket Operatør", "15-05-2019 / 7.30"));
            _overviewlist.Add(new OverviewList("Tappe Operatør", "15-05-2019 / 11.30"));
            _overviewlist.Add(new OverviewList("Trykkontrol", "15-05-2019 / 14.30"));
            _overviewlist.Add(new OverviewList("Færdigvare Kontrol", "15-05-2019 / 18.30"));

            LoanBookCommand = new RelayCommand(
                addLoanertoSelectedBook);

        }

        public OverviewList SelectedBook
        {
            get { return _selectedBook; }
            set
            {
                _selectedBook = value;
                OnPropertyChanged(); // fortæller XAML at property er opdateret
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

        public RelayCommand LoanBookCommand
        {
            get;
            private set;
        }

        private void addLoanertoSelectedBook()
        {
            Debug.WriteLine("add loaner");
            //Debug.WriteLine("Loaner: " + Loaner);
            //Debug.WriteLine("SelectedBook_: "+ SelectedBook.Title);
            Debug.WriteLine(SelectedBook);
            SelectedBook.Controller = Controller;
            //OnPropertyChanged("SelectedBook");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
