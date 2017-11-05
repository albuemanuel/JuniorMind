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
            int index = 0;
            Assert.AreEqual("23.65", ReadNo("23.65 234 *", ref index));
            Assert.AreEqual(4, index);
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
            int index = 0;
            Assert.AreEqual(19, EvalExpr("+ 10 9", ref index));
            
        }

        bool IsOperator(char op)
        {
            string operators = "+-*/";

            if (operators.IndexOf(op) != -1)
                return true;

            return false;
        }

        string ReadNo(string expr, int index)
        {
            string no = "";
            for (int i = index; expr[i]!= ' '; i++)
            {
                no += expr[i];
                index = i;
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

        double EvalExpr(string expr, ref int index)
        {
            if (index == expr.Length - 1)
                return 0;

            if (index != 0)
                if (char.IsDigit(expr[index - 1]) || expr[index] == ' ')
                {
                    index++;
                    return EvalExpr(expr, ref index);
                }

            if (char.IsDigit(expr[index]))
            {
                return Convert.ToDouble(ReadNo(expr, ref index));
            }

            
            return Operate(EvalExpr(expr, 2), EvalExpr(expr, 4), expr[index]);

        }

    }
}
