using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrtReader.Exceptions
{
    class FormatHourNotCorrectException : Exception
    {
        public FormatHourNotCorrectException()
            : base("The format given can't be handled.") { }

        public FormatHourNotCorrectException(String message) 
            : base(message) { }
    }
}
