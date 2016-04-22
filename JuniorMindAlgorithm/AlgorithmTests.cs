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
        public void OrOperandTest()
        {
            CollectionAssert.AreEqual(ConvertDecimalToBinary(2 | 3), General(ConvertDecimalToBinary(2), ConvertDecimalToBinary(3), "or"));
        }
        [TestMethod]
        public void OrOperanddTest()
        {
            CollectionAssert.AreEqual(ConvertDecimalToBinary(2 | 5), General(ConvertDecimalToBinary(2), ConvertDecimalToBinary(5), "or"));
        }
        [TestMethod]
        public void OperandTest()
        {
            CollectionAssert.AreEqual(ConvertDecimalToBinary(2 & 3), General(ConvertDecimalToBinary(2), ConvertDecimalToBinary(3), "and"));
        }
        [TestMethod]
        public void OperanddTest()
        {
            CollectionAssert.AreEqual(ConvertDecimalToBinary(2 & 5), General(ConvertDecimalToBinary(2), ConvertDecimalToBinary(5), "and"));
        }
        [TestMethod]
        public void OperandTenFiveTest()
        {
            CollectionAssert.AreEqual(ConvertDecimalToBinary(10 & 5), General(ConvertDecimalToBinary(10), ConvertDecimalToBinary(5), "and"));
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
        [TestMethod]
        public void XorOperandTest()
        {
            CollectionAssert.AreEqual(ConvertDecimalToBinary(2 ^ 3), General(ConvertDecimalToBinary(2), ConvertDecimalToBinary(3), "xor"));
        }
        [TestMethod]
        public void XorOperanddTest()
        {
            CollectionAssert.AreEqual(ConvertDecimalToBinary(2 ^ 5), General(ConvertDecimalToBinary(2), ConvertDecimalToBinary(5), "xor"));
        }
        [TestMethod]
        public void RightHandShiftTest()
        {
            CollectionAssert.AreEqual(ConvertDecimalToBinary(9 >> 2), RightHandShift(ConvertDecimalToBinary(9), 2));
        }
        [TestMethod]
        public void LeftHandShiftTest()
        {
            CollectionAssert.AreEqual(ConvertDecimalToBinary(9 << 2), LeftHandShift(ConvertDecimalToBinary(9), 2));
        }
        [TestMethod]
        public void LessTest()
        {
            Assert.AreEqual(true, LessThan(new byte[] { 1, 0 }, new byte[] { 1, 0, 0, 1 }));
        }
        [TestMethod]
        public void LessThanTest()
        {
            Assert.AreEqual(true, LessThan(ConvertDecimalToBinary(2), ConvertDecimalToBinary(9)));
        }
        [TestMethod]
        public void GraterThanTest()
        {
            Assert.AreEqual(false, GraterThan(ConvertDecimalToBinary(2), ConvertDecimalToBinary(9)));
        }
        [TestMethod]
        public void EqualTest()
        {
            Assert.AreEqual(true, Equal(ConvertDecimalToBinary(9), ConvertDecimalToBinary(9)));
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
            return count;
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
        byte AndOrXor(string option, byte number1, byte number2)
        {
            byte number = 0;
            if (option == "and")
            {
                number = (number1 == 1 && number2 == 1) ? (byte)1 : (byte)0;
            }
            else if (option == "or")
            {
                number = (number1 == 0 && number2 == 0) ? (byte)0 : (byte)1;
            }
            else if (option == "xor")
            {
                number = ((number1 == 1 && number2 == 0) || (number1 == 0 && number2 == 1)) ? (byte)1 : (byte)0;
            }
            return number;
        }
        byte[] General(byte[] first, byte[] second, string option)
        {
            int maxLength = Math.Max(first.Length, second.Length);
            byte[] result = new byte[maxLength];
            for (int i = 0; i < maxLength; i++)
            {
                result[i] = AndOrXor(option, GetAt(first, i), GetAt(second, i));
            }
            Array.Resize(ref result, result.Length - Count(result));
            Array.Reverse(result);
            return result;
        }
        byte[] RightHandShift(byte[] number, int position)
        {
            byte[] result = new byte[number.Length - position];
            int i = 0;
            while (i < number.Length - position)
            {
                result[i] = number[i];
                i++;
            }
            return result;
        }
        byte[] LeftHandShift(byte[] number, int position)
        {
            byte[] result = new byte[number.Length + position];
            for (int i = 0; i < number.Length; i++)
            {
                result[i] = number[i];
            }
            return result;
        }
        bool LessThan(byte[] number1, byte[] number2)
        {
            int maxLength = Math.Max(number1.Length, number2.Length);
            Array.Reverse(number1);
            Array.Reverse(number2);
            for (int i = 0; i < maxLength; i++)
            {
                if (GetAt(number1, i) < GetAt(number2, i))
                return true;
            }
            return false;
        }
        bool GraterThan(byte[] number1, byte[] number2)
        {
            return (LessThan(number1, number2) == true) ? false : true;
        }
        bool Equal(byte[] number1, byte[] number2)
        {
            return ((LessThan(number1, number2) == true) && (LessThan(number1, number2) == true)) ? false : true;
        }
    }
}

