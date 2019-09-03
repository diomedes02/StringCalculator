using System;
using System.Text;

namespace CalculatorApp.Operations
{
    public class Addition : OperationBase
    {
        public override int PerformOperation(string opParams)
        {
            int result = 0;
            string[] addends = opParams.Split(new char[]{',', '\n'});
            
            // clear previous results from log
            ClearLog();

            if (addends != null && addends.Length > 1)
            {
                int cnt = 0;
                bool foundNegNum = false;
                StringBuilder sbNegNum = new StringBuilder();

                foreach(string ad in addends)
                {
                    if(cnt > 0)
                        OpLog.Append("+");

                    if(Int32.TryParse(ad, out int adInt))
                    {
                        // check for negative number
                        if(adInt < 0)
                        {
                            // save the negative number for printing in the exception
                            if(sbNegNum.Length > 0)
                                sbNegNum.Append(",");

                            sbNegNum.Append(adInt);
                            foundNegNum = true;
                        }
                        else  // add to result
                            result += adInt;

                        OpLog.Append($"{adInt}");
                    }
                    else
                        OpLog.Append("0");

                    cnt++;
                }

                if (foundNegNum)
                {
                    OpLog.Append("Negative values found: " + sbNegNum);
                    throw new ArgumentOutOfRangeException("Negative values are not allowed!");
                }

                OpLog.Append($" = {result}");
            }
            else
                OpLog.Append($"Invalid parameter for addition operation. Parameter: {opParams}");

            return result;
        }

    }
}