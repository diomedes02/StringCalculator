using System;

namespace CalculatorApp.Operations
{
    public class Subtraction : OperationBase
    {
        public override int PerformOperation(int[] opValues)
        {
            int result = 0;

            for(int i = 0; i < opValues.Length; i++)
            {
                if (i == 0)
                    result = opValues[i];
                else
                    result -= opValues[i];
            }

            return result;
        }
    }
}