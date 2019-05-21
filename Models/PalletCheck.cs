using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PalletCheck
    {
        public int ProcessOrderNR { get; set; }
        public DateTime TimeOfTest { get; set; }
        public string Pallet { get; set; }
        public int WorkerID { get; set; }

        public PalletCheck()
        {

        }
    }
}
