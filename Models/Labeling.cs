using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Labeling
    {
        public int ProcessOrderNR { get; set; }
        public TimeSpan TimeOfTest { get; set; }
        public int LableNR { get; set; }
        public DateTime ExpireyDate { get; set; }
        public int WorkerToSign { get; set; }

        public Labeling()
        {

        }
    }
}
