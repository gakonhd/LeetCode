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
            Console.WriteLine(Convert("PAYPALISHIRING", 4));
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
                var flippedLeft = true;
                var flippedRight = true;
                var falseCheck = 0;

                while (latest + check < arr.Length && falseCheck != 2)
                {
                    falseCheck = 2;
                    if (latest + left < arr.Length && left != 0 && flippedLeft)
                    {
                        builder.Append(arr[latest + left]);
                        latest = latest + left;
                        if (right != 0)
                        {
                            flippedRight = true;
                            flippedLeft = false;
                        }

                        falseCheck--;
                    }

                    if (latest + right < arr.Length && right != 0 && flippedRight)
                    {
                        builder.Append(arr[latest + right]);
                        latest = latest + right;
                        if (left != 0)
                        {
                            flippedLeft = true;
                            flippedRight = false;
                        }
                        falseCheck--;
                    }
                }
            }
            return builder.ToString();
        }
    }
}
