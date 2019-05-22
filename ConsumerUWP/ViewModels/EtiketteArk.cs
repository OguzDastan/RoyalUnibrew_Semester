using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace ConsumerUWP.ViewModels
{
    class EtiketteArk : ProcessOrdre
    {
        public EtiketteArk()
        {
        }

        class PalleCheck
        {
            public TimeSpan TimeOfTest { get; set; }
            public string Pallet { get; set; }
            public string WorkerSign { get; set; }
        }
        class LabelCheck
        {
            public TimeSpan TimeOfTest { get; set; }
            public DateTime ExpireDate { get; set; }
            public int MyProperty { get; set; }
        }
    }
}
