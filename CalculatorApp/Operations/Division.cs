using System;

namespace CalculatorApp.Operations
{
    public class Division : OperationBase
    {
        public override int PerformOperation(int[] opValues)
        {
            int result = 0;

            for(int i = 0; i < opValues.Length; i++)
            {
                if (i == 0)
                {
                    if (opValues[i] == 0)
                        return 0;  // zero divided by anything is zero
                    else
                        result = opValues[i];
                }
                else
                {
                    if(opValues[i] == 0) // avoid dividing by zero
                        continue;
                    else
                        result /= opValues[i];
                }
            }

            return result;
        }
    }
}