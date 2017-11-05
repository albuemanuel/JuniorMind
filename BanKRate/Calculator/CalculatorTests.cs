using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void Operator()
        {
            Assert.IsTrue(IsOperator('+'));
            Assert.IsFalse(IsOperator('b'));
        }

        [TestMethod]
        public void NumberReading()
        {
            Assert.AreEqual("23.6", ReadNo("23.6 234 *"));
        }

        [TestMethod]
        public void Operation()
        {
            string op = "/-*+";
            Assert.AreEqual(19, Operate(10, 9, ref op));
            Assert.AreEqual(40, Operate(20, 2, ref op));
        }

        bool IsOperator(char op)
        {
            string operators = "+-*/";

            if (operators.IndexOf(op) != -1)
                return true;

            return false;
        }

        string ReadNo(string expr)
        {
            string no = "";
            for (int i = 0; i < expr.Length; i++)
            {
                if (expr[i] == ' ')
                    break;
                no += expr[i];
            }

            return no;
        }

        double Operate(double termOne, double termTwo, ref string operators)
        {
            char op = operators[operators.Length - 1];
            operators = operators.Substring(0, operators.Length - 1);

            switch (op)
            {
                case '+':
                    return termOne + termTwo;
                case '-':
                    return termOne - termTwo;
                case '*':
                    return termOne * termTwo;
                case '/':
                    return termOne / termTwo;
            }
            

            return 0;
        }

        double EvalExpr(string expr, string operators = "", double result = 0)
        {
            if (IsOperator(expr[0]))
            {
                operators += expr[0];
                return EvalExpr(expr.Substring(2), operators);
            }

            if (char.IsDigit(expr[0]))
            {
                string term = ReadNo(expr);

                if (result == 0)
                    result = Convert.ToDouble(term);
                else
                    result = Operate(result, Convert.ToDouble(term), ref operators);

                return EvalExpr(expr.Substring(term.Length), operators, result);
            }

        }

    }
}
