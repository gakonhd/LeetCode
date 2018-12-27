using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATOI
{
    class Program
    {
        static void Main(string[] args)
        {
            var res = Solution("-2147483649");
            Console.WriteLine(res);

            Console.Read();
        }

        public static int Solution(string str)
        {
            if (string.IsNullOrEmpty(str)) return 0;
            var trimString = str.Trim();
            var charArr = trimString.ToCharArray();
            if (charArr.Length == 0 || char.IsLetter(charArr[0]))
                return 0;

            var isNegative = charArr[0] == '-';
            var idx = 0;
            var res = 0;
            if ((charArr[0] == '+' || charArr[0] == '-') && charArr.Length > 1) idx = 1;

            while (idx < charArr.Length && char.IsDigit(charArr[idx]))
            {
                var convert = char.GetNumericValue(charArr[idx]);
                if ((res > Int32.MaxValue / 10 || (res == Int32.MaxValue/ 10 && convert > 7) ) && !isNegative)
                    return Int32.MaxValue;

                if ((0 - res < Int32.MinValue / 10 || (0 - res == Int32.MinValue / 10 && convert > 7)) && isNegative)
                    return  Int32.MinValue;

                res = res * 10 + (int)convert;
                idx++;
            }

            if (isNegative) res = 0 - res;

            return res;
        }
    }
}
