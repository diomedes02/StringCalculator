using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorApp;

namespace StringCalculator.CalculatorUnitTests
{
    [TestClass]
    public class SubtractionTests
    {
        [DataTestMethod]
        [DataRow("2,3",-1)]
        [DataRow("12,3,1",8)]
        [DataRow("0,1,xyz,3",-4)]
        [DataRow("zxy, 11\n 3n, 4",-15)]
        [DataRow("0,0\nxxx",0)]
        [DataRow(",",0)]
        [DataRow(",0,3\n2",-5)]
        [DataRow("10,3,\n1\n,1,,,2",3)]
        [DataRow("*,/,\\,xxx,9,2",-11)]
        [DataRow("2,3,1000",-1)]
        [DataRow("2,3,999",-1000)]
        [DataRow("2,3,1001",-1)]
        [DataRow("562454,3,",3)]
        [DataRow("//;\n2,3\n1\n1;6",-9)]
        [DataRow("//h\n2h3,3,,\n\n,1",-5)]
        [DataRow("//a\n4a2af3",2)]
        [DataRow("//3\n,43233f35",-11)]
        [DataRow("//\n1,2,3",-4)]
        [DataRow("//[***]\n1***2,3******,\n\n5***1",-10)]
        [DataRow("//[----]\n1,3----,\n----5,1",-8)]
        [DataRow("//[***]\n100***22***33",45)]
        [DataRow("//[h]\n1,3h1h,2\n5,1",-11)]
        [DataRow("//[h][$$][***]\n1,3***1h,2\n5$$1",-11)]
        [DataRow("//[h][][***]\n1,3***1h,2\n5,1",-11)]
        [DataRow("//[*][!!][rrr]\n11rrr22*33!!44",-88)]
        [DataRow("//[][!$$!][rrr]\n11rrr22\n33!$$!44",-88)]
        public void TestSubtraction(string opValues, int expectedResult)
        {
            Console.WriteLine($"TestSubtraction. Input string parameter: {opValues}");

            InputParameters inputParams = new InputParameters
            {
                AllowNegativeNumbers = false,
                CustomDelimiter = "",
                UpperBound = 1000,
                OperationValues = opValues
            };
            Calculator calc = new Calculator(inputParams);
            int actualResult = calc.RunOperation(OperationType.Subtraction);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}