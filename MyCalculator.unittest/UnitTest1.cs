using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCalculatorAPI;

namespace MyCalculator.unittest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestInitialState()
        {
            string inputs = "";
            HandleBackspace(inputs, "0", "Operand State", "", 1, 0);
            HandleClear(inputs, "0", "Initial State", "", 1, 0);
            HandleClearEntry(inputs, "0", "Operand State", "", 1, 0);
            HandleEqual(inputs, "0", "Equal State", "0 =", 1, 0, "0", "0", "0");
            HandleNegative(inputs, "0", "Operand State", "", 1, 0);
            HandleSquareRoot(inputs, "0", "Operand State", "", 1, 0);
            HandleLeftParenthesis(inputs, "0", "Parenthesis State", "(", 1, 1);
            HandleRightParenthesis(inputs, "0", "Initial State", "", 1, 0);
            HandleNumber(inputs, "2", "2", "Operand State", "", 1, 0);
            HandleDecimalPoint(inputs, ".", "0.", "Operand State", "", 1, 0);
            HandleAddition(inputs, "0", "Operator State", "0 +", 1, 0);
            HandleSubtraction(inputs, "0", "Operator State", "0 -", 1, 0);
            HandleMultiplication(inputs, "0", "Operator State", "0 *", 1, 0);
            HandleDivision(inputs, "0", "Operator State", "0 /", 1, 0);
        }

       

        [TestMethod]
        public void TestOperandState()
        {
            string inputs = "16";
            HandleBackspace(inputs, "1", "Operand State", "", 1, 0);
            HandleClear(inputs, "0", "Initial State", "", 1, 0);
            HandleClearEntry(inputs, "0", "Operand State", "", 1, 0);
            HandleEqual(inputs, "16", "Equal State", "16 =", 1, 0, "16", "16", "16");
            HandleNegative(inputs, "-16", "Operand State", "", 1, 0);
            HandleSquareRoot(inputs, "4", "Operand State", "", 1, 0);
            HandleLeftParenthesis(inputs, "0", "Parenthesis State", "16 * (", 2, 2);
            HandleRightParenthesis(inputs, "16", "Operand State", "", 1, 0);
            HandleNumber(inputs, "3", "163", "Operand State", "", 1, 0);
            HandleDecimalPoint(inputs, ".", "16.", "Operand State", "", 1, 0);
            HandleAddition(inputs, "16", "Operator State", "16 +", 1, 0);
            HandleSubtraction(inputs, "16", "Operator State", "16 -", 1, 0);
            HandleMultiplication(inputs, "16", "Operator State", "16 *", 1, 0);
            HandleDivision(inputs, "16", "Operator State", "16 /", 1, 0);


            inputs = "9+16";
            HandleBackspace(inputs, "1", "Operand State", "9 +", 2, 1);
            HandleClear(inputs, "0", "Initial State", "", 1, 0);
            HandleClearEntry(inputs, "0", "Operand State", "9 +", 2, 1);
            HandleEqual(inputs, "25", "Equal State", "9 + 16 =", 1, 0, "( 9 + 16 )", "+ 9 16", "9 16 +");
            HandleNegative(inputs, "-16", "Operand State", "9 +", 2, 1);
            HandleSquareRoot(inputs, "4", "Operand State", "9 +", 2, 1);
            HandleLeftParenthesis(inputs, "0", "Parenthesis State", "9 + 16 * (", 3, 3);
            HandleRightParenthesis(inputs, "16", "Operand State", "9 +", 2, 1);
            HandleNumber(inputs, "3", "163", "Operand State", "9 +", 2, 1);
            HandleDecimalPoint(inputs, ".", "16.", "Operand State", "9 +", 2, 1);
            HandleAddition(inputs, "16", "Operator State", "9 + 16 +", 2, 1);
            HandleSubtraction(inputs, "16", "Operator State", "9 + 16 -", 2, 1);
            HandleMultiplication(inputs, "16", "Operator State", "9 + 16 *", 2, 1);
            HandleDivision(inputs, "16", "Operator State", "9 + 16 /", 2, 1);
        }

        [TestMethod]
        public void TestOperatorState()
        {
            string inputs = "9*";
            HandleBackspace(inputs, "9", "Operator State", "9 *", 1, 0);
            HandleClear(inputs, "0", "Initial State", "", 1, 0);
            HandleClearEntry(inputs, "0", "Operand State", "9 *", 2, 1);
            HandleEqual(inputs, "81", "Equal State", "9 * 9 =", 1, 0, "( 9 * 9 )", "* 9 9", "9 9 *");
            HandleNegative(inputs, "-9", "Operand State", "9 *", 2, 1);
            HandleSquareRoot(inputs, "3", "Operand State", "9 *", 2, 1);
            HandleLeftParenthesis(inputs, "0", "Parenthesis State", "9 * (", 2, 2);
            HandleRightParenthesis(inputs, "9", "Operator State", "9 *", 1, 0);
            HandleNumber(inputs, "3", "3", "Operand State", "9 *", 2, 1);
            HandleDecimalPoint(inputs, ".", "0.", "Operand State", "9 *", 2, 1);
            HandleAddition(inputs, "9", "Operator State", "9 +", 1, 0);
            HandleSubtraction(inputs, "9", "Operator State", "9 -", 1, 0);
            HandleMultiplication(inputs, "9", "Operator State", "9 *", 1, 0);
            HandleDivision(inputs, "9", "Operator State", "9 /", 1, 0);

            inputs = "3+9/";
            HandleBackspace(inputs, "9", "Operator State", "3 + 9 /", 2, 1);
            HandleClear(inputs, "0", "Initial State", "", 1, 0);
            HandleClearEntry(inputs, "0", "Operand State", "3 + 9 /", 3, 2);
            HandleEqual(inputs, "4", "Equal State", "3 + 9 / 9 =", 1, 0, "( 3 + ( 9 / 9 ) )", "+ 3 / 9 9", "3 9 9 / +");
            HandleNegative(inputs, "-9", "Operand State", "3 + 9 /", 3, 2);
            HandleSquareRoot(inputs, "3", "Operand State", "3 + 9 /", 3, 2);
            HandleLeftParenthesis(inputs, "0", "Parenthesis State", "3 + 9 / (", 3, 3);
            HandleRightParenthesis(inputs, "9", "Operator State", "3 + 9 /", 2, 1);
            HandleNumber(inputs, "3", "3", "Operand State", "3 + 9 /", 3, 2);
            HandleDecimalPoint(inputs, ".", "0.", "Operand State", "3 + 9 /", 3, 2);
            HandleAddition(inputs, "9", "Operator State", "3 + 9 +", 2, 1);
            HandleSubtraction(inputs, "9", "Operator State", "3 + 9 -", 2, 1);
            HandleMultiplication(inputs, "9", "Operator State", "3 + 9 *", 2, 1);
            HandleDivision(inputs, "9", "Operator State", "3 + 9 /", 2, 1);
        }

        [TestMethod]
        public void TestParenthesisInitialState()
        {
            string inputs = "3+(";
            HandleBackspace(inputs, "0", "Parenthesis Operand State", "3 + (", 2, 2);
            HandleClear(inputs, "0", "Initial State", "", 1, 0);
            HandleClearEntry(inputs, "0", "Parenthesis Operand State", "3 + (", 2, 2);
            HandleEqual(inputs, "3", "Equal State", "3 + ( 0 ) =", 1, 0, "( 3 + 0 )", "+ 3 0", "3 0 +");
            HandleNegative(inputs, "0", "Parenthesis Operand State", "3 + (", 2, 2);
            HandleSquareRoot(inputs, "0", "Parenthesis Operand State", "3 + (", 2, 2);
            HandleLeftParenthesis(inputs, "0", "Parenthesis State", "3 + ( (", 2, 3);
            HandleRightParenthesis(inputs, "0", "Right Parenthesis State", "3 + ( 0 )", 2, 1);
            HandleNumber(inputs, "9", "9", "Parenthesis Operand State", "3 + (", 2, 2);
            HandleDecimalPoint(inputs, ".", "0.", "Parenthesis Operand State", "3 + (", 2, 2);
            HandleAddition(inputs, "0", "Parenthesis Operator State", "3 + ( 0 +", 2, 2);
            HandleSubtraction(inputs, "0", "Parenthesis Operator State", "3 + ( 0 -", 2, 2);
            HandleMultiplication(inputs, "0", "Parenthesis Operator State", "3 + ( 0 *", 2, 2);
            HandleDivision(inputs, "0", "Parenthesis Operator State", "3 + ( 0 /", 2, 2);

        }

        [TestMethod]
        public void TestParenthesisOperandState()
        {
            string inputs = "8/(6-4";
            HandleBackspace(inputs, "0", "Parenthesis Operand State", "8 / ( 6 -", 3, 3);
            HandleClear(inputs, "0", "Initial State", "", 1, 0);
            HandleClearEntry(inputs, "0", "Parenthesis Operand State", "8 / ( 6 -", 3, 3);
            HandleEqual(inputs, "4", "Equal State", "8 / ( 6 - 4 ) =", 1, 0, "( 8 / ( 6 - 4 ) )", "/ 8 - 6 4", "8 6 4 - /");
            HandleNegative(inputs, "-4", "Parenthesis Operand State", "8 / ( 6 -", 3, 3);
            HandleSquareRoot(inputs, "2", "Parenthesis Operand State", "8 / ( 6 -", 3, 3);
            HandleLeftParenthesis(inputs, "0", "Parenthesis State", "8 / ( 6 - 4 * (", 4, 5);
            HandleRightParenthesis(inputs, "2", "Right Parenthesis State", "8 / ( 6 - 4 )", 2, 1);
            HandleNumber(inputs, "3", "43", "Parenthesis Operand State", "8 / ( 6 -", 3, 3);
            HandleDecimalPoint(inputs, ".", "4.", "Parenthesis Operand State", "8 / ( 6 -", 3, 3);
            HandleAddition(inputs, "4", "Parenthesis Operator State", "8 / ( 6 - 4 +", 3, 3);
            HandleSubtraction(inputs, "4", "Parenthesis Operator State", "8 / ( 6 - 4 -", 3, 3);
            HandleMultiplication(inputs, "4", "Parenthesis Operator State", "8 / ( 6 - 4 *", 3, 3);
            HandleDivision(inputs, "4", "Parenthesis Operator State", "8 / ( 6 - 4 /", 3, 3);
        }

        [TestMethod]
        public void TestParenthesisOperatorState()
        {
            string inputs = "3*(9/";
            HandleBackspace(inputs, "9", "Parenthesis Operator State", "3 * ( 9 /", 2, 2);
            HandleClear(inputs, "0", "Initial State", "", 1, 0);
            HandleClearEntry(inputs, "0", "Parenthesis Operand State", "3 * ( 9 /", 3, 3);
            HandleEqual(inputs, "3", "Equal State", "3 * ( 9 / 9 ) =", 1, 0, "( 3 * ( 9 / 9 ) )", "* 3 / 9 9", "3 9 9 / *");
            HandleNegative(inputs, "-9", "Parenthesis Operand State", "3 * ( 9 /", 3, 3);
            HandleSquareRoot(inputs, "3", "Parenthesis Operand State", "3 * ( 9 /", 3, 3);
            HandleLeftParenthesis(inputs, "0", "Parenthesis State", "3 * ( 9 / (", 3, 4);
            HandleRightParenthesis(inputs, "1", "Right Parenthesis State", "3 * ( 9 / 9 )", 2, 1);
            HandleNumber(inputs, "3", "3", "Parenthesis Operand State", "3 * ( 9 /", 3, 3);
            HandleDecimalPoint(inputs, ".", "0.", "Parenthesis Operand State", "3 * ( 9 /", 3, 3);
            HandleAddition(inputs, "9", "Parenthesis Operator State", "3 * ( 9 +", 2, 2);
            HandleSubtraction(inputs, "9", "Parenthesis Operator State", "3 * ( 9 -", 2, 2);
            HandleMultiplication(inputs, "9", "Parenthesis Operator State", "3 * ( 9 *", 2, 2);
            HandleDivision(inputs, "9", "Parenthesis Operator State", "3 * ( 9 /", 2, 2);
        }

        [TestMethod]
        public void TestRightParenthesisState()
        {
            string inputs = "9*(5+2)";
            HandleBackspace(inputs, "0", "Initial State", "", 1, 0);
            HandleClear(inputs, "0", "Initial State", "", 1, 0);
            HandleClearEntry(inputs, "0", "Initial State", "", 1, 0);
            HandleEqual(inputs, "63", "Equal State", "9 * ( 5 + 2 ) =", 1, 0, "( 9 * ( 5 + 2 ) )", "* 9 + 5 2", "9 5 2 + *");
            HandleNegative(inputs, "0", "Initial State", "", 1, 0);
            HandleSquareRoot(inputs, "0", "Initial State", "", 1, 0);
            HandleLeftParenthesis(inputs, "0", "Parenthesis State", "9 * ( 5 + 2 ) * (", 2, 2);
            HandleRightParenthesis(inputs, "7", "Right Parenthesis State", "9 * ( 5 + 2 )", 2, 1);
            HandleNumber(inputs, "3", "3", "Operand State", "", 1, 0);
            HandleDecimalPoint(inputs, ".", "0.", "Operand State", "", 1, 0);
            HandleAddition(inputs, "7", "Parenthesis Operator State", "9 * ( 5 + 2 ) +", 2, 1);
            HandleSubtraction(inputs, "7", "Parenthesis Operator State", "9 * ( 5 + 2 ) -", 2, 1);
            HandleMultiplication(inputs, "7", "Parenthesis Operator State", "9 * ( 5 + 2 ) *", 2, 1);
            HandleDivision(inputs, "7", "Parenthesis Operator State", "9 * ( 5 + 2 ) /", 2, 1);
        }

        [TestMethod]
        public void TestEqualState()
        {
            string inputs = "2=";
            HandleBackspace(inputs, "0", "Initial State", "", 1, 0);
            HandleClear(inputs, "0", "Initial State", "", 1, 0);
            HandleClearEntry(inputs, "0", "Initial State", "", 1, 0);
            HandleEqual(inputs, "2", "Equal State", "2 =", 1, 0, "2", "2", "2");
            HandleNegative(inputs, "0", "Initial State", "", 1, 0);
            HandleSquareRoot(inputs, "0", "Initial State", "", 1, 0);
            HandleLeftParenthesis(inputs, "0", "Initial State", "", 1, 0);
            HandleRightParenthesis(inputs, "0", "Initial State", "", 1, 0);
            HandleNumber(inputs, "3", "3", "Operand State", "", 1, 0);
            HandleDecimalPoint(inputs, ".", "0.", "Operand State", "", 1, 0);
            HandleAddition(inputs, "2", "Operator State", "2 +", 1, 0);
            HandleSubtraction(inputs, "2", "Operator State", "2 -", 1, 0);
            HandleMultiplication(inputs, "2", "Operator State", "2 *", 1, 0);
            HandleDivision(inputs, "2", "Operator State", "2 /", 1, 0);

            inputs = "2/=";
            HandleBackspace(inputs, "0", "Initial State", "", 1, 0);
            HandleClear(inputs, "0", "Initial State", "", 1, 0);
            HandleClearEntry(inputs, "0", "Initial State", "", 1, 0);
            HandleEqual(inputs, "1", "Equal State", "2 / 2 =", 1, 0, "( 2 / 2 )", "/ 2 2", "2 2 /");
            HandleNegative(inputs, "0", "Initial State", "", 1, 0);
            HandleSquareRoot(inputs, "0", "Initial State", "", 1, 0);
            HandleLeftParenthesis(inputs, "0", "Initial State", "", 1, 0);
            HandleRightParenthesis(inputs, "0", "Initial State", "", 1, 0);
            HandleNumber(inputs, "3", "3", "Operand State", "", 1, 0);
            HandleDecimalPoint(inputs, ".", "0.", "Operand State", "", 1, 0);
            HandleAddition(inputs, "1", "Operator State", "1 +", 1, 0);
            HandleSubtraction(inputs, "1", "Operator State", "1 -", 1, 0);
            HandleMultiplication(inputs, "1", "Operator State", "1 *", 1, 0);
            HandleDivision(inputs, "1", "Operator State", "1 /", 1, 0);

            inputs = "2*(=";
            HandleBackspace(inputs, "0", "Initial State", "", 1, 0);
            HandleClear(inputs, "0", "Initial State", "", 1, 0);
            HandleClearEntry(inputs, "0", "Initial State", "", 1, 0);
            HandleEqual(inputs, "0", "Equal State", "2 * ( 0 ) =", 1, 0, "( 2 * 0 )", "* 2 0", "2 0 *");
            HandleNegative(inputs, "0", "Initial State", "", 1, 0);
            HandleSquareRoot(inputs, "0", "Initial State", "", 1, 0);
            HandleLeftParenthesis(inputs, "0", "Initial State", "", 1, 0);
            HandleRightParenthesis(inputs, "0", "Initial State", "", 1, 0);
            HandleNumber(inputs, "3", "3", "Operand State", "", 1, 0);
            HandleDecimalPoint(inputs, ".", "0.", "Operand State", "", 1, 0);
            HandleAddition(inputs, "0", "Operator State", "0 +", 1, 0);
            HandleSubtraction(inputs, "0", "Operator State", "0 -", 1, 0);
            HandleMultiplication(inputs, "0", "Operator State", "0 *", 1, 0);
            HandleDivision(inputs, "0", "Operator State", "0 /", 1, 0);
        }

        [TestMethod]
        public void Test1()
        {
            string inputs = "9+(5+3)/2=";
            HandleEqual(inputs, "13", "Equal State", "9 + ( 5 + 3 ) / 2 =", 1, 0, "( 9 + ( ( 5 + 3 ) / 2 ) )", "+ 9 / + 5 3 2", "9 5 3 + 2 / +");

            inputs = "9+5-6*4/8+5*6-1/2+6=";
            HandleEqual(inputs, "46.5", "Equal State", "9 + 5 - 6 * 4 / 8 + 5 * 6 - 1 / 2 + 6 =", 1, 0, "( ( ( ( ( 9 + 5 ) - ( ( 6 * 4 ) / 8 ) ) + ( 5 * 6 ) ) - ( 1 / 2 ) ) + 6 )", "+ - + - + 9 5 / * 6 4 8 * 5 6 / 1 2 6", "9 5 + 6 4 * 8 / - 5 6 * + 1 2 / - 6 +");
        }


        public void GroupTest(
            CalculatorContext cal,
            string result,
            string stateName,
            string formula,
            int valuesCount,
            int operatorCount
        )
        {
            Assert.AreEqual(cal.Tree.GetResult(), result);
            Assert.AreEqual(cal.StateName, stateName);
            Assert.AreEqual(cal.Tree.GetInputFormula(), formula);
            Assert.AreEqual(cal.Tree.Values.Count, valuesCount);
            Assert.AreEqual(cal.Tree.Operators.Count, operatorCount);
        }

        public CalculatorContext CreateCalculatorContext(string inputs)
        {
            CalculatorContext cal = new CalculatorContext();
            InputSteps(cal, inputs);
            return cal;
        }

        public void HandleBackspace(
            string inputs,
            string result,
            string stateName,
            string formula,
            int valuesCount,
            int operatorCount)
        {
            CalculatorContext cal = CreateCalculatorContext(inputs);
            cal.HandleBackspace();
            GroupTest(
                cal,
                result,
                stateName,
                formula,
                valuesCount,
                operatorCount
                );
        }


        public void HandleClear(
            string inputs,
            string result,
            string stateName,
            string formula,
            int valuesCount,
            int operatorCount)
        {
            CalculatorContext cal = CreateCalculatorContext(inputs);
            cal.HandleClear();
            GroupTest(
               cal,
               result,
               stateName,
               formula,
               valuesCount,
               operatorCount
               );
        }

        public void HandleClearEntry(
            string inputs,
            string result,
            string stateName,
            string formula,
            int valuesCount,
            int operatorCount)
        {
            CalculatorContext cal = CreateCalculatorContext(inputs);
            cal.HandleClearEntry();
            GroupTest(
               cal,
               result,
               stateName,
               formula,
               valuesCount,
               operatorCount
               );
        }

        public void HandleEqual(
            string inputs,
            string result,
            string stateName,
            string formula,
            int valuesCount,
            int operatorCount,
            string infix,
            string prefix,
            string postfix)
        {
            CalculatorContext cal = CreateCalculatorContext(inputs);
            cal.HandleEqual();
            GroupTest(
               cal,
               result,
               stateName,
               formula,
               valuesCount,
               operatorCount
               );

            Assert.AreEqual(cal.Tree.GetInfix(), infix);
            Assert.AreEqual(cal.Tree.GetPrefix(), prefix);
            Assert.AreEqual(cal.Tree.GetPostfix(), postfix);
        }

        public void HandleLeftParenthesis(
            string inputs,
            string result,
            string stateName,
            string formula,
            int valuesCount,
            int operatorCount)
        {
            CalculatorContext cal = CreateCalculatorContext(inputs);
            cal.HandleLeftParenthesis();
            GroupTest(
               cal,
               result,
               stateName,
               formula,
               valuesCount,
               operatorCount
               );
        }

        public void HandleNegative(
            string inputs,
            string result,
            string stateName,
            string formula,
            int valuesCount,
            int operatorCount)
        {
            CalculatorContext cal = CreateCalculatorContext(inputs);
            cal.HandleNegate();
            GroupTest(
               cal,
               result,
               stateName,
               formula,
               valuesCount,
               operatorCount
               );
        }

        public void HandleDecimalPoint(
            string inputs,
            string operand,
            string result,
            string stateName,
            string formula,
            int valuesCount,
            int operatorCount)
        {
            CalculatorContext cal = CreateCalculatorContext(inputs);
            cal.HandleDecimalPoint();
            GroupTest(
               cal,
               result,
               stateName,
               formula,
               valuesCount,
               operatorCount
               );
        }

        public void HandleNumber(
            string inputs,
            string operand,
            string result,
            string stateName,
            string formula,
            int valuesCount,
            int operatorCount)
        {
            CalculatorContext cal = CreateCalculatorContext(inputs);
            cal.HandleNumber(operand);
            GroupTest(
               cal,
               result,
               stateName,
               formula,
               valuesCount,
               operatorCount
               );
        }

        public void HandleAddition(
            string inputs,
            string result,
            string stateName,
            string formula,
            int valuesCount,
            int operatorCount)
        {
            CalculatorContext cal = CreateCalculatorContext(inputs);
            cal.HandleAddition();
            GroupTest(
               cal,
               result,
               stateName,
               formula,
               valuesCount,
               operatorCount
               );
        }

        public void HandleSubtraction(
            string inputs,
            string result,
            string stateName,
            string formula,
            int valuesCount,
            int operatorCount)
        {
            CalculatorContext cal = CreateCalculatorContext(inputs);
            cal.HandleSubtraction();
            GroupTest(
               cal,
               result,
               stateName,
               formula,
               valuesCount,
               operatorCount
               );
        }

        public void HandleMultiplication(
            string inputs,
            string result,
            string stateName,
            string formula,
            int valuesCount,
            int operatorCount)
        {
            CalculatorContext cal = CreateCalculatorContext(inputs);
            cal.HandleMultiplication();
            GroupTest(
               cal,
               result,
               stateName,
               formula,
               valuesCount,
               operatorCount
               );
        }

        public void HandleDivision(
            string inputs,
            string result,
            string stateName,
            string formula,
            int valuesCount,
            int operatorCount)
        {
            CalculatorContext cal = CreateCalculatorContext(inputs);
            cal.HandleDivision();
            GroupTest(
               cal,
               result,
               stateName,
               formula,
               valuesCount,
               operatorCount
               );
        }

        public void HandleRightParenthesis(
            string inputs,
            string result,
            string stateName,
            string formula,
            int valuesCount,
            int operatorCount)
        {
            CalculatorContext cal = CreateCalculatorContext(inputs);
            cal.HandleRightParenthesis();
            GroupTest(
               cal,
               result,
               stateName,
               formula,
               valuesCount,
               operatorCount
               );
        }

        public void HandleSquareRoot(
            string inputs,
            string result,
            string stateName,
            string formula,
            int valuesCount,
            int operatorCount)
        {
            CalculatorContext cal = CreateCalculatorContext(inputs);
            cal.HandleSquareRoot();
            GroupTest(
               cal,
               result,
               stateName,
               formula,
               valuesCount,
               operatorCount
               );
        }

        public void InputSteps(CalculatorContext cal, string inputs)
        {
            foreach (char c in inputs.ToCharArray())
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
                        cal.HandleNumber(s);
                        break;
                    case ".":
                        cal.HandleDecimalPoint();
                        break;
                    case "+":
                        cal.HandleAddition();
                        break;
                    case "-":
                        cal.HandleSubtraction();
                        break;
                    case "*":
                        cal.HandleMultiplication();
                        break;
                    case "/":
                        cal.HandleDivision();
                        break;
                    case "=":
                        cal.HandleEqual();
                        break;
                    case "negate":
                        cal.HandleNegate();
                        break;
                    case "sqrt":
                        cal.HandleSquareRoot();
                        break;
                    case "(":
                        cal.HandleLeftParenthesis();
                        break;
                    case ")":
                        cal.HandleRightParenthesis();
                        break;
                    default:
                        Console.WriteLine("error " + s);
                        break;
                }
            }
        }
    }
}
