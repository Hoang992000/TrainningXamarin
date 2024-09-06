using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NhatMinhQCI.Utilities
{
    public class ConvertData
    {
        public static String HexToString(Byte[] pInput, int nLen)
        {
            StringBuilder strTemp = new StringBuilder(nLen * 2);
            int i = 0;
            foreach (byte pTemp in pInput)
            {
                i++;
                strTemp.AppendFormat("{0:x2}", pTemp);

                if (i == nLen)
                    break;
            }
            return strTemp.ToString();
        }

        public static String StringToHex(string input)
        {
            char[] charValues = input.ToCharArray();
            string hexOutput = "";
            foreach (char _eachChar in charValues)
            {
                int value = Convert.ToInt32(_eachChar);
                hexOutput += String.Format("{0:X}", value);

            }
            return hexOutput;
        }

        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        public static String IntToString(int ret)
        {
            StringBuilder strTemp = new StringBuilder(2);

            strTemp.AppendFormat("{0:d2}", ret);

            return strTemp.ToString();
        }

        public static byte[] StringToBytes(string str)
        {
            string[] hexValuesSplit = new string[str.Length / 2];
            byte[] byteArray = new byte[hexValuesSplit.Length];
            int i = 0;

            for (i = 0; i < str.Length / 2; i++)
            {
                hexValuesSplit[i] = str.Substring(i * 2, 2);
            }

            i = 0;
            foreach (String hex in hexValuesSplit)
            {
                int value = Convert.ToInt32(hex, 16);
                byte bytevalue = Convert.ToByte(value);

                byteArray[i++] = bytevalue;
            }

            return byteArray;
        }

        public static byte IntToByte(int block)
        {
            byte blocknum;
            blocknum = Convert.ToByte(block);
            return blocknum;
        }

        public static decimal ByteToDecimal(byte[] data)
        {
            decimal x = 0;


            using (MemoryStream stream = new MemoryStream(data))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    x = reader.ReadDecimal();
                }
            }
            return x;
        }

        public static string BinToString(string s)
        {
            StringBuilder bin = new StringBuilder();

            for (int i = 0; i <= s.Length - 8; i += 8)
            {
                int k = Convert.ToInt32(s.Substring(i, 8), 2);
                bin.Append((char)k);
            }

            return bin.ToString().Trim();
        }
    }
}