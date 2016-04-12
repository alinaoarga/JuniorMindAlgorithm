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
        [TestMethod]
        public void And()
        {
            Assert.AreEqual(1, And(1, 1));
        }
        [TestMethod]
        public void Or()
        {
            Assert.AreEqual(0, Or(0, 0));
        }

        [TestMethod]
        public void OrOperandTest()
        {
            CollectionAssert.AreEqual(ConvertDecimalToBinary(2 | 3), OrOperand(ConvertDecimalToBinary(2), ConvertDecimalToBinary(3)));
        }
        [TestMethod]
        public void OperandTest()
        {
            CollectionAssert.AreEqual(ConvertDecimalToBinary(2 & 3), AndOperand(ConvertDecimalToBinary(2), ConvertDecimalToBinary(3)));
        }
        [TestMethod]
        public void OperanddTest()
        {
            CollectionAssert.AreEqual(ConvertDecimalToBinary(2 & 5), AndOperand(ConvertDecimalToBinary(2), ConvertDecimalToBinary(5)));
        }
        [TestMethod]
        public void OperandTenFiveTest()
        {
            CollectionAssert.AreEqual(ConvertDecimalToBinary(10 & 5), AndOperand(ConvertDecimalToBinary(10), ConvertDecimalToBinary(5)));
        }
        [TestMethod]
        public void GetAtTest()
        {
            Assert.AreEqual(1, GetAt(new byte[] { 1, 0, 1, 0, 1, 1 }, 3));
        }
        [TestMethod]
        public void GetAttTest()
        {
            Assert.AreEqual(0, GetAt(new byte[] { 1, 2, 3 }, 5));
        }
        [TestMethod]
        public void GetAtttTest()
        {
            Assert.AreEqual(0, GetAt(new byte[] { 1, 2, 3, 4 }, 5));
        }
        [TestMethod]
        public void CountTest()
        {
            Assert.AreEqual(3, Count(new byte[] { 1, 0, 0, 1, 0, 0, 0 }));
        }
        int Count(byte[] number)
        {
            int count = 0;
            for (int position = number.Length - 1; position >= 0; position--)
            {
                if (number[position] == 0)
                    count++;
                else
                    break;
            }
            return count ;
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
        byte GetAt(byte[] number, int position)
        {
            if (position >= number.Length)
                return (byte)0;
            return number[number.Length - 1 - position];
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
        byte And(byte number1, byte number2)
        {
            byte number = (number1 == 1 && number2 == 1) ? (byte)1 : (byte)0;
            return number;
        }
        byte[] AndOperand(byte[] first, byte[] second)
        {
            int maxLength = Math.Max(first.Length, second.Length);
            byte[] result = new byte[maxLength];
            for (int i = 0; i < maxLength; i++)
            {
                result[i] = And(GetAt(first, i), GetAt(second, i));
            }
            Array.Resize(ref result, result.Length - Count(result));
            Array.Reverse(result);
            return result;
        }
        byte Or(byte number1, byte number2)
        {
            byte number = (number1 == 0 && number2 == 0) ? (byte)0 : (byte)1;
            return number;
        }
        byte[] OrOperand(byte[] first, byte[] second)
        {
            byte[] result = new byte[first.Length];
            for (int i = 0; i < first.Length; i++)
            {
                result[i] = Or(first[i], second[i]);
            }
            return result;
        }
    }
}
