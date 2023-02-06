using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyCalculator.unittest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestFState()
        {
            Assert.AreEqual(Calculator("5="), "5");
            Assert.AreEqual(Calculator("5.="), "5");
            Assert.AreEqual(Calculator("-5="), "-5");
        }

        [TestMethod]
        public void TestFASState()
        {
            Assert.AreEqual(Calculator("5+="), "10");
            Assert.AreEqual(Calculator("3-="), "0");
        }

        [TestMethod]
        public void TestFMDState()
        {
            Assert.AreEqual(Calculator("5*="), "25");
            Assert.AreEqual(Calculator("3/="), "1");
        }

        [TestMethod]
        public void TestFASSState()
        {
            Assert.AreEqual(Calculator("5+7="), "12");
            Assert.AreEqual(Calculator("3-9="), "-6");
        }

        [TestMethod]
        public void TestFMDSState()
        {
            Assert.AreEqual(Calculator("5*7="), "35");
            Assert.AreEqual(Calculator("9/3="), "3");
        }

        [TestMethod]
        public void TestFASSASState()
        {
            Assert.AreEqual(Calculator("5+7+="), "19");
            Assert.AreEqual(Calculator("5+7-="), "5");
            Assert.AreEqual(Calculator("5-7+="), "5");
            Assert.AreEqual(Calculator("5-7-="), "-9");
        }

        [TestMethod]
        public void TestFASSMDState()
        {
            Assert.AreEqual(Calculator("5+7*="), "54");
            Assert.AreEqual(Calculator("5+7/="), "6");
            Assert.AreEqual(Calculator("5-7*="), "-44");
            Assert.AreEqual(Calculator("5-7/="), "4");
        }

        [TestMethod]
        public void TestFASSMDTState()
        {
            Assert.AreEqual(Calculator("5+7*9="), "68");
            Assert.AreEqual(Calculator("5+9/3="), "8");
            Assert.AreEqual(Calculator("5-7*9="), "-58");
            Assert.AreEqual(Calculator("5-9/3="), "2");
        }
        
        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual(Calculator("9+5-6*4/8+5*6-1/2+6="), "46.5");
        }

        public string Calculator(string fomula)
        {
            var cal = new CalculatorContext();

            foreach (char c in fomula)
            {
                string s = c.ToString();
                switch (s)
                {
                    case "0":
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                    case ".":
                        cal.HandleOperand(s);
                        break;
                    case "+":
                        cal.HandleOperatorSimple(new Addition(), s);
                        break;
                    case "-":
                        cal.HandleOperatorSimple(new Subtraction(), s);
                        break;
                    case "*":
                        cal.HandleOperatorComplex(new Multiplication(), s);
                        break;
                    case "/":
                        cal.HandleOperatorComplex(new Division(), s);
                        break;
                    case "=":
                        cal.HandleEqual(s);
                        break;
                    default:
                        Console.WriteLine("error " + s);
                        break;
                }
            }
            return cal.GetCurrentValue();
        }
    }
}
