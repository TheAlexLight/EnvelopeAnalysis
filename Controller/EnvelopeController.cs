using _2.EnvelopeAnalysis.Logic;
using _2.EnvelopeAnalysis.Validation;
using _2.EnvelopeAnalysis.View;
using ConsoleTaskLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.EnvelopeAnalysis.Controller
{
    class EnvelopeController
    {
        readonly ConsolePrinter _printer = new ConsolePrinter();

        public void StartEnvelopeExecution(string firstEnvelopeLength, string firstEnvelopeWidth, string secondEnvelopeLength, string secondEnvelopeWidth)
        {
            try
            {


                Envelope firstEnvelope = new Envelope()
                {
                    Length = GetEnvelopeValue(firstEnvelopeLength),

                    Width = GetEnvelopeValue(firstEnvelopeWidth)
                };

                Envelope secondEnvelope = new Envelope()
                {
                    Length = GetEnvelopeValue(secondEnvelopeLength),

                    Width = GetEnvelopeValue(secondEnvelopeWidth)
                };

                EnvelopeAnalysator analysator = new EnvelopeAnalysator(firstEnvelope);

                if (analysator.CompareTo(secondEnvelope) == 1)
                {
                    _printer.WriteLine(Constant.CAN_INSERT_ENVELOPE);
                }
                else
                {
                    _printer.WriteLine(Constant.CANNOT_INSERT_ENVELOPE);
                    _printer.ShowInstruction(Constant.INSTRUCTION, Constant.FIRST_ARGUMENT, Constant.SECOND_ARGUMENT,
                                Constant.THIRD_ARGUMENT, Constant.FOURTH_ARGUMENT);
                    Environment.Exit(-1);
                }
            }
            catch (ArgumentException ex)
            {
                _printer.WriteLine(string.Format(Constant.ERROR_OCCURED, ex.Message));
                throw;
            }
        }

        private int GetEnvelopeValue(string envelopeArgument)
        {
            Converter converterArgs = new Converter();
            Validator validArgs = new Validator();

            int result = converterArgs.TryParseToInt(envelopeArgument);

            if (result != -1)
            {
                if (!validArgs.CheckIntOnPositive(result, Constant.MAX_ENVELOPE_SIZE))
                {
                    _printer.WriteLine(Constant.WRONG_BOUNDARIES); 
                    _printer.ShowInstruction(Constant.INSTRUCTION, Constant.FIRST_ARGUMENT, Constant.SECOND_ARGUMENT,
                            Constant.THIRD_ARGUMENT, Constant.FOURTH_ARGUMENT);
                    Environment.Exit(-1);
                }
            }
            else
            {
                _printer.WriteLine(Constant.INT_WRONG_TYPE);
                _printer.ShowInstruction(Constant.INSTRUCTION, Constant.FIRST_ARGUMENT, Constant.SECOND_ARGUMENT,
                        Constant.THIRD_ARGUMENT, Constant.FOURTH_ARGUMENT);
                Environment.Exit(-1);
            }

            return result;
        }
    }
}
