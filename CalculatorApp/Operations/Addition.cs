using System;

namespace CalculatorApp.Operations
{
    public class Addition : OperationBase
    {
        public override int PerformOperation(string opParams)
        {
            int result = 0;
            string[] addends = opParams.Split(',');
            
            // clear previous results from log
            ClearLog();

            if (addends != null && addends.Length > 1)
            {
                int cnt = 0;

                foreach(string ad in addends)
                {
                    if(cnt > 0)
                        OpLog.Append("+");

                    if(Int32.TryParse(ad, out int adInt))
                    {
                        result += adInt;
                        OpLog.Append($"{adInt}");
                    }
                    else
                        OpLog.Append("0");

                    cnt++;
                }

                OpLog.Append($" = {result}");
            }
            else
                OpLog.Append($"Invalid parameter for addition operation. Parameter: {opParams}");

            return result;
        }

    }
}