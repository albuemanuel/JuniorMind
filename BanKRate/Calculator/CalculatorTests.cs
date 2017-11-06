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
            Assert.AreEqual("23.65", ReadNo("23.65 234 *"));
        }

        [TestMethod]
        public void Operation()
        {
            Assert.AreEqual(19, Operate(10, 9, '+'));
            Assert.AreEqual(40, Operate(20, 2, '*'));
        }

        [TestMethod]
        public void ExpressionEvaluation()
        {
            Assert.AreEqual(19, EvalExpr("+ 10 9"));
            
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
            for (int i = 0; i<expr.Length; i++)
            {
                if (expr[i] == ' ')
                    break;
                no += expr[i];
            }
            return no;
        }

        double Operate(double termOne, double termTwo, char op)
        {
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



        double EvalExpr(string expr, out int index)
        {
            
            if (char.IsDigit(expr[0]))
            {
                index = expr.IndexOf(' ');
                return Convert.ToDouble(expr.Substring(0, index));
            }

            index = 0;
            return Operate(EvalExpr(expr.Substring(1), out index), EvalExpr(expr.Substring(2), out index), expr[0]);

        }

    }
}
