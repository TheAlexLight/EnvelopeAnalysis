using _2.EnvelopeAnalysis.Controller;
using _2.EnvelopeAnalysis.Logic;
using _2.EnvelopeAnalysis.View;
using ConsoleTaskLibrary;
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
            try
            {
                if (args.Length != 4)
                {
                    throw new ArgumentException();
                }

                EnvelopeController controller = new EnvelopeController();

                controller.StartEnvelopeExecution(args[0], args[1], args[2], args[3]);
            }
            catch (Exception)
            {
                ConsolePrinter _printer = new ConsolePrinter();
                _printer.ShowInstruction(Constant.INSTRUCTION, Constant.FIRST_ARGUMENT, Constant.SECOND_ARGUMENT,
                        Constant.THIRD_ARGUMENT, Constant.FOURTH_ARGUMENT);
                throw;
            }
        }
    }
}
