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
            CollectionAssert.AreEqual(new byte[] { 1, 0, 1, 1, 0 }, ConvertDecimalToBinary(22));
        }
        [TestMethod]
        public void ConvertNumber13()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 1, 0, 1 }, ConvertDecimalToBinary(13));
        }
        [TestMethod]
        public void ConvertNumber11()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 0, 1, 1 }, ConvertDecimalToBinary(11));
        }
        [TestMethod]
        public void Not11()
        {
            CollectionAssert.AreEqual(new byte[] { 0, 1, 0, 0 }, NotOperand(new byte[] { 1, 0, 1, 1 }));
        }
        [TestMethod]
        public void Not()
        {
            Assert.AreEqual(1, Not(0));
        }
        byte[] ConvertDecimalToBinary(int number)
        {
            byte[] results = new byte[0];
            while (number > 0)
            {
                int remainder = (number % 2);
                number /= 2;
                Array.Resize(ref results, results.Length + 1);
                results[results.Length - 1] = Convert.ToByte(remainder);
            }
            Array.Reverse(results);
            return results;
        }
        byte Not(byte number)
        {
            number = number == 0 ? (byte)1 : (byte)0;
            return number;
        }
        byte[] NotOperand(byte[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = Not(numbers[i]);
                
            }
            return numbers;
        }
    }
}
