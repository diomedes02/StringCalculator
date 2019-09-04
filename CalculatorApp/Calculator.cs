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
            string opParams = ProcessDelimiters(mixedParams);

            int result = adOp.PerformOperation(opParams);
            Console.WriteLine(adOp.GetLog());

            return result;
        }

        // Takes the full string parameter and extracts the custom delimeters then replaces them with commas in the addend parameter string.
        // Returns the operation parameter string 
        private string ProcessDelimiters(string mixedParams)
        {
            string opParams = ExtractAddendParams(mixedParams);

            // convert newline delimiters to commas (standardize)
            opParams = opParams.Replace('\n', ',');

            if (mixedParams.Length > 2 && mixedParams.Substring(0, 2) == "//")
            {
                // check for multi-character delimeter
                if(mixedParams.Substring(2, 1) == "[")
                {
                    int lastOpenBraceIndex = 0;

                    while(true)
                    {
                        // find the index of the next open and closing braces
                        lastOpenBraceIndex = mixedParams.IndexOf('[', lastOpenBraceIndex + 1);
                        int lastClosedBraceIndex = mixedParams.IndexOf(']', lastOpenBraceIndex + 1);

                        // break out of loop once a next open brace is not found or if we surpass the newline delimeter
                        if (lastOpenBraceIndex == -1 || lastClosedBraceIndex > mixedParams.IndexOf('\n'))
                            break;

                        string multiCharDelimeter = mixedParams.Substring(lastOpenBraceIndex + 1, lastClosedBraceIndex - lastOpenBraceIndex - 1);

                        Console.WriteLine($"Parsed multiCharDelimeter: {multiCharDelimeter}");

                        if (multiCharDelimeter.Length > 0)
                        {
                            // find all occurrences of the multi-char delimiter in the operator's parameter and replace with a comma (the default delimeter)
                            opParams = opParams.Replace(multiCharDelimeter, ",");

                            Console.WriteLine($"Scrubbed opParams after replace: {opParams}");
                        }
                    }
                }
                else
                {
                    // input scenario: single custom delimeter without braces
                    char customDelimiter = mixedParams.ToCharArray()[2];
                    
                    // scrub the custom delimeter from the operation parameter
                    opParams = opParams.Replace(customDelimiter, ',');
                }
            }

            return opParams;
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