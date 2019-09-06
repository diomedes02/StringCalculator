using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorApp;

namespace StringCalculator.CalculatorUnitTests
{
    [TestClass]
    public class CalcTests
    {
        [DataTestMethod]
        [DataRow("2,-3",true)]
        [DataRow("2,3",false)]
        [DataRow("2,3,,,5,-1,3",true)]
        [DataRow("-1,",true)]
        [DataRow(",",false)]
        public void TestNegativeAddend(string opValues, bool expectedResult)
        {
            InputParameters inputParams = new InputParameters
            {
                AllowNegativeNumbers = false,
                CustomDelimiter = "",
                UpperBound = 1000,
                OperationValues = opValues
            };
            Calculator calc = new Calculator(inputParams);

            bool actualResult = false;

            try
            {
                calc.RunOperation(OperationType.Addition);
            }
            catch(ArgumentOutOfRangeException ex)
            {
                actualResult = true;
            }

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}