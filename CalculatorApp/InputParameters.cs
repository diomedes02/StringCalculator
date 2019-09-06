using System;
using System.Text;

namespace CalculatorApp
{
    public class InputParameters
    {
        public bool AllowNegativeNumbers { get; set; }

        public string CustomDelimiter { get; set; }

        public int? UpperBound { get; set; }

        public string OperationValues { get; set; }
    }
}