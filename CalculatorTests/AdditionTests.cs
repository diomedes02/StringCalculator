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
        public void TestAddition(string addends, int expectedResult)
        {
            Calculator calc = new Calculator();
            int actualResult = calc.Add(addends);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [DataTestMethod]
        [DataRow("2,-3",true)]
        [DataRow("2,3",false)]
        [DataRow("2,3,,,5,-1,3",true)]
        [DataRow("-1,",true)]
        [DataRow(",",false)]
        public void TestNegativeAddend(string addends, bool expectedResult)
        {
            Calculator calc = new Calculator();
            bool actualResult = false;

            try
            {
                calc.Add(addends);
            }
            catch(ArgumentOutOfRangeException ex)
            {
                actualResult = true;
            }

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}