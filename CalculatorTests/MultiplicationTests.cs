using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorApp;

namespace StringCalculator.CalculatorUnitTests
{
    [TestClass]
    public class MultiplicationTests
    {
        [DataTestMethod]
        [DataRow("2,3",6)]
        [DataRow("2,3,1",6)]
        [DataRow("0,1,xyz,3",0)]
        [DataRow("zxy, 1\n 3n, 4",0)]
        [DataRow("0,0\nxxx",0)]
        [DataRow(",",0)]
        [DataRow("0,0,3,\n1\n,1,,,2",0)]
        [DataRow("*,/,\\,xxx,9,2",0)]
        [DataRow("2,3,1000",6)]
        [DataRow("2,3,999",5994)]
        [DataRow("2,3,1001",6)]
        [DataRow("//;\n2,3\n1\n1;6",36)]
        [DataRow("//\n1,2,3",6)]
        [DataRow("//[***]\n1***2,3******,\n\n5***1",0)]
        [DataRow("//[*][!!][rrr]\n11rrr22*33!!44",351384)]
        public void TestMultiplication(string opValues, int expectedResult)
        {
            Console.WriteLine($"TestMultiplication. Input string parameter: {opValues}");

            InputParameters inputParams = new InputParameters
            {
                AllowNegativeNumbers = false,
                CustomDelimiter = "",
                UpperBound = 1000,
                OperationValues = opValues
            };
            Calculator calc = new Calculator(inputParams);
            int actualResult = calc.RunOperation(OperationType.Multiplication);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}