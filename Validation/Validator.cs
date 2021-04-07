using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.EnvelopeAnalysis.Validation
{
    class Validator
    {
        public bool CheckIntOnPositive(int intToCheck, int maxValue)
        {
            return (intToCheck > 0 && intToCheck <= maxValue);
        }
    }
}
