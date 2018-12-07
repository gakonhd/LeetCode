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
            Console.WriteLine(LengthOfLongestSubstring("abcabcbb"));
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
        public static int LengthOfLongestSubstring(string s)
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
        }
    }
}
