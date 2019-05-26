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
        private ObservableCollection<ProcessOrderArk> _doing;
        private ObservableCollection<ProcessOrderArk> _saved;
        private ObservableCollection<ProcessOrderArk> _scheduled;

        public ObservableCollection<ProcessOrderArk> Doing
        {
            get { return _doing; }
            set { _doing = value; }
        }

        public ObservableCollection<ProcessOrderArk> Saved
        {
            get { return _saved; }
            set { _saved = value; }
        }

        public ObservableCollection<ProcessOrderArk> Scheduled
        {
            get { return _scheduled; }
            set { _scheduled = value; }
        }

        public ProcessOrderArk SelectedOrdre
        {
            get { return _selectedOrdre; }
            set
            {
                _selectedOrdre = value; 
                OnPropertyChanged();
            }
        }

        private ProcessOrderArk _selectedOrdre;


        public AdminVM()
        {
            Doing = new ObservableCollection<ProcessOrderArk>();
            Saved = new ObservableCollection<ProcessOrderArk>();
            Scheduled = new ObservableCollection<ProcessOrderArk>();
            ObservableCollection<ProcessOrderArk> alleProcesser = ProcessOrderArk.LoadAllArks();

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

    
            foreach (ProcessOrderArk item in doing)
            {
                Doing.Add(item);
            }

            foreach (ProcessOrderArk item in saved)
            {
                Saved.Add(item);
            }

            foreach (ProcessOrderArk item in scheduled)
            {
                Scheduled.Add(item);
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
