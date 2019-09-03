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
            char[] delimiters = ProcessDelimiters(mixedParams, out string opParams);

            int result = adOp.PerformOperation(opParams, delimiters);
            Console.WriteLine(adOp.GetLog());

            return result;
        }

        // Takes the full string parameter and extracts the custom delimeters
        // When multi-character delimeters are used, it will scrub the addends by swapping 
        //  the multi-character delimeter with a single character delimeter
        private char[] ProcessDelimiters(string mixedParams, out string opParams)
        {
            List<char> delsList = new List<char>(){',','\n'};
            opParams = ExtractAddendParams(mixedParams);

            if (mixedParams.Length > 2 && mixedParams.Substring(0, 2) == "//")
            {
                // check for multi-character delimeter
                if(mixedParams.Substring(2, 1) == "[")
                {
                    string multiCharDelimeter = mixedParams.Substring(mixedParams.IndexOf('[') + 1, mixedParams.IndexOf(']') - mixedParams.IndexOf('[') - 1);

                    // find all occurrences of the multi-char delimiter in the operator's parameter and replace with a comma (the default delimeter)
                    opParams = opParams.Replace(multiCharDelimeter, ",");
                }
                else
                {
                    char customDelimiter = mixedParams.ToCharArray()[2];
                    delsList.Add(customDelimiter);
                }
            }

            return delsList.ToArray();
        }

        private string ExtractAddendParams(string mixedParams)
        {
            if (mixedParams.Length > 2 && mixedParams.Substring(0, 2) == "//")
            {
                // split on the first newline to get the addend parameters
                string[] splitNewline = mixedParams.Split('\n', 2);

                if (splitNewline != null && splitNewline.Length > 1)
                {
                    return splitNewline[1];
                }
            }

            // did not find a custom delimiter
            return mixedParams;
        }
    }
}