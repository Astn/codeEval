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
        /// <remarks>
        /// <para><b>Example:</b> The method should simply return the string "Hello World!".</para>
        /// </remarks>
        public static string HelloWorld()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Calculates the sum of two integers.
        /// </summary>
        /// <param name="a">The first integer, denoted as <c>a</c>.</param>
        /// <param name="b">The second integer, denoted as <c>b</c>.</param>
        /// <returns>The sum of <paramref name="a"/> and <paramref name="b"/>, calculated as <c>a + b</c>.</returns>
        /// <remarks>
        /// <para><b>Mathematical Definition:</b> <c>sum(a, b) = a + b</c>.</para>
        /// <para><b>Example:</b> If <c>a = 2</c> and <c>b = 3</c>, then <c>sum(a, b) = 5</c>.</para>
        /// </remarks>
        public static int sum(int a, int b)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Calculates the product of two integers.
        /// </summary>
        /// <param name="a">The first integer, denoted as <c>a</c>.</param>
        /// <param name="b">The second integer, denoted as <c>b</c>.</param>
        /// <returns>The product of <paramref name="a"/> and <paramref name="b"/>, calculated as <c>a × b</c>.</returns>
        /// <remarks>
        /// <para><b>Mathematical Definition:</b> <c>product(a, b) = a × b</c>.</para>
        /// <para><b>Example:</b> If <c>a = 4</c> and <c>b = 5</c>, then <c>product(a, b) = 20</c>.</para>
        /// </remarks>
        public static int product(int a, int b)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the square of an integer.
        /// </summary>
        /// <param name="a">The integer to square, denoted as <c>a</c>.</param>
        /// <returns>The square of <paramref name="a"/>, calculated as <c>a²</c>.</returns>
        /// <remarks>
        /// <para><b>Mathematical Definition:</b> <c>square(a) = a²</c>.</para>
        /// <para><b>Example:</b> If <c>a = 3</c>, then <c>square(a) = 9</c>.</para>
        /// </remarks>
        public static int square(int a)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the cube of an integer.
        /// </summary>
        /// <param name="a">The integer to cube, denoted as <c>a</c>.</param>
        /// <returns>The cube of <paramref name="a"/>, calculated as <c>a³</c>.</returns>
        /// <remarks>
        /// <para><b>Mathematical Definition:</b> <c>cube(a) = a³</c>.</para>
        /// <para><b>Example:</b> If <c>a = 2</c>, then <c>cube(a) = 8</c>.</para>
        /// </remarks>
        public static int cube(int a)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Calculates the quotient of dividing two integers using integer division.
        /// </summary>
        /// <param name="a">The dividend, denoted as <c>a</c>.</param>
        /// <param name="b">The divisor, denoted as <c>b</c>. Must not be 0.</param>
        /// <returns>The quotient of <paramref name="a"/> divided by <paramref name="b"/>, calculated as <c>a ÷ b</c> using integer division.</returns>
        /// <exception cref="DivideByZeroException">Thrown when <paramref name="b"/> is 0.</exception>
        /// <remarks>
        /// <para><b>Mathematical Definition:</b> <c>quotient(a, b) = a ÷ b</c> (integer division).</para>
        /// <para><b>Example:</b> If <c>a = 7</c> and <c>b = 2</c>, then <c>quotient(a, b) = 3</c>.</para>
        /// </remarks>
        public static int quotient(int a, int b)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Calculates the remainder of dividing two integers.
        /// </summary>
        /// <param name="a">The dividend, denoted as <c>a</c>.</param>
        /// <param name="b">The divisor, denoted as <c>b</c>. Must not be 0.</param>
        /// <returns>The remainder of <paramref name="a"/> divided by <paramref name="b"/>, calculated as <c>a mod b</c>.</returns>
        /// <exception cref="DivideByZeroException">Thrown when <paramref name="b"/> is 0.</exception>
        /// <remarks>
        /// <para><b>Mathematical Definition:</b> <c>remainder(a, b) = a mod b</c>.</para>
        /// <para><b>Example:</b> If <c>a = 7</c> and <c>b = 2</c>, then <c>remainder(a, b) = 1</c>.</para>
        /// </remarks>
        public static int remainder(int a, int b)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines whether an integer is a perfect square.
        /// </summary>
        /// <param name="a">The integer to check, denoted as <c>a</c>.</param>
        /// <returns><c>true</c> if <paramref name="a"/> is a perfect square (i.e., there exists an integer <c>n</c> such that <c>n² = a</c>), otherwise <c>false</c>.</returns>
        /// <remarks>
        /// <para><b>Example:</b> <c>isPerfectSquare(16)</c> returns <c>true</c> because <c>4² = 16</c>.</para>
        /// <para><b>Example:</b> <c>isPerfectSquare(15)</c> returns <c>false</c>.</para>
        /// </remarks>
        public static bool isPerfectSquare(int a)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Squares each number in a collection.
        /// </summary>
        /// <param name="xs">The collection of integers to square, denoted as <c>{ x₁, x₂, ..., xₙ }</c>.</param>
        /// <returns>A new list containing the squares of each number in <paramref name="xs"/>, i.e., <c>{ x₁², x₂², ..., xₙ² }</c>.</returns>
        /// <remarks>
        /// <para><b>Example:</b> If <c>xs = [1, 2, 3]</c>, then <c>squareAll(xs) = [1, 4, 9]</c>.</para>
        /// </remarks>
        public static List<int> squareAll(IEnumerable<int> xs)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Cubes each number in a collection.
        /// </summary>
        /// <param name="xs">The collection of integers to cube, denoted as <c>{ x₁, x₂, ..., xₙ }</c>.</param>
        /// <returns>A new list containing the cubes of each number in <paramref name="xs"/>, i.e., <c>{ x₁³, x₂³, ..., xₙ³ }</c>.</returns>
        /// <remarks>
        /// <para><b>Example:</b> If <c>xs = [1, 2, 3]</c>, then <c>cubeAll(xs) = [1, 8, 27]</c>.</para>
        /// </remarks>
        public static List<int> cubeAll(IEnumerable<int> xs)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sums all numbers in a collection.
        /// </summary>
        /// <param name="xs">The collection of integers to sum, denoted as <c>{ x₁, x₂, ..., xₙ }</c>.</param>
        /// <returns>The sum of all numbers in <paramref name="xs"/>, calculated as <c>∑(xᵢ)</c> for <c>i = 1</c> to <c>n</c>.</returns>
        /// <remarks>
        /// <para><b>Example:</b> If <c>xs = [1, 2, 3, 4]</c>, then <c>sumAll(xs) = 10</c>.</para>
        /// </remarks>
        public static int sumAll(IEnumerable<int> xs)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reverses the order of numbers in a collection.
        /// </summary>
        /// <param name="xs">The collection of integers to reverse, denoted as <c>[x₁, x₂, ..., xₙ]</c>.</param>
        /// <returns>A new list containing all numbers in <paramref name="xs"/> in reverse order, i.e., <c>[xₙ, xₙ₋₁, ..., x₁]</c>.</returns>
        /// <remarks>
        /// <para><b>Example:</b> If <c>xs = [1, 2, 3]</c>, then <c>reverse(xs) = [3, 2, 1]</c>.</para>
        /// </remarks>
        public static List<int> reverse(IEnumerable<int> xs)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Produces an infinite sequence of integers starting from a specified number.
        /// </summary>
        /// <param name="x">The starting number of the sequence, denoted as <c>x</c>.</param>
        /// <returns>An infinite sequence of integers starting at <paramref name="x"/>, i.e., <c>[x, x + 1, x + 2, ...]</c>.</returns>
        /// <remarks>
        /// <para><b>Example:</b> If <c>x = 5</c>, the sequence is <c>[5, 6, 7, 8, ...]</c>.</para>
        /// </remarks>
        public static IEnumerable<int> countFrom(int x)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Produces an infinite sequence of squares starting from the square of a specified number.
        /// </summary>
        /// <param name="x">The number from which to start the sequence of squares, denoted as <c>x</c>.</param>
        /// <returns>An infinite sequence of squares starting at <c>x²</c>, i.e., <c>[x², (x + 1)², (x + 2)², ...]</c>.</returns>
        /// <remarks>
        /// <para><b>Example:</b> If <c>x = 2</c>, the sequence is <c>[4, 9, 16, 25, ...]</c>.</para>
        /// </remarks>
        public static IEnumerable<int> squaresFrom(int x)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Calculates the product of corresponding elements in two collections.
        /// </summary>
        /// <param name="xs">The first collection of integers, denoted as <c>{ x₁, x₂, ..., xₙ }</c>.</param>
        /// <param name="ys">The second collection of integers, denoted as <c>{ y₁, y₂, ..., yₙ }</c>.</param>
        /// <returns>A new sequence containing the products of corresponding elements from <paramref name="xs"/> and <paramref name="ys"/>, i.e., <c>{ x₁ × y₁, x₂ × y₂, ..., xₙ × yₙ }</c>.</returns>
        /// <remarks>
        /// <para><b>Mathematical Definition:</b> <c>productOfStreams(xs, ys) = { xᵢ × yᵢ }</c> for <c>i = 1</c> to <c>n</c>.</para>
        /// <para><b>Example:</b> If <c>xs = [1, 2, 3]</c> and <c>ys = [4, 5, 6]</c>, then <c>productOfStreams(xs, ys) = [4, 10, 18]</c>.</para>
        /// <para>The sequences are assumed to be of the same length. If they are of different lengths, the resulting sequence will be as long as the shorter one.</para>
        /// </remarks>
        public static IEnumerable<int> productOfStreams(IEnumerable<int> xs, IEnumerable<int> ys)
        {
            throw new NotImplementedException();
        }
    }
}
