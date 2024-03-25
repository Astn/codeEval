using System;
using System.Collections.Generic;
using System.Linq;

namespace testproject
{
    public static class Warmup
    {
        /// <summary>
        /// Returns the greeting message "Hello World!".
        /// </summary>
        /// <returns>A string containing "Hello World!".</returns>
        public static string HelloWorld()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Calculates the sum of two integers.
        /// </summary>
        /// <param name="a">The first integer.</param>
        /// <param name="b">The second integer.</param>
        /// <returns>The sum of <paramref name="a"/> and <paramref name="b"/>.</returns>
        public static int sum(int a, int b)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Calculates the product of two integers.
        /// </summary>
        /// <param name="a">The first integer.</param>
        /// <param name="b">The second integer.</param>
        /// <returns>The product of <paramref name="a"/> and <paramref name="b"/>.</returns>
        public static int product(int a, int b)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Returns the square of an integer.
        /// </summary>
        /// <param name="a">The integer to square.</param>
        /// <returns>The square of <paramref name="a"/>.</returns>
        public static int square(int a)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Returns the cube of an integer.
        /// </summary>
        /// <param name="a">The integer to cube.</param>
        /// <returns>The cube of <paramref name="a"/>.</returns>
        public static int cube(int a)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Determines whether an integer is a perfect square.
        /// </summary>
        /// <param name="a">The integer to check.</param>
        /// <returns>True if <paramref name="a"/> is a perfect square, otherwise false.</returns>
        public static bool isPerfectSquare(int a)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Calculates the quotient of dividing two integers.
        /// </summary>
        /// <param name="a">The dividend.</param>
        /// <param name="b">The divisor. Must not be 0.</param>
        /// <returns>The quotient of <paramref name="a"/> divided by <paramref name="b"/>.</returns>
        /// <exception cref="DivideByZeroException">Thrown when <paramref name="b"/> is 0.</exception>
        public static int quotient(int a, int b)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Calculates the remainder of dividing two integers.
        /// </summary>
        /// <param name="a">The dividend.</param>
        /// <param name="b">The divisor. Must not be 0.</param>
        /// <returns>The remainder of <paramref name="a"/> divided by <paramref name="b"/>.</returns>
        /// <exception cref="DivideByZeroException">Thrown when <paramref name="b"/> is 0.</exception>
        public static int remainder(int a, int b)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Squares each number in a collection.
        /// </summary>
        /// <param name="xs">The collection of integers to square.</param>
        /// <returns>A new list containing the squares of each number in <paramref name="xs"/>.</returns>
        public static List<int> squareAll(IEnumerable<int> xs)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Cubes each number in a collection.
        /// </summary>
        /// <param name="xs">The collection of integers to cube.</param>
        /// <returns>A new list containing the cubes of each number in <paramref name="xs"/>.</returns>
        public static List<int> cubeAll(IEnumerable<int> xs)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Sums all numbers in a collection.
        /// </summary>
        /// <param name="xs">The collection of integers to sum.</param>
        /// <returns>The sum of all numbers in <paramref name="xs"/>.</returns>
        public static int sumAll(IEnumerable<int> xs)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Reverses the order of numbers in a collection.
        /// </summary>
        /// <param name="xs">The collection of integers to reverse.</param>
        /// <returns>A new list containing all numbers in <paramref name="xs"/> in reverse order.</returns>
        public static List<int> reverse(IEnumerable<int> xs)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Produces an infinite sequence of integers starting from a specified number.
        /// </summary>
        /// <param name="x">The starting number of the sequence.</param>
        /// <returns>An infinite sequence of integers starting at <paramref name="x"/>.</returns>
        public static IEnumerable<int> countFrom(int x)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Produces an infinite sequence of squares starting from the square of a specified number.
        /// </summary>
        /// <param name="x">The number from which to start the sequence of squares.</param>
        /// <returns>An infinite sequence of squares starting at the square of <paramref name="x"/>.</returns>
        public static IEnumerable<int> squaresFrom(int x)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Calculates the product of corresponding elements in two collections.
        /// </summary>
        /// <param name="xs">The first collection of integers.</param>
        /// <param name="ys">The second collection of integers.</param>
        /// <returns>A new sequence containing the products of corresponding elements from <paramref name="xs"/> and <paramref name="ys"/>.</returns>
        public static IEnumerable<int> productOfStreams(IEnumerable<int> xs, IEnumerable<int> ys)
        {
            throw new System.NotImplementedException();
        }
    }
}