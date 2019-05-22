 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ProcessOrdre
    {
        public int ProcessOrderNR { get; set; }
        public int ColumnNR { get; set; }
        public int EndproductNR { get; set; }
        public DateTime ProcessDate { get; set; }
        public string EndProductName { get; set; }
        public char Process { get; set; }

        public ProcessOrdre()
        {

        }
    }
}
