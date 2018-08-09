using System;
using System.Collections.Generic;
using System.Text;

namespace ArithmeticProgression
{
    public class ArithmeticProgressionTooSmallException : Exception
    {
        public override string Message
        {
            get { return "The progression must contain at least 3 values to be valid and have missing values."; }
        }
    }
}
