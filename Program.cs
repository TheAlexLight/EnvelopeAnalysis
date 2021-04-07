using _2.EnvelopeAnalysis.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.EnvelopeAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            Envelope env1 = new Envelope(10,20);
            Envelope env2 = new Envelope(5,5);

            EnvelopeAnalysator analysator = new EnvelopeAnalysator(env1);

            Console.WriteLine(analysator.CompareTo(env2)); 
        }
    }
}
