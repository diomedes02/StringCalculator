using System;
using System.Collections.Generic;
using CalculatorApp.Operations;

namespace CalculatorApp
{
    public class Calculator
    {
        public int Add(string mixedParams)
        {
            Addition adOp = new Addition();

            // Get basic addend delimiters 
            char[] delimiters = GetDelimiters(mixedParams);
            string opParams = ExtractAddendParams(mixedParams);

            int result = adOp.PerformOperation(opParams, delimiters);
            Console.WriteLine(adOp.GetLog());

            return result;
        }

        private char[] GetDelimiters(string opParams)
        {
            List<char> delsList = new List<char>(){',','\n'};

            if (opParams.Length > 2 && opParams.Substring(0, 2) == "//")
            {
                char customDelimiter = opParams.ToCharArray()[2];
                delsList.Add(customDelimiter);
            }

            return delsList.ToArray();
        }

        private string ExtractAddendParams(string opParams)
        {
            if (opParams.Length > 2 && opParams.Substring(0, 2) == "//")
            {
                // split on the first newline to get the addend parameters
                string[] splitNewline = opParams.Split('\n', 2);

                if (splitNewline != null && splitNewline.Length > 1)
                {
                    return splitNewline[1];
                }
            }

            // did not find a custom delimiter
            return opParams;
        }
    }
}