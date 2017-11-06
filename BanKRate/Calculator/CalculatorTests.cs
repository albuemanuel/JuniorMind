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
            Assert.AreEqual(23.65, ReadNo("23.65 234 *"));
        }

        [TestMethod]
        public void Operation()
        {
            Assert.AreEqual(19, Operate(10, 9, '+'));
            Assert.AreEqual(40, Operate(20, 2, '*'));
        }

        [TestMethod]
        public void ExpressionEvaluationForTwoTerms()
        {
            Assert.AreEqual(19, EvalExpr("+ 10 9"));
        }

        [TestMethod]
        public void ExpressionEvaluationForThreeTerms()
        {
            Assert.AreEqual(70, EvalExpr("* + 34 1 2"));
        }

        bool IsOperator(char op)
        {
            string operators = "+-*/";

            if (operators.IndexOf(op) != -1)
                return true;

            return false;
        }

        double ReadNo(string expr, int index = 0)
        {
            string no = "";
            for (int i = index; i<expr.Length; i++)
            {
                if (expr[i] == ' ')
                    break;
                no += expr[i];
            }
            return Convert.ToDouble(no);
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

        int GetIndexOf(string expr, int order, int index = 0)
        {
            for(int i=index; i<expr.Length; i++)
            {
                if (order == 0)
                    return i;

                if (expr[i] == ' ')
                    order--;
            }
            return 0;
        }

        double EvalExpr(string expr, int index = 0)
        {
            if (char.IsDigit(expr[index]))
                return ReadNo(expr, index);

            
            return Operate(EvalExpr(expr, GetIndexOf(expr, 1, index)), EvalExpr(expr, GetIndexOf(expr, 2, index)), expr[index]);
        }

    }
}
