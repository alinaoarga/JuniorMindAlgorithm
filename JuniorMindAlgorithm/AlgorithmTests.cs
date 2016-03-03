using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JuniorMindAlgorithm
{
    [TestClass]
    public class AlgorithmTests
    {
        [TestMethod]
        public void ConvertNumber22()
        {
            Assert.AreEqual("10110", ConvertDecimalToBinary(22));
        }
        [TestMethod]
        public void ConvertNumber13()
        {
            Assert.AreEqual("1101", ConvertDecimalToBinary(13));
        }
        string ConvertDecimalToBinary(int number)
        {
            string result = string.Empty;
            while (number > 0)
            {
                int remainder = number % 2;
                number /= 2;
                result = remainder.ToString() + result;
            }
            return result;
        }
    }
}
