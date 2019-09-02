using System;

namespace CalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("Error: No arguments found! Expected a string parameter.");
                return;
            }

            try
            {
                CalculateOperation(args[0]);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Exception: {ex}");
            }
        }

        private static void CalculateOperation(string opString)
        {
            Calculator calc = new Calculator();
            calc.Add(opString);
        }
    }
}
