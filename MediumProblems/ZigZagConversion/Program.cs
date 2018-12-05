using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZigZagConversion
{
    class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine(Convert("PAYPALISHIRING", 3).Equals("PAHNAPLSIIGYIR"));
            Console.WriteLine(Convert("A", 2));
            Console.ReadKey();


        }

        public static string Convert(string s, int numRows)
        {
            if (numRows == 1) return s;
            var distance = (numRows - 1) * 2;
            var arr = s.ToCharArray();
            var builder = new StringBuilder();
            for (var i = 0; i < numRows; i++)
            {
                if (i >= arr.Length) break;
                builder.Append(arr[i]);
                var left = (numRows - 1) * 2 - (i * 2);
                var right = distance - left;
                var latest = i;
                var check = (left != 0) ? left : right;
                while (latest + check < arr.Length)
                {
                    if (latest + left < arr.Length && left != 0)
                    {
                        builder.Append(arr[latest + left]);
                        latest = latest + left;
                    }
                    if (latest + right < arr.Length && right != 0)
                    {
                        builder.Append(arr[latest + right]);
                        latest = latest + right;
                    }
                }
            }
            return builder.ToString();
        }
    }
}
