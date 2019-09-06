using System;

namespace CalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string helpMessage = "Calculator parameters: -<a,s,m,d> -scd=<single custom delimiter> <0,1> -ub=<upper bound> <StringOfValuesToCalculate>\n" +
                                 "Parameter 1: Math operations (-a = addition, -s = subtraction, -m = multiplication, -d division\n" +
                                 "Parameter 2 (optional): single custom delimiter\n" +
                                 "Parameter 3 (optional, defaults to false): 1 = allow negative number, 0 = throw exception for negative number\n" +
                                 "Parameter 4 (optional): An integer representing the upper bound of the numbers to be calculated. Numbers >= upper bound will be ignored.\n" +
                                 "Parameter 5: CSV (or alternate delimiter) string of numbers to perform Math operation on";

            try
            {
                if (args == null || args.Length < 3)
                {
                    Console.WriteLine("Error: Invalid or wrong number of arguments encountered!\n" + helpMessage);
                    return;
                }

                if (args[0].ToLower() == "help")
                {
                    Console.WriteLine(helpMessage);
                    return;
                }

                CalculateOperation(args);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Exception: {ex}");
            }
        }

        private static void CalculateOperation(string[] args)
        {
            OperationType operationType = GetOperationType(args[0]);

            if(operationType == OperationType.Unknown)
            {
                Console.WriteLine("Error parsing the operation (first) parameter. Expected one of these: [-a,-s,-m,-d]\nUse \"help\" as first parameter for more info.");
                return;
            }

            InputParameters inputParams = ParseArguments(args);

            Calculator calc = new Calculator(inputParams);
            calc.RunOperation(operationType);
        }

        private static InputParameters ParseArguments(string[] args)
        {
            bool allowNegatives = false;
            string customDelimiter = "";
            int? upperBound = null;
            string operationParams = "";

            for(int i = 0; i < args.Length; i++)
            {
                // skip the operation type arg since it was parsed separately
                if(i == 0)
                    continue;

                if (args[i].Contains("-scd="))
                {
                    string[] scdAry = args[i].Split('=');
                    if (scdAry.Length > 1)
                        customDelimiter = scdAry[1];
                }
                else if(args[i].Contains("-ub="))
                {
                    string[] ubAry = args[i].Split('=');
                    if (ubAry.Length > 1 && Int32.TryParse(ubAry[1], out int upBound))
                        upperBound = upBound;
                }
                else if (args[i] == "1" || args[i] == "0")
                {
                    allowNegatives = args[i] == "1";
                }
                else
                {
                    operationParams = args[i];
                }
            }

            InputParameters inputParams = new InputParameters
            {
                AllowNegativeNumbers = allowNegatives,
                CustomDelimiter = customDelimiter,
                UpperBound = upperBound,
                OperationValues = operationParams
            };

            return inputParams;
        }

        private static OperationType GetOperationType(string opTypeArg)
        {
            switch(opTypeArg)
            {
                case "-a":
                    return OperationType.Addition;
                case "-s":
                    return OperationType.Subtraction;
                case "-m":
                    return OperationType.Multiplication;
                case "-d":
                    return OperationType.Division;
                default:
                    return OperationType.Unknown;
            }
        }
    }
}
