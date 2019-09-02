using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorApp;

namespace StringCalculator.CalculatorUnitTests
{
    [TestClass]
    public class AdditionTests
    {
        [DataTestMethod]
        [DataRow("2,3",5)]
        [DataRow("2,3,1",5)]
        [DataRow("-3,10",7)]
        [DataRow("3,-10",-7)]
        [DataRow("0,1,xyz,3",1)]
        [DataRow("zxy, -1, 3n, 4",-1)]
        [DataRow("0,0,xxx",0)]
        [DataRow("2,,,0,xxx",2)]
        [DataRow(",",2)]
        public void TestAddition(string addends, int expectedResult)
        {
            Calculator calc = new Calculator();
            int actualResult = calc.Add(addends);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}