using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.EnvelopeAnalysis.Logic
{
    class EnvelopeAnalysator: IComparable<Envelope>
    {
        public EnvelopeAnalysator(Envelope mainEnvelope)
        {
            MainEnvelope = mainEnvelope; 
        }

        Envelope MainEnvelope { get; set; }

        public int CompareTo(Envelope comparedEnvelope)
        {
            if (((comparedEnvelope.Length < MainEnvelope.Length) && (comparedEnvelope.Width < MainEnvelope.Width))
                || ((comparedEnvelope.Length < MainEnvelope.Width) && (comparedEnvelope.Width < MainEnvelope.Length)))
            {
                return 1;
            }
            else if (((comparedEnvelope.Length > MainEnvelope.Length) || (comparedEnvelope.Width > MainEnvelope.Length))
                || ((comparedEnvelope.Width > MainEnvelope.Width) || (comparedEnvelope.Length < MainEnvelope.Width)))
            {
                return -1;
            }

            return 0;
        }
    }
}
