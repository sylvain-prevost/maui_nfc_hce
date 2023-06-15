using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiNfcHceBootStrapExample
{
    internal class Util
    {
        public static byte[] HexStringToByteArray(string input)
        {
            if ((input.Length % 2) != 0)
            {
                throw new ArgumentException("input byte length must be modulo-2");
            }

            byte[] output = new byte[input.Length / 2];

            for (int i = 0; i < output.Length; i++)
            {
                output[i] = (byte)Convert.ToInt32(input.Substring(i * 2, 2), 16);
            }

            return output;
        }

        public static string ByteArrayToHexString(byte[] input, int offset, int len)
        {
            StringBuilder output = new StringBuilder();
            for (int i = offset; i < offset + len; i++)
            {
                output.Append(String.Format("{0:X2}", input[i]));
            }
            return output.ToString();
        }

        public static string ByteArrayToHexString(byte[] input)
        {
            return ByteArrayToHexString(input, 0, input.Length);
        }
    }
}
