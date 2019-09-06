using System;
using System.Text;
using System.Collections.Generic;
using CalculatorApp.Operations;

namespace CalculatorApp
{
    public class Calculator
    {
        public Calculator(InputParameters inputParams)
        {
            InputParameters = inputParams;
            CalcLog = new StringBuilder();
        }

        public StringBuilder CalcLog {get; set;}
        public String GetLog() => CalcLog.ToString();
        public void ClearLog() => CalcLog.Clear();

        public InputParameters InputParameters {get; private set;}
        public string OperationParams { get; set; }

        public int RunOperation(OperationType opType)
        {
            string operationStr = "";
            int result = 0;
            string delimiterScrubbedOpParams = ProcessDelimiters(InputParameters.OperationValues, InputParameters.CustomDelimiter);
            List<int> opValues = new List<int>();

            switch(opType)
            {
                case OperationType.Addition:
                    operationStr = "+";
                    opValues = ProcessOperationParameters(operationStr, delimiterScrubbedOpParams, InputParameters);
                    result = Add(opValues);
                    break;
                case OperationType.Subtraction:
                    operationStr = "-";
                    opValues = ProcessOperationParameters(operationStr, delimiterScrubbedOpParams, InputParameters);
                    result = Subtract(opValues);
                    break;
                case OperationType.Multiplication:
                    operationStr = "*";
                    opValues = ProcessOperationParameters(operationStr, delimiterScrubbedOpParams, InputParameters);
                    result = Multiplication(opValues);
                    break;
                case OperationType.Division:
                    operationStr = "/";
                    opValues = ProcessOperationParameters(operationStr, delimiterScrubbedOpParams, InputParameters);
                    result = Division(opValues);
                    break;
            }

            CalcLog.Append($" = {result}");
            Console.WriteLine(GetLog());
            ClearLog();

            return result;
        }

        private int Add(List<int> opValues)
        {
            Addition op = new Addition();
            return op.PerformOperation(opValues.ToArray());
        }

        private int Subtract(List<int> opValues)
        {
            Subtraction op = new Subtraction();
            return op.PerformOperation(opValues.ToArray());
        }

        private int Multiplication(List<int> opValues)
        {
            Multiplication op = new Multiplication();
            return op.PerformOperation(opValues.ToArray());
        }

        private int Division(List<int> opValues)
        {
            Division op = new Division();
            return op.PerformOperation(opValues.ToArray());
        }

        private List<int> ProcessOperationParameters(string logOpStr, string scrubbedOpParams, InputParameters inputParams)
        {
            List<int> opValueList = new List<int>();
            string[] rawValues = scrubbedOpParams.Split(',');
            int upperBound = inputParams.UpperBound.GetValueOrDefault(0);

            if (rawValues == null || rawValues.Length < 2)
            {
                CalcLog.Append($"Invalid parameter for operation. Parameter: {scrubbedOpParams}");
                return null;
            }

            int cnt = 0;
            bool foundNegNum = false;
            StringBuilder sbNegNum = new StringBuilder();

            foreach(string val in rawValues)
            {
                if(cnt > 0)
                    CalcLog.Append(logOpStr);

                if(Int32.TryParse(val, out int adInt))
                {
                    // check for negative number
                    if(adInt < 0)
                    {
                        if (inputParams.AllowNegativeNumbers)
                        {
                            opValueList.Add(adInt);
                            CalcLog.Append($"{adInt}");
                        }
                        else
                        {
                            // save the negative number for printing in the exception
                            if(sbNegNum.Length > 0)
                                sbNegNum.Append(",");

                            sbNegNum.Append(adInt);
                            foundNegNum = true;
                        }
                    }
                    // set upper bound if one was chosen
                    else if (upperBound > 1)
                    {
                        if(adInt < upperBound)
                        {
                            opValueList.Add(adInt);
                            CalcLog.Append($"{adInt}");
                        }
                        else
                            CalcLog.Append("0");
                    }
                    else
                    {
                        opValueList.Add(adInt);
                        CalcLog.Append($"{adInt}");
                    }
                }
                else
                {
                    opValueList.Add(0);
                    CalcLog.Append("0");
                }

                cnt++;
            }

            if (foundNegNum)
            {
                CalcLog.Append("Negative values found: " + sbNegNum);
                throw new ArgumentOutOfRangeException("Negative values are not allowed! Set the proper parameter to allow negatives values.");
            }

            return opValueList;
        }

        // Takes the full string parameter and extracts the custom delimiters then replaces them with commas in the addend parameter string.
        // Returns the operation parameter string 
        private string ProcessDelimiters(string mixedParams, string customDelimiter)
        {
            string opParams = ExtractValueParams(mixedParams);

            // convert newline and custom delimiters to commas (standardize)
            opParams = opParams.Replace('\n', ',');
            if(customDelimiter != null && customDelimiter.Length > 0)
            {
                opParams = opParams.Replace(customDelimiter, ",");
            }

            if (mixedParams.Length > 2 && mixedParams.Substring(0, 2) == "//")
            {
                // check for multi-character delimiter
                if(mixedParams.Substring(2, 1) == "[")
                {
                    int lastOpenBraceIndex = 0;

                    while(true)
                    {
                        // find the index of the next open and closing braces
                        lastOpenBraceIndex = mixedParams.IndexOf('[', lastOpenBraceIndex + 1);
                        int lastClosedBraceIndex = mixedParams.IndexOf(']', lastOpenBraceIndex + 1);

                        // break out of loop once a next open brace is not found or if we surpass the newline delimiter
                        if (lastOpenBraceIndex == -1 || lastClosedBraceIndex > mixedParams.IndexOf('\n'))
                            break;

                        string multiCharDelimiter = mixedParams.Substring(lastOpenBraceIndex + 1, lastClosedBraceIndex - lastOpenBraceIndex - 1);

                        if (multiCharDelimiter.Length > 0)
                        {
                            // find all occurrences of the multi-char delimiter in the operator's parameter and replace with a comma (the default delimiter)
                            opParams = opParams.Replace(multiCharDelimiter, ",");
                        }
                    }
                }
                else
                {
                    // input scenario: single custom delimiter without braces
                    char customSingleDelimiter = mixedParams.ToCharArray()[2];
                    
                    // scrub the custom delimiter from the operation parameter
                    opParams = opParams.Replace(customSingleDelimiter, ',');
                }
            }

            return opParams;
        }

        private string ExtractValueParams(string mixedParams)
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