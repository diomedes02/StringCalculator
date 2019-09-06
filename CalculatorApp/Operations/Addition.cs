using System;
namespace CalculatorApp.Operations
{
    public class Addition : OperationBase
    {
        public override int PerformOperation(int[] opValues)
        {
            int result = 0;

            foreach(int opVal in opValues)
            {
                result += opVal;
            }

            return result;
        }
    }
}