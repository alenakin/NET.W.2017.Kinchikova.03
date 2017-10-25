using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Extension for double
    /// </summary>
    public static class DoubleExtension
    {
        private const int mantissa = 64;
        private const int exp = 11;

        /// <summary>
        /// Represent the string with binary representation of double number
        /// </summary>
        /// <param name="number"></param>
        /// <returns>String with binary representation</returns>
        public static string ToBinaryString(this double number)
        {
            var bits = new BitArray(BitConverter.GetBytes(number));
            char[] resChar = new char[bits.Length];
            for (int i = 0; i < resChar.Length; i++)
                if (bits[i])
                    resChar[i] = '1';
                else
                    resChar[i] = '0';
            Array.Reverse(resChar);
            return new string(resChar);
        }
    }
}
