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
using Models;

namespace ConsumerUWP.ViewModels
{
    public class AdminVM : INotifyPropertyChanged
    {
        private ObservableCollection<ProcessOrdre> _doing;
        private ObservableCollection<ProcessOrdre> _saved;
        private ObservableCollection<ProcessOrdre> _scheduled;
        private ProcessOrdre _selectedOrdre;

        public ProcessOrdre SelectedOrdre {
            get {
                return _selectedOrdre;
            }
            set {
                    _selectedOrdre = value;
                    OnPropertyChanged();
                }
        }



        public AdminVM()
        {
            

            Doing = new ObservableCollection<ProcessOrdre>();
            Saved = new ObservableCollection<ProcessOrdre>();
            Scheduled = new ObservableCollection<ProcessOrdre>();
            List<ProcessOrdre> alleProcesser = ProcessOrderArk.LoadAllArks();

            var doing =
                    from ark in alleProcesser
                    where ark.Process == 'd'
                    select ark;

            var saved =
                    from ark in alleProcesser
                    where ark.Process == 'a'
                    select ark;

            var scheduled =
                    from ark in alleProcesser
                    where ark.Process == 'p'
                    select ark;

    
            foreach (ProcessOrdre item in doing)
            {
                Doing.Add(item);
            }

            foreach (ProcessOrdre item in saved)
            {
                Saved.Add(item);
            }

            foreach (ProcessOrdre item in scheduled)
            {
                Scheduled.Add(item);
            }


            SelectedOrdre = doing.First<ProcessOrdre>();
        }

        public ObservableCollection<ProcessOrdre> Doing
        {
            get { return _doing; }
            set { _doing = value; }
        }

        public ObservableCollection<ProcessOrdre> Saved
        {
            get { return _saved; }
            set { _saved = value; }
        }

        public ObservableCollection<ProcessOrdre> Scheduled
        {
            get { return _scheduled; }
            set { _scheduled = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
