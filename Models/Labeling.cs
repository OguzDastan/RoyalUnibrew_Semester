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
        public DateTime CheckTime { get; set; }
        public int LableNR { get; set; }
        public DateTime ExpireDate { get; set; }
        public string SignForTest { get; set; }

        public Labeling()
        {

        }
    }
}
