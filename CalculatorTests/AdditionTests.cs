using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorApp;

namespace StringCalculator.CalculatorUnitTests
{
    [TestClass]
    public class AdditionTests
    {
        [DataTestMethod]
        [DataRow("2,3",5)]
        [DataRow("2,3,1",6)]
        [DataRow("0,1,xyz,3",4)]
        [DataRow("zxy, 1\n 3n, 4",5)]
        [DataRow("0,0\nxxx",0)]
        [DataRow(",",0)]
        [DataRow(",0,3\n2",5)]
        [DataRow("0,0,3,\n1\n,1,,,2",7)]
        [DataRow("*,/,\\,xxx,9,2",11)]
        [DataRow("2,3,1000",5)]
        [DataRow("2,3,999",1004)]
        [DataRow("2,3,1001",5)]
        [DataRow("2,3,156001",5)]
        [DataRow("//;\n2,3\n1\n1;6",13)]
        [DataRow("//h\n2h3,3,,\n\n,1",9)]
        [DataRow("//a\n,4a2af3",6)]
        [DataRow("//3\n,43233f35",11)]
        [DataRow("//\n1,2,3",6)]
        [DataRow("//[***]\n1***2,3******,\n\n5***1",12)]
        [DataRow("//[----]\n1,3----,\n----5,1",10)]
        [DataRow("//[***]\n11***22***33",66)]
        [DataRow("//[h]\n1,3h1h,2\n5,1",13)]
        [DataRow("//[h][$$][***]\n1,3***1h,2\n5$$1",13)]
        [DataRow("//[h][][***]\n1,3***1h,2\n5,1",13)]
        [DataRow("//[*][!!][rrr]\n11rrr22*33!!44",110)]
        [DataRow("//[][!$$!][rrr]\n11rrr22\n33!$$!44",110)]
        public void TestAddition(string opValues, int expectedResult)
        {
            Console.WriteLine($"TestAddition. Input string parameter: {opValues}");
            
            InputParameters inputParams = new InputParameters
            {
                AllowNegativeNumbers = false,
                CustomDelimiter = "",
                UpperBound = 1000,
                OperationValues = opValues
            };
            Calculator calc = new Calculator(inputParams);
            int actualResult = calc.RunOperation(OperationType.Addition);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}