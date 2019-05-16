using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerUWP.ViewModels
{
    public class AdminVM
    {
        private List<ProcessOrd> doing;
        private List<ProcessOrd> saved;
        private List<ProcessOrd> scheduled;
        

        public AdminVM()
        {
            Doing = new List<ProcessOrd>();
            Doing.Add(new ProcessOrd(DateTime.Now, 1));
            Doing.Add(new ProcessOrd(DateTime.Now, 2));
            Doing.Add(new ProcessOrd(DateTime.Now, 3));
            Doing.Add(new ProcessOrd(DateTime.Now, 4));
            Doing.Add(new ProcessOrd(DateTime.Now, 5));
            Doing.Add(new ProcessOrd(DateTime.Now, 6));
            Doing.Add(new ProcessOrd(DateTime.Now, 7));

            Saved = Doing;
            Scheduled = Doing;

        }

        

        public List<ProcessOrd> Doing
        {
            get { return doing; }
            set { doing = value; }
        }

        public List<ProcessOrd> Saved
        {
            get { return saved; }
            set { saved = value; }
        }

        public List<ProcessOrd> Scheduled
        {
            get { return scheduled; }
            set { scheduled = value; }
        }
    }
    public class ProcessOrd
    {
        private DateTime date;
        private int _nummer;
        public ProcessOrd(DateTime d, int n)
        {
            Date = d;
            Nummer = n;
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public int Nummer
        {
            get { return _nummer; }
            set { _nummer = value; }
        }
    }
}
