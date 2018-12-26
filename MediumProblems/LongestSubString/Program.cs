using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestSubString
{
    class Program
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine(LongestPalindrome("eabcb"));
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
        /*public static int LengthOfLongestSubstring(string s)
        {
            int i = 0, res = 0;
            var mySet = new HashSet<char>();
            var myQueue = new Queue<char>();

            while (i < s.Length)
            {
                if (mySet.Contains(s[i]))
                {
                    while (myQueue.Peek() != s[i])
                    {
                        mySet.Remove(myQueue.Dequeue());
                    }
                    mySet.Remove(myQueue.Dequeue());
                }

                mySet.Add(s[i]);
                myQueue.Enqueue(s[i]);
                if (myQueue.Count > res)
                {
                    res = myQueue.Count;
                }

                i++;
            }
            return res;
        }*/

        public static string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            int start = 0, end = 0;
            for (var i = 0; i < s.Length; i++)
            {
                var len1 = ExpandAroundCenter(s, i, i);
                var len2 = ExpandAroundCenter(s, i, i + 1);
                var len = Math.Max(len1, len2);
                if (len > end - start)
                {
                    start = i - (len - 1) / 2;
                    end = i + len / 2;
                }
            }
            return s.Substring(start, end-start+1);
        }

        private static int ExpandAroundCenter(string s, int left, int right)
        {
            int leftIdx = left, rightIdx = right;
            var charArr = s.ToCharArray();
            while (leftIdx >= 0 && rightIdx < s.Length && charArr[leftIdx] == charArr[rightIdx])
            {
                leftIdx--;
                rightIdx++;
            }
            return rightIdx - leftIdx - 1;
        }
    }
}
