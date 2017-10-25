using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// GCD class provides metods for calculating GCD
    /// </summary>
    public class GCD
    {
        #region EuclideanGCD method
        /// <summary>
        /// Calculates GCD using Euclidean algorithm
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <param name="time">Time spent on calculating</param>
        /// <exception cref="ArgumentException"></exception>
        /// <returns>GCD of a and b</returns>
        public static int EuclideanGCD(out long time, int a, int b)
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            time = 0;
            if (a == 0 && b == 0)
                throw new ArgumentException("GCD(0,0) can't be calculated");
            if (a == 0)
                return b;
            if (b == 0)
                return a;
            if (a == b)
                return a;

            FindMaxAndMin(ref a, ref b);

            int r = a % b;
            while (r != 0)
            {
                a = b;
                b = r;
                r = a % b;
            }
            s.Stop();
            time = s.ElapsedMilliseconds;
            return b;
        }
        #endregion

        #region Overloadiongs for EuclideanGCD
        public static int EuclideanGCD(int a, int b)
        {
            return EuclideanGCD(out _, a, b);
        }

        public static int EuclideanGCD(out long time, int a, int b, int c)
        {
            int gcd = EuclideanGCD(a, b);
            return EuclideanGCD(out time, gcd, c);
        }

        public static int EuclideanGCD(int a, int b, int c)
        {
            int gcd = EuclideanGCD(a, b);
            return EuclideanGCD(gcd, c);
        }

        public static int EuclideanGCD(out long time, params int[] numbers)
        {
            time = 0;
            if (numbers.Length < 2)
                throw new ArgumentException("Must be 2 or more numbers");

            int gcd = EuclideanGCD(numbers[0], numbers[1]);
            for (int i = 2; i < numbers.Length; i++)
            {
                gcd = EuclideanGCD(out time, gcd, numbers[i]);
            }
            return gcd;
        }

        public static int EuclideanGCD(params int[] numbers)
        {
            return EuclideanGCD(out _, numbers);
        }
        #endregion

        #region BinaryEuclideanGCD method
        /// <summary>
        /// Calculates GCD using binary Eucidean algorithm 
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <param name="time">Time spent on calculating</param>
        /// <exception cref="ArgumentException"></exception>
        /// <returns>GCD(a, b)</returns>
        public static int BinaryEuclideanGCD(out long time, int a, int b)
        {
            time = 0;
            Stopwatch s = new Stopwatch();
            s.Start();
            if (a == 0 && b == 0)
                throw new ArgumentException();
            if (a == 0)
                return b;
            if (b == 0)
                return a;
            if (a == b)
                return a;

            FindMaxAndMin(ref a, ref b);

            int k;
            for (k = 0; ((a | b) & 1) == 0; k++)
            {
                a >>= 1;
                b >>= 1;
            }

            while ((a & 1) == 0)
                a >>= 1;
            while ((b & 1) == 0)
                b >>= 1;

            while (a > 0)
            {
                int t = Math.Abs(a - b) / 2;
                if (a < b)
                    b = t;
                else
                    a = t;
            }
            s.Stop();
            time = s.ElapsedMilliseconds;
            return b << k;
        }
        #endregion

        #region Overloading for BinaryEuclideanGCD
        public static int BinaryEuclideanGCD (int a, int b)
        {
            return BinaryEuclideanGCD(out _, a, b);
        }


        public static int BinaryEuclideanGCD(out long time, int a, int b, int c)
        {
            int gcd = BinaryEuclideanGCD(a, b);
            return BinaryEuclideanGCD(out time, gcd, c);
        }

        public static int BinaryEuclideanGCD(int a, int b, int c)
        {
            int gcd = BinaryEuclideanGCD(a, b);
            return BinaryEuclideanGCD(gcd, c);
        }

        public static int BinaryEuclideanGCD(out long time, params int[] numbers)
        {
            time = 0;
            if (numbers.Length < 2)
                throw new ArgumentException("Must be 2 or more numbers");

            int gcd = EuclideanGCD(numbers[0], numbers[1]);
            for (int i = 2; i < numbers.Length; i++)
            {
                gcd = EuclideanGCD(out time, gcd, numbers[i]);
            }
            return gcd;
        }

        public static int BinaryEuclideanGCD(params int[] numbers)
        {
            return BinaryEuclideanGCD(out _, numbers);
        }
        #endregion

        #region Help methods
        private static void FindMaxAndMin(ref int a, ref int b)
        {
            int a1 = Math.Abs(a);
            int b1 = Math.Abs(b);
            a = Math.Max(a1, b1);
            b = Math.Min(a1, b1);
        }
        #endregion
    }
}
