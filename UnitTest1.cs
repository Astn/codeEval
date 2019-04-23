using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace testproject
{
  public class UnitTest1
  {
    [Fact]
    public void TestRunnerWorks()
    {
    }

    [Fact]
    public void HelloWorldTest()
    {
      Assert.Equal("Hello World!", Page1.HelloWorld());
    }

    [Fact]
    public void sumTest()
    {
      Assert.Equal(10, Page1.sum(0, 10));
      Assert.Equal(10, Page1.sum(2, 8));
      Assert.Equal(10, Page1.sum(6, 4));
      Assert.Equal(10, Page1.sum(5, 5));
    }

    [Fact]
    public void productTest()
    {
      Assert.Equal(100, Page1.product(1, 100));
      Assert.Equal(100, Page1.product(2, 50));
      Assert.Equal(100, Page1.product(4, 25));
      Assert.Equal(100, Page1.product(5, 20));
    }

    [Fact]
    public void squareTest()
    {
      Assert.Equal(1, Page1.square(1));
      Assert.Equal(4, Page1.square(2));
      Assert.Equal(16, Page1.square(4));
      Assert.Equal(25, Page1.square(5));
    }

    [Fact]
    public void cubeTest()
    {
      Assert.Equal(1, Page1.cube(1));
      Assert.Equal(8, Page1.cube(2));
      Assert.Equal(27, Page1.cube(3));
      Assert.Equal(64, Page1.cube(4));
    }

    [Fact]
    public void squareRootOfPerfectSquareTest()
    {
      Assert.True(Page1.isPerfectSquare(1));
      Assert.True(Page1.isPerfectSquare(4));
      Assert.True(Page1.isPerfectSquare(16));
      Assert.True(Page1.isPerfectSquare(25));
      Assert.False(Page1.isPerfectSquare(2));
      Assert.False(Page1.isPerfectSquare(-25));
    }

    [Fact]
    public void quotientTest()
    {
      Assert.Equal(2, Page1.quotient(101, 50));
      Assert.Equal(4, Page1.quotient(102, 25));
      Assert.Equal(5, Page1.quotient(103, 20));
      Assert.Equal(10, Page1.quotient(104, 10));
    }

    [Fact]
    public void remainderTest()
    {
      Assert.Equal(1, Page1.remainder(101, 50));
      Assert.Equal(2, Page1.remainder(102, 25));
      Assert.Equal(3, Page1.remainder(103, 20));
      Assert.Equal(4, Page1.remainder(104, 10));
    }

    [Fact]
    public void squareAllTest()
    {
      Assert.Equal(new List<int>{1, 4, 9, 16, 25}, Page1.squareAll(new List<int>{1, 2, 3, 4, 5}));
    }

    [Fact]
    public void cubeAllTest()
    {
      Assert.Equal(new List<int>{ 8, 27, 64, 125}, Page1.cubeAll(new List<int>{1, 2, 3, 4, 5}));
    }

    [Fact]
    public void sumAllTest()
    {
      Assert.Equal(100, Page1.sumAll(new List<int>{1, 9, 2, 8, 3, 7, 4, 6, 5, 5, 50}));
    }

    [Fact]
    public void reverseTest()
    {
      Assert.Equal(new List<int>{1, 5, 1, 2, 1, 9, 1, 3},
        Page1.reverse(new List<int>{3, 1, 9, 1, 2, 1, 5, 1}));
    }

    [Fact]
    public void countFromTest()
    {
      var actual1 = Page1.countFrom(0).Take(10000);
      var actual2 = Page1.countFrom(10000).Take(256);
      Assert.True(actual1.Min() == 0 && actual1.Max() == 9999 && actual1.Count() == 10000);
      Assert.True(actual2.Min() == 10000 && actual2.Max() == 10255 && actual2.Count() == 256);
    }

    [Fact]
    public void squaresFromTest()
    {
      var actual1 = Page1.squaresFrom(0).Take(10000);
      var actual2 = Page1.squaresFrom(10000).Take(500);
      Assert.True(actual1.Min() == 0 && actual1.Max() == 99980001 && actual1.Count() == 10000,
        $"{actual1.Min()} {actual1.Max()} {actual1.Count()}");
      Assert.True(actual2.Min() == 100000000 && actual2.Max() == 110229001 && actual2.Count() == 500,
        $"{actual2.Min()}  {actual2.Max()}  {actual2.Count()}");
    }

    [Fact]
    public void productOfStreamsTest()
    {
      var source1 = Page1.countFrom(0).Take(100);
      var source2 = Page1.countFrom(10).Take(100);
      var actual = Page1.productOfStreams(source1, source2);
      Assert.True(actual.Min() == 0 && actual.Max() == 10791 && actual.Count() == 100,
        $"{actual.Min()}  {actual.Max()} {actual.Count()}");
    }

    [Fact]
    public void allFibTest()
    {
      Assert.Equal(
        "0,1,1,2,3,5,8,13,21,34,55,89,144,233,377,610,987,1597,2584,4181",
        String.Join(",", Page2.allFib(0, 1).Take(20) ));
    }

    [Fact]
    public void firstNFibonacciNumbersTest()
    {
      void assertFirstNFib(int n, IEnumerable<int> expected) {
        var actual = Page2.firstNFibonacciNumbers(n);
        Assert.True(actual == expected, $"The first {n} fib are {expected}; But you had {actual}");
      }
      assertFirstNFib(3, new []{0, 1, 1});
      assertFirstNFib(6, new []{ 0, 1, 1, 2, 3, 5});
      assertFirstNFib(9, new []{0, 1, 1, 2, 3, 5, 8, 13, 21});
    }

    [Fact]
    public void isFibTest()
    {
      void assertNisFib(int n, Boolean isB)
      {
        Assert.True(Page2.isFibNumber(n) == isB, $"Is {n} a fib? {isB}; But you had {!isB}");
      }

      assertNisFib(0, true);
      assertNisFib(1, true);
      assertNisFib(2, true);
      assertNisFib(3, true);
      assertNisFib(4, false);
      assertNisFib(5, true);
      assertNisFib(6, false);
      assertNisFib(7, false);
      assertNisFib(8, true);
      assertNisFib(9, false);
    }

    [Fact]
    public void sumSomeFibTest()
    {
      void assertSumSomeFib(int lower ,int upper ,int expected ) {
        var actual = Page2.sumSomeFib(lower, upper);
        Assert.True(actual == expected,
          $"The sum of all fib from {lower} to {upper} is {expected} but you had {actual}");
      }

      assertSumSomeFib(0, 10, 20);
      assertSumSomeFib(10, 20, 13);
      assertSumSomeFib(30, 100, 178);
      assertSumSomeFib(100, 1000, 2351);
      assertSumSomeFib(0, 500, 986);
    }

    [Fact]
    public void parallelSumTest()
    {
      var source1 = Enumerable.Range(10, 10000);
      var actual = Page2.parallelSum(source1);
      var expected = 49994955;
      Assert.True(actual == expected, $"expected {expected} but got {actual}");
    }

    [Fact]
    public void isTextInStreamTest()
    {
      IEnumerable<String> stringToStream(string text, int chunkSize)
      {
        if (text == null || text.Length == 0)
        {
            yield break;
        }
        yield return text.Substring(0, Math.Min(text.Length, chunkSize));
        foreach (var str in stringToStream(text.Substring(Math.Min(text.Length, chunkSize)), chunkSize))
        {
            yield return str;
        }
      }

      var phrase1 =
        "The acts of the mind, wherein it exerts its power over simple ideas, are chiefly these three: 1. Combining several simple ideas into one compound one, and thus all complex ideas are made. 2. The second is bringing two ideas, whether simple or complex, together, and setting them by one another so as to take a view of them at once, without uniting them into one, by which it gets all its ideas of relations. 3. The third is separating them from all other ideas that accompany them in their real existence: this is called abstraction, and thus all its general ideas are made.";
      var phrase2 =
        "We now come to the decisive step of mathematical abstraction: we forget about what the symbols stand for. ...[The mathematician] need not be idle; there are many operations which he may carry out with these symbols, without ever having to look at the things they stand for.";
      Assert.True(Page2.isTextInStream(stringToStream(phrase1, 10), phrase1.Substring(37, 53)));
      Assert.True(Page2.isTextInStream(stringToStream(phrase2, 10), phrase2.Substring(30, 45)));
      Assert.True(Page2.isTextInStream(stringToStream(phrase1, 7), phrase1.Substring(37, 53)));
      Assert.True(Page2.isTextInStream(stringToStream(phrase2, 15), phrase2.Substring(30, 45)));
      Assert.False(Page2.isTextInStream(stringToStream(phrase1, 10), phrase2.Substring(37, 53)));
      Assert.False(Page2.isTextInStream(stringToStream(phrase2, 10), phrase1.Substring(30, 45)));
      Assert.False(Page2.isTextInStream(stringToStream(phrase1, 20), phrase2.Substring(37, 53)));
      Assert.False(Page2.isTextInStream(stringToStream(phrase2, 30), phrase1.Substring(30, 45)));
    }

    [Fact]
    public void keepFirstNegNumberTest()
    {
      Assert.Equal(new List<int> {5, 2, -3, 9, 10},
        Page2.keepFirstNegNumber(new List<int> {5, 2, -3, -4, 9, 10, -11}));
      Assert.Equal(new List<int> {5, 4, 3, 2, 1}, Page2.keepFirstNegNumber(new List<int> {5, 4, 3, 2, 1}));
      Assert.Equal(new List<int> {-1}, Page2.keepFirstNegNumber(new List<int>{-1, -2, -3, -4, -5}));
      Assert.Equal(new List<int>(), new List<int>());
    }
  }
}