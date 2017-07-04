using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StateMachineParser
{
    public class ParseErrorException : Exception
    {
        public ParseErrorException()
        {
        }

        public ParseErrorException(string message)
            : base(message)
        {
        }

        public ParseErrorException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
