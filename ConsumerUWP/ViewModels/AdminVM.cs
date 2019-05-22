using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace ConsumerUWP.ViewModels
{
    public class AdminVM
    {
        private ObservableCollection<ProcessOrdre> _doing;
        private ObservableCollection<ProcessOrdre> _saved;
        private ObservableCollection<ProcessOrdre> _scheduled;


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
                Debug.WriteLine(item.ProcessOrderNR);
                Doing.Add(item);
            }

            foreach (ProcessOrdre item in saved)
            {
                Debug.WriteLine(item.ProcessOrderNR);
                Saved.Add(item);
            }

            foreach (ProcessOrdre item in scheduled)
            {
                Debug.WriteLine(item.ProcessOrderNR);
                Scheduled.Add(item);
            }

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
    }
}
