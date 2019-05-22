using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace ConsumerUWP.ViewModels
{
    public class AdminVM
    {
        private List<ProcessOrdre> _doing;
        private List<ProcessOrdre> _saved;
        private List<ProcessOrdre> _scheduled;


        public AdminVM()
        {
            Doing = new List<ProcessOrdre>();
            Saved = new List<ProcessOrdre>();
            Scheduled = new List<ProcessOrdre>();
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



        public List<ProcessOrdre> Doing
        {
            get { return _doing; }
            set { _doing = value; }
        }

        public List<ProcessOrdre> Saved
        {
            get { return _saved; }
            set { _saved = value; }
        }

        public List<ProcessOrdre> Scheduled
        {
            get { return _scheduled; }
            set { _scheduled = value; }
        }
    }
}
