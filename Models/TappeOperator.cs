using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class TappeOperator
    {
        private int PONum;
        private int liquidCode;
        private int prodNum;
        private DateTime date;
        private List<TapCheck> tapChecks;
        private List<BottleCheck> bottleCheckList;
    }
}
