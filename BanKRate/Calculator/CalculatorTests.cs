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
            Assert.AreEqual(23.65, ReadNo("23.65 234 *", ref index));
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
            int index = 0;
            Assert.AreEqual(19, EvalExpr("+ 10 9", ref index));
        }

        [TestMethod]
        public void ExpressionEvaluationForThreeTerms()
        {
            int index = 0;
            Assert.AreEqual(70, EvalExpr("* + 34 1 2", ref index));
        }

        [TestMethod]
        public void ExpressionEvaluationForCompoundTerms()
        {
            int index = 0;
            Assert.AreEqual(63, EvalExpr("- * + 34 1 2 + 5 2", ref index));
        }

        bool IsOperator(char op)
        {
            string operators = "+-*/";

            if (operators.IndexOf(op) != -1)
                return true;

            return false;
        }

        double ReadNo(string expr, ref int index)
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

        double EvalExpr(string expr, ref int index)
        {
            if (char.IsDigit(expr[index]))
                return ReadNo(expr, ref index);

            char op = expr[index];

            index = GetIndexOf(expr, 1, index);
            double term1 = EvalExpr(expr, ref index);
            index = GetIndexOf(expr, 1, index);
            double term2 = EvalExpr(expr, ref index);

            return Operate(term1, term2, op);

        }

    }
}
