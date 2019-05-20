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
        public DateTime CheckTime { get; set; }
        public string PalletID { get; set; }

        public PalletCheck()
        {

        }
    }
}
