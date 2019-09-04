using System;
using System.Text;

namespace CalculatorApp.Operations
{
    public abstract class OperationBase
    {
        public OperationBase()
        {
            OpLog = new StringBuilder();
        }

        public StringBuilder OpLog {get; set;}

        public String GetLog()
        {
            return OpLog.ToString();
        }

        public void ClearLog()
        {
            OpLog.Clear();
        }

        public abstract int PerformOperation(string opParams);

    }
}