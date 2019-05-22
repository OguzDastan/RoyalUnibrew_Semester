using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class LabelingComment
    {
        public int ProcessOrderNR { get; set; }
        public int WorkerID { get; set; }
        public string Comment { get; set; }

        public LabelingComment()
        {

        }
    }
}
