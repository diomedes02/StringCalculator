using System;
using CalculatorApp.Operations;

namespace CalculatorApp
{
    public class Calculator
    {
        public int Add(string addOperation)
        {
            Addition adOp = new Addition();
            int result = adOp.PerformOperation(addOperation);
            Console.WriteLine(adOp.GetLog());

            return result;
        }
    }
}