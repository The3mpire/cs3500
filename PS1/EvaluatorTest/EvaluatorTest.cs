using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FormulaEvaluator;

namespace EvaluatorTest
{
    [TestClass]
    public class EvaluatorTest

    {
        /// <summary>
        /// A dictionary function that holds the values of variables
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int Dictionary(string s)
        {
            return -2;
        }

        int ans;

        [TestMethod]
        public void TestDivisionBasic()
        {
            ans = Evaluator.Evaluate("8 / 2", Dictionary);
            Assert.AreEqual(4, ans);
        }

        [TestMethod]
        public void TestMultiplicationBasic()
        {
            ans = Evaluator.Evaluate("2*\t0", Dictionary);
            Assert.AreEqual(0, ans);
        }
    }
}
