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
                bool restartProgram = true;

                while (restartProgram)
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

                    _printer.WriteLine(Constant.RESTART_PROGRAM_PROMPT);
                    string checkAnswer = _printer.ReadLine();

                    if (!checkAnswer.ToUpper().Equals(Constant.SIMPLE_YES) || checkAnswer.ToUpper().Equals(Constant.YES))
                    {
                        restartProgram = false;
                        continue;
                    }

                    Console.Clear();
                   string[] newArgs = EnterNewEnvelope();

                    firstEnvelopeLength = newArgs[0];
                    firstEnvelopeWidth = newArgs[1];
                    secondEnvelopeLength = newArgs[2];
                    secondEnvelopeWidth = newArgs[3];
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

        public string[] EnterNewEnvelope()
        {
            _printer.WriteLine(Constant.ENTER_PROMPT);

            string[] newArgs = _printer.ReadLine().Split(',');

            if (newArgs.Length != 4)
            {
                _printer.WriteLine(Constant.WRONG_NEW_ARGUMENTS);

                _printer.ShowInstruction(Constant.INSTRUCTION, Constant.FIRST_ARGUMENT,
                           Constant.SECOND_ARGUMENT, Constant.THIRD_ARGUMENT, Constant.FOURTH_ARGUMENT);

                Environment.Exit(-1);
            }

            newArgs = RemoveSpaces(newArgs);
            newArgs = RemoveTabulation(newArgs);

            for (int i = 0; i < newArgs.Length; i++)
            {
                if (newArgs[i] == "")
                {
                    _printer.WriteLine(Constant.WRONG_NEW_ARGUMENTS);

                    _printer.ShowInstruction(Constant.INSTRUCTION, Constant.FIRST_ARGUMENT,
                               Constant.SECOND_ARGUMENT, Constant.THIRD_ARGUMENT, Constant.FOURTH_ARGUMENT);

                    Environment.Exit(-1);
                }
            }

            return newArgs;
        }

        public string[] RemoveSpaces(string[] newArgs)
        {
            for (int i = 0; i < newArgs.Length; i++)
            {
                newArgs[i] = newArgs[i].Replace(" ", "");
            }

            return newArgs;
        }

        public string[] RemoveTabulation(string[] newArgs)
        {
            for (int i = 0; i < newArgs.Length; i++)
            {
                newArgs[i] = newArgs[i].Replace("    ", "");
            }

            return newArgs;
        }
    }
}
