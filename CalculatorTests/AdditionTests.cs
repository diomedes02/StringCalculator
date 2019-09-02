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
        [DataRow("-3,10",7)]
        [DataRow("3,-10",-7)]
        [DataRow("0,1,xyz,3",4)]
        [DataRow("zxy, -1, 3n, 4",3)]
        [DataRow("0,0,xxx",0)]
        [DataRow(",",0)]
        [DataRow(",0,3,2",5)]
        [DataRow("0,0,3,,,,1,,,-2",2)]
        [DataRow("*,/,\\,xxx,9,2",11)]
        public void TestAddition(string addends, int expectedResult)
        {
            Calculator calc = new Calculator();
            int actualResult = calc.Add(addends);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}