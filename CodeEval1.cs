using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileChunk = string;
namespace testproject
{
    public static class CodeEval1
    {
        /// <summary>
        /// Generates an infinite sequence of Fibonacci numbers starting from specified initial values.
        /// If the initial values for f1 and f2 are (0, 1) then the sequence will start with [0, 1, 1, 2, 3, 5, 8, 13, ...].
        /// </summary>
        /// <param name="f1">The first term in the Fibonacci sequence.</param>
        /// <param name="f2">The second term in the Fibonacci sequence.</param>
        /// <returns>An infinite sequence of Fibonacci numbers as <see cref="IEnumerable{int}"/>.</returns>
        public static IEnumerable<int> allFib(int f1, int f2)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Generates a sequence of the first N Fibonacci numbers.
        /// </summary>
        /// <param name="n">The number of Fibonacci numbers to generate. Must be non-negative.</param>
        /// <returns>A sequence of the first N Fibonacci numbers as <see cref="IEnumerable{int}"/>.</returns>
        public static IEnumerable<int> firstNFibonacciNumbers(int n)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines if a given number is a Fibonacci number.
        /// </summary>
        /// <param name="n">The number to check.</param>
        /// <returns>True if <paramref name="n"/> is a Fibonacci number, otherwise false.</returns>
        public static bool isFibNumber(int n)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sums all Fibonacci numbers within a specified range, inclusive.
        /// </summary>
        /// <param name="lower">The lower bound of the range.</param>
        /// <param name="upper">The upper bound of the range.</param>
        /// <returns>The sum of all Fibonacci numbers between <paramref name="lower"/> and <paramref name="upper"/>, inclusive.</returns>
        public static int sumSomeFib(int lower, int upper)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sums a sequence of integers in parallel.
        /// </summary>
        /// <param name="xs">The sequence of integers to sum.</param>
        /// <returns>The sum of all integers in <paramref name="xs"/>.</returns>
        public static int parallelSum(IEnumerable<int> xs)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines if a specified substring occurs within a stream of text chunks, simulating reading from a very large file.
        /// </summary>
        /// <param name="chunksFromA10GBfile">The stream of text chunks.</param>
        /// <param name="substring">The substring to search for within the stream.</param>
        /// <returns>True if <paramref name="substring"/> is found within the stream, otherwise false.</returns>
        /// <remarks>
        /// This function is designed to be memory efficient and handle cases where the substring spans multiple chunks.
        /// </remarks>
       
        public static bool isTextInStream(IEnumerable<FileChunk> chunksFromA10GBfile, string substring)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Filters a sequence of integers to keep all positive numbers and only the first negative number encountered, maintaining the original order.
        /// </summary>
        /// <param name="xs">The sequence of integers to filter.</param>
        /// <returns>A filtered sequence as <see cref="IEnumerable{int}"/> according to the specified criteria.</returns>
        /// <remarks>
        /// This method is memory efficient and does not require converting the entire sequence into a List or Array.
        /// </remarks>
        public static IEnumerable<int> keepFirstNegNumber(IEnumerable<int> xs)
        {
            throw new NotImplementedException();
        }
    }
}