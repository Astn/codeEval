using System.Collections.Generic;
using System.Linq;

namespace testproject
{
    public static class Page2
    {
        // An endless stream of Fibonacci numbers starting with f1 and f2
        public static IEnumerable<int> allFib(int f1, int f2)
        {
            throw new System.NotImplementedException();
        }

        // Return a stream of N Fibonacci numbers starting at N
        public static IEnumerable<int> firstNFibonacciNumbers(int n)
        {
            throw new System.NotImplementedException();
        }

        // Determine if N is a Fibonacci number
        public static bool isFibNumber(int n)
        {
            throw new System.NotImplementedException();
        }

        // Sum all of the 'Fibonacci numbers' between lower and upper inclusive.
        public static int sumSomeFib(int lower, int upper)
        {
            throw new System.NotImplementedException();
        }

        // produce the sum of all xs in parallel
        public static int parallelSum(IEnumerable<int> xs)
        {
            throw new System.NotImplementedException();
        }

        // Determine if the text occurs somewhere in the stream.
        // Code as if the stream was accessing a very large file that would not fit in memory.
        // 'text' is larger then a single stream, and is not aligned with
        // a string in the stream. You will have to handle the text being spread
        // across multiple strings in the stream
        public static bool isTextInStream(IEnumerable<string> chunksFromA10GBfile, string substring)
        {
            throw new System.NotImplementedException();
        }

        // Keep all positive numbers, but only the first negative number, maintain order.
        // Be memory efficient, Do not pull the entire Enumerable into a List or Array.
        public static IEnumerable<int> keepFirstNegNumber(IEnumerable<int> xs)
        {
            throw new System.NotImplementedException();
        }
    }
}