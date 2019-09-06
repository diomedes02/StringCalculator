using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorApp;

namespace StringCalculator.CalculatorUnitTests
{
    [TestClass]
    public class DivisionTests
    {
        [DataTestMethod]
        [DataRow("20,2",10)]
        [DataRow("20,2,2",5)]
        [DataRow("0,1,xyz,3",0)]
        [DataRow("zxy, 1\n 3n, 4",0)]
        [DataRow("10,0\nxxx",10)]
        [DataRow("10,0\nxxx,5",2)]
        public void TestDivision(string opValues, int expectedResult)
        {
            Console.WriteLine($"TestDivision. Input string parameter: {opValues}");

            InputParameters inputParams = new InputParameters
            {
                AllowNegativeNumbers = false,
                CustomDelimiter = "",
                UpperBound = 1000,
                OperationValues = opValues
            };
            Calculator calc = new Calculator(inputParams);
            int actualResult = calc.RunOperation(OperationType.Division);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}