using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class TapCheck
    {
        private DateTime time;
        private int lidNr;
        private int preFormNum;
        private List<float> bottletorque;
        private bool heuftLid;
        private bool heuftFill;
        private struct tasteTest
        {
            public string tank;

            public bool OK;

            public tasteTest(string Tank, bool ok)
            {
                tank = Tank;
                OK = ok;
            }
        }

        private bool sugarStickTest;
        private bool dropTest;
        private List<float> bottleWeight;
        private float bottleWeightAvg;
        private string dropTestComment;
        private string operatorSign;

    }
}
