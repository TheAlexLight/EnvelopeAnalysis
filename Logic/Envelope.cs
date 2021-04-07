using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.EnvelopeAnalysis.Logic
{
    struct Envelope
    {
        public Envelope(int length, int width)
        {
            Length = length;
            Width = width;
        }
        public int Length { get; set; }
        public int Width { get; set; }
    }
}
