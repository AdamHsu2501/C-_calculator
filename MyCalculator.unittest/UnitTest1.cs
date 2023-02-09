using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyCalculator.unittest
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestFState()
        {
            CheckResult("5=", "5=", "5");
            CheckResult("5.=", "5=", "5");
            CheckResult("5±=", "-5=", "-5");
        }

        [TestMethod]
        public void TestFASState()
        {
            CheckResult("5+=", "5+5=", "10");
            CheckResult("3-=", "3-3=", "0");
        }

        [TestMethod]
        public void TestFMDState()
        {
            CheckResult("5*=", "5*5=", "25");
            CheckResult("3/=", "3/3=", "1");
        }

        [TestMethod]
        public void TestFASSState()
        {
            CheckResult("5+7=", "5+7=", "12");
            CheckResult("3-9=", "3-9=", "-6");
        }

        [TestMethod]
        public void TestFMDSState()
        {
            CheckResult("5*7=", "5*7=", "35");
            CheckResult("9/3=", "9/3=", "3");
        }

        [TestMethod]
        public void TestFASSASState()
        {
            CheckResult("5+7+=", "5+7+7=", "19");
            CheckResult("5+7-=", "5+7-7=", "5");
            CheckResult("5-7+=", "5-7+7=", "5");
            CheckResult("5-7-=", "5-7-7=", "-9");
        }

        [TestMethod]
        public void TestFASSMDState()
        {
            CheckResult("5+7*=", "5+7*7=", "54");
            CheckResult("5+7/=", "5+7/7=", "6");
            CheckResult("5-7*=", "5-7*7=", "-44");
            CheckResult("5-7/=", "5-7/7=", "4");
        }

        [TestMethod]
        public void TestFASSMDTState()
        {
            CheckResult("5+7*9=", "5+7*9=", "68");
            CheckResult("5+9/3=", "5+9/3=", "8");
            CheckResult("5-7*9=", "5-7*9=", "-58");
            CheckResult("5-9/3=", "5-9/3=", "2");
        }

        [TestMethod]
        public void Test1()
        {
            CheckResult("9+5-6*4/8+5*6-1/2+6=", "9+5-6*4/8+5*6-1/2+6=", "46.5");
            CheckResult("9/3*3-5+4*6-2=", "9/3*3-5+4*6-2=", "26");
        }


        public void CheckResult(string step, string formula, string answer)
        {
            CalculatorContext cal = new CalculatorContext();
            
            Calculate(cal, step);

            Assert.AreEqual(cal.GetCurrentValue(), answer);
            Assert.AreEqual(Trim(cal.GetFormula()), formula);
        }

        public string Trim(string s)
        {
            var arr = s.Split(' ');
            return string.Join("", arr);
        }

        public void Calculate(CalculatorContext cal, string fomula)
        {
            var arr = fomula.Split(' ');

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
                    case "±":
                        cal.HandleNegative();
                        break;
                    default:
                        Console.WriteLine("error " + s);
                        break;
                }
                Trace.WriteLine(s + " " + cal.GetCurrentValue());
            }
        }
    }
}
