using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Logic
{
    /// <summary>
    /// Extension for double
    /// </summary>
    public static class DoubleExtension
    {
        private const int numOfBits = 64;

        /// <summary>
        /// Represent the string with binary representation of double number
        /// </summary>
        /// <param name="number">Number</param>
        /// <returns>String with binary representation</returns>
        public static string ToBinaryString(this double number)
        {
            Union num = new Union();
            num.DoubleValue = number;
            long lNum = num.LongValue;
            string result = "";
            for (int i = 0; i < numOfBits; i++)
            {
                result += lNum & 1;
                lNum >>= 1;
            }
            char[] resChar = result.ToArray();
            Array.Reverse(resChar);
            return new string(resChar);
        }

        [StructLayout(LayoutKind.Explicit)]
        private class Union
        {
            [FieldOffset(0)]
            private double doubleValue;

            [FieldOffset(0)]
            private long longValue;

            public double DoubleValue
            {
                get => doubleValue;
                set => doubleValue = value;
            }

            public long LongValue
            {
                get => longValue;
                set => longValue = value;
            }
        }
    }
}
