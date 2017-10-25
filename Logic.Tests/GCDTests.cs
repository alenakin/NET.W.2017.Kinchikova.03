using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Logic.Tests
{
    [TestFixture]
    public class GCDTests
    {
        static object[] GCDCases =
        {
            new object[] { 1, 10, 1 },
            new object[] { 5, 10, 5 },
            new object[] { 0, 20, 20 },
            new object[] { 20, 0, 20 },
            new object[] { -5, 10, 5 }
        };

        #region EuclideanGCD method's tests
        [TestCaseSource("GCDCases")]
        public void EuclideanGCD_Params_EqualToExpectedResult(int a, int b, int r)
        {
            Assert.AreEqual(r, GCD.EuclideanGCD(a, b));
        }

        [Test]
        public void EuclideanGCD_TwoZerosInParams_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => GCD.EuclideanGCD(0, 0));
        }

        [TestCase(18, 9, 3, ExpectedResult = 3)]
        [TestCase(-18, 9, 3, ExpectedResult = 3)]
        [TestCase(108, 81, 9, 1, ExpectedResult = 1)]
        public int EuclideanGCD_MoreThanTwoArguments_EqualToResult(params int[] numbers)
        {
            return GCD.EuclideanGCD(numbers);
        }

        [Test]
        public void EuclideanGCD_NumOfParamsLessThan2_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => GCD.EuclideanGCD(1));
        }
        #endregion

        #region BinaryEuclideanGCD method's tests
        [TestCaseSource("GCDCases")]
        public void BinaryEuclideanGCD_Params_EqualToExpectedResult(int a, int b, int r)
        {
            Assert.AreEqual(r, GCD.BinaryEuclideanGCD(a, b));
        }

        [Test]
        public void BinaryEuclideanGCD_TwoZerosInParams_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => GCD.BinaryEuclideanGCD(0, 0));
        }

        [TestCase(18, 9, 3, ExpectedResult = 3)]
        [TestCase(-18, 9, 3, ExpectedResult = 3)]
        [TestCase(108, 81, 9, 1, ExpectedResult = 1)]
        public int BinaryEuclideanGCD_MoreThanTwoArguments_EqualToResult(params int[] numbers)
        {
            return GCD.BinaryEuclideanGCD(numbers);
        }

        [Test]
        public void BinaryEuclideanGCD_NumOfParamsLessThan2_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => GCD.BinaryEuclideanGCD(1));
        }
        #endregion
    }
}
