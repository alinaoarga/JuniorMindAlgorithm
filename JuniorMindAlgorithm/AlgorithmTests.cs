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
            Assert.AreEqual(10110, ConvertDecimalToBinary(22));
        }
        [TestMethod]
        public void ConvertNumber13()
        {
            Assert.AreEqual(1101, ConvertDecimalToBinary(13));
        }
        byte ConvertDecimalToBinary(int number)
        {
            byte [] results = new byte[] { 0, 1};
            byte i = 0;
            while (number > 0 )
            {
                   int remainder =(number % 2);
                    number /= 2;
                   results[i] += Convert.ToByte(remainder) ;
            }
            return results[i];
        }
    }
}
