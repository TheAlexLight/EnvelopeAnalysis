using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.EnvelopeAnalysis.View
{
    class Constant
    {
        public const int MAX_ENVELOPE_SIZE = 20;

        public const string WRONG_BOUNDARIES = "Wrong number boundaries, try again";
        public const string INSTRUCTION = "Instruction of using: You should use 2 arguments:";
        public const string FIRST_ARGUMENT = "1 argument - first envelope length: Type - Integer(Greater than 0)";
        public const string SECOND_ARGUMENT = "2 argument - first envelope width: Type - Integer(Greater than 0)";
        public const string THIRD_ARGUMENT = "3 argument - second envelope length: Type - Integer(Greater than 0)";
        public const string FOURTH_ARGUMENT = "4 argument - second envelope width: Type - Integer(Greater than 0)";
        public const string INT_WRONG_TYPE = "Type of data should be integer, try again";
        public const string CAN_INSERT_ENVELOPE = "Second envelope can be inserted in the first";
        public const string CANNOT_INSERT_ENVELOPE = "Second envelope cannot be inserted in the first";
        public const string ERROR_OCCURED = "ERROR occured";
        public const string START_PROGRAM_AGAIN = "ERROR occured";
    }
}
