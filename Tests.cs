using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace testproject
{
    public class Tests
    {
        
        // inject the xunit test logger
        private readonly ITestOutputHelper output; // logger for xUnit Test.

        public Tests(ITestOutputHelper output)
        {
            this.output = output; // inject the xunit test logger.
        }
        
        
        // Verifies that the test framework is set up and running.
        [Fact]
        public void TestFrameworkIsOperational()
        {
        }

        // Tests that HelloWorld returns the expected string.
        [Fact]
        public void HelloWorld_ReturnsCorrectString()
        {
            Assert.Equal("Hello World!", Page1.HelloWorld());
        }

        // Verifies the sum function with multiple pairs of inputs.
        [Theory]
        [InlineData(0, 10, 10)]
        [InlineData(2, 8, 10)]
        [InlineData(6, 4, 10)]
        [InlineData(5, 5, 10)]
        public void Sum_CorrectlyAddsTwoNumbers(int a, int b, int expected)
        {
            Assert.Equal(expected, Page1.sum(a, b));
        }

        // Tests the product function with different inputs.
        [Theory]
        [InlineData(1, 100, 100)]
        [InlineData(2, 50, 100)]
        [InlineData(4, 25, 100)]
        [InlineData(5, 20, 100)]
        public void Product_CorrectlyMultipliesTwoNumbers(int a, int b, int expected)
        {
            Assert.Equal(expected, Page1.product(a, b));
        }

        // Verifies the square function against known squares.
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 4)]
        [InlineData(4, 16)]
        [InlineData(5, 25)]
        public void Square_ReturnsCorrectSquareOfNumber(int number, int expectedSquare)
        {
            Assert.Equal(expectedSquare, Page1.square(number));
        }

        // Tests the cube function with known cubes.
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 8)]
        [InlineData(3, 27)]
        [InlineData(4, 64)]
        public void Cube_ReturnsCorrectCubeOfNumber(int number, int expectedCube)
        {
            Assert.Equal(expectedCube, Page1.cube(number));
        }

        // Verifies isPerfectSquare with both perfect squares and non-squares.
        [Theory]
        [InlineData(1, true)]
        [InlineData(4, true)]
        [InlineData(16, true)]
        [InlineData(25, true)]
        [InlineData(2, false)]
        [InlineData(-25, false)]
        public void IsPerfectSquare_CorrectlyIdentifiesPerfectSquares(int number, bool expectedResult)
        {
            Assert.Equal(expectedResult, Page1.isPerfectSquare(number));
        }

        // Tests quotient calculation with various dividends and divisors.
        [Theory]
        [InlineData(101, 50, 2)]
        [InlineData(102, 25, 4)]
        [InlineData(103, 20, 5)]
        [InlineData(104, 10, 10)]
        public void Quotient_CorrectlyCalculatesQuotient(int dividend, int divisor, int expectedQuotient)
        {
            Assert.Equal(expectedQuotient, Page1.quotient(dividend, divisor));
        }

        // Verifies the remainder function with multiple test cases.
        [Theory]
        [InlineData(101, 50, 1)]
        [InlineData(102, 25, 2)]
        [InlineData(103, 20, 3)]
        [InlineData(104, 10, 4)]
        public void Remainder_CorrectlyCalculatesRemainder(int dividend, int divisor, int expectedRemainder)
        {
            Assert.Equal(expectedRemainder, Page1.remainder(dividend, divisor));
        }

        [Fact]
        public void SquareAll_ReturnsSquaredValuesOfList()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };
            var expectedResult = new List<int> { 1, 4, 9, 16, 25 };
            var result = Page1.squareAll(numbers);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void CubeAll_ReturnsCubedValuesOfList()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };
            var expectedResult = new List<int> { 1, 8, 27, 64, 125 };
            var result = Page1.cubeAll(numbers);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void SumAll_ReturnsSumOfAllNumbersInList()
        {
            var numbers = new List<int> { 1, 9, 2, 8, 3, 7, 4, 6, 5, 5, 50 };
            var expectedResult = 100;
            var result = Page1.sumAll(numbers);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void ReverseList_ReturnsReversedOrderOfElements()
        {
            // Arrange
            var inputList = new List<int> { 3, 1, 9, 1, 2, 1, 5, 1 };
            var expectedList = new List<int> { 1, 5, 1, 2, 1, 9, 1, 3 };

            // Act
            var result = Page1.reverse(inputList);

            // Assert
            Assert.Equal(expectedList, result);
        }

        [Theory]
        [InlineData(0, 9999, 10000)]
        [InlineData(10000, 10255, 256)]
        public void CountFrom_GeneratesCorrectSequence(int start, int expectedMax, int expectedCount)
        {
            // Act
            var result = Page1.countFrom(start).Take(expectedCount);

            // Assert
            Assert.Equal(expectedCount, result.Count());
            Assert.Equal(expectedMax, result.Max());
        }

        [Theory]
        [InlineData(0, 99980001, 10000)]
        [InlineData(10000, 110229001, 500)]
        public void SquaresFrom_GeneratesCorrectSequenceOfSquares(int start, int expectedMaxSquare, int count)
        {
            // Act
            var result = Page1.squaresFrom(start).Take(count);

            // Assert
            Assert.Equal(count, result.Count());
            Assert.Equal(expectedMaxSquare, result.Max());
        }

        [Fact]
        public void ProductOfStreams_ReturnsCorrectProductSequence()
        {
            // Arrange
            var source1 = Page1.countFrom(0).Take(100);
            var source2 = Page1.countFrom(10).Take(100);

            // Act
            var result = Page1.productOfStreams(source1, source2).ToList();

            // Assert
            Assert.Equal(0, result.First()); // First element check
            Assert.Equal(10791, result.Last()); // Last element check
            Assert.Equal(100, result.Count); // Count check
        }

        [Fact]
        public void AllFib_GeneratesCorrectFibonacciSequence()
        {
            // Arrange
            var expectedSequence = "0,1,1,2,3,5,8,13,21,34,55,89,144,233,377,610,987,1597,2584,4181";

            // Act
            var result = string.Join(",", Page2.allFib(0, 1).Take(20));

            // Assert
            Assert.Equal(expectedSequence, result);
        }

        [Theory]
        [InlineData(3, "0,1,1")]
        [InlineData(6, "0,1,1,2,3,5")]
        [InlineData(9, "0,1,1,2,3,5,8,13,21")]
        public void FirstNFibonacciNumbers_GeneratesCorrectSequence(int n, string expectedSequence)
        {
            // Arrange
            var expected = expectedSequence.Split(',').Select(int.Parse);

            // Act
            var result = Page2.firstNFibonacciNumbers(n);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, true)]
        [InlineData(1, true)]
        [InlineData(4, false)]
        [InlineData(8, true)]
        public void IsFibNumber_IdentifiesFibonacciNumbersCorrectly(int n, bool expected)
        {
            // Act
            var result = Page2.isFibNumber(n);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, 10, 20)]
        [InlineData(10, 20, 13)]
        [InlineData(30, 100, 178)]
        public void SumSomeFib_SumsFibonacciNumbersWithinRangeCorrectly(int lower, int upper, int expectedSum)
        {
            // Act
            var result = Page2.sumSomeFib(lower, upper);

            // Assert
            Assert.Equal(expectedSum, result);
        }

        [Fact]
        public void ParallelSum_CalculatesSumOfRangeCorrectly()
        {
            // Arrange
            var source = Enumerable.Range(10, 10000);
            var expected = 50095000;

            // Act
            var result = Page2.parallelSum(source);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void IsTextInStream_FindsSubstringAcrossChunksCorrectly()
        {
            // Arrange
            var text = "This is a test string to validate the IsTextInStream method.";
            var chunkSize = 10;

            // Act & Assert
            Assert.True(Page2.isTextInStream(StringToStream(text, chunkSize), "validate the IsTextIn"));
            Assert.False(Page2.isTextInStream(StringToStream(text, chunkSize), "nonexistent substring"));
        }

        [Fact]
        public void KeepFirstNegNumber_FiltersSequenceCorrectly()
        {
            // Arrange
            var inputSequence = new List<int> { 5, 2, -3, -4, 9, 10, -11 };
            var expectedSequence = new List<int> { 5, 2, -3, 9, 10 };

            // Act
            var result = Page2.keepFirstNegNumber(inputSequence);

            // Assert
            Assert.Equal(expectedSequence, result);
        }

        private IEnumerable<string> StringToStream(string text, int chunkSize)
        {
            for (int i = 0; i < text.Length; i += chunkSize)
            {
                yield return text.Substring(i, Math.Min(chunkSize, text.Length - i));
            }
        }

        // (textProcessed, memoryUsed, time)
        private List<BigOEstimator.ProcessingMetric> memoryUsageCheckpoints = new ();

        [Theory]
        [InlineData(524288)] // ~1 MB
        [InlineData(5242880)] // ~10 MB
        [InlineData(52428800)] // ~100 MB
        public void IsTextInStream_FindsSubstringAcrossChunksCorrectly_WithMemoryChecks(int totalLength)
        {
            memoryUsageCheckpoints.Clear();
            // Arrange
            var chunkSize = 10240; // 10 KB chunks
            var memoryUsageBefore = GetCurrentMemoryUsage();
            
            var checkpointSize = 10240; // 100 KB checkpoints
            var pattern = "validate the IsTextIn"; // Substring to be found

            var sw = Stopwatch.StartNew();
            // Generate a stream of text lazily with a configurable length
            // and collect memory usage data at each checkpoint
            var textStream = GenerateTextStreamWithMemoryCheckpoints(totalLength, chunkSize, checkpointSize, pattern, 4,
                (long ofX) =>
                {
                    memoryUsageCheckpoints.Add(new (ofX,GetCurrentMemoryUsage()-memoryUsageBefore, sw.ElapsedMilliseconds));        
                });
            memoryUsageBefore = GetCurrentMemoryUsage();
            output.WriteLine($"Memory usage before test: {memoryUsageBefore} bytes");
            // Act
            var found = Page2.isTextInStream(textStream, pattern);
            sw.Stop();
            // Calculate the maximum memory usage during the test
            var bigO = new BigOEstimator(output);
            var bigOMemory = bigO.EstimateComplexityMemory(memoryUsageCheckpoints);
            var bigOTime = bigO.EstimateComplexityTime(memoryUsageCheckpoints);
            // Assert
            Assert.True(found, "The pattern should be found in the generated text stream.");
            Assert.False(bigOMemory == "O(n)", $"Your memory usage was estimated to be {bigOMemory}");
            Assert.False(bigOTime == "O(n)", $"Your time usage was estimated to be {bigOTime}");
                
            // Log the maximum memory usage during the test
            output.WriteLine($"Memory usage during test: {bigOMemory}");
            output.WriteLine($"Time usage during test: {bigOTime}");
            output.WriteLine($"Maximum memory usage during test: {memoryUsageCheckpoints.Max(x => x.MemoryUsed)} bytes");
            output.WriteLine($"Time taken: {sw.ElapsedMilliseconds} ms");
            // Reset the checkpoints list for future tests
            memoryUsageCheckpoints.Clear();
        }

        public static IEnumerable<string> GenerateTextStreamWithMemoryCheckpoints(int totalLength, int chunkSize,
            int checkpointSize, string pattern, int patternInsertionChunkIndex = 2, Action<long> memoryCheckpointAction = null)
        {
            if (totalLength <= 0)
                throw new ArgumentException("Total length must be greater than 0.", nameof(totalLength));
            if (chunkSize <= 0)
                throw new ArgumentException("Chunk size must be greater than 0.", nameof(chunkSize));
            if (checkpointSize <= 0)
                throw new ArgumentException("Checkpoint size must be greater than 0.", nameof(checkpointSize));

            var patternLength = pattern.Length;
            var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var totalProduced = 0;
            var currentCheckpoint = 0;

            var chunks = new List<string>();
            
            while (totalProduced < totalLength)
            {
                var currentChunkSize = Math.Min(chunkSize, totalLength - totalProduced);
                var chunk = new char[currentChunkSize];
                var effectiveChunkSize = currentChunkSize; // Adjusted for pattern insertion

                // If this is the chunk where we insert the pattern
                if (totalProduced / chunkSize == patternInsertionChunkIndex)
                {
                    effectiveChunkSize -= patternLength; // Make room for the pattern
                }

                for (int i = 0; i < effectiveChunkSize; i++)
                {
                    chunk[i] = alphabet[(totalProduced + i) % alphabet.Length];
                }

                // Insert the pattern at the middle of the specified chunk
                if (totalProduced / chunkSize == patternInsertionChunkIndex)
                {
                    var midPoint = effectiveChunkSize / 2;
                    Array.Copy(chunk, midPoint, chunk, midPoint + patternLength,
                        effectiveChunkSize - midPoint); // Shift right part
                    for (int i = 0; i < patternLength; i++)
                    {
                        chunk[midPoint + i] = pattern[i];
                    }
                }

                //yield return new string(chunk);
                chunks.Add(new string(chunk));
                totalProduced += chunk.Length;
            }

            totalProduced = 0;
            foreach (var ch in chunks)
            {
                yield return ch;
                totalProduced += ch.Length;

                // Memory checkpoint logic goes here
                if (totalProduced - currentCheckpoint >= checkpointSize)
                {
                    // Log memory usage or perform any checkpoint action here
                    currentCheckpoint = totalProduced;
                    memoryCheckpointAction?.Invoke(currentCheckpoint);
                }
            }
        }



        private long GetCurrentMemoryUsage()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            return GC.GetTotalMemory(true);
        }
    }

    public class UtilityTests
    {
        
        // inject the xunit test logger
        private readonly ITestOutputHelper output; // logger for xUnit Test.

        public UtilityTests(ITestOutputHelper output)
        {
            this.output = output; // inject the xunit test logger.
        }
        
        [Fact]
        public void EstimateComplexity_ShouldIdentifyLinearComplexity()
        {
            var data = new List<BigOEstimator.ProcessingMetric>
            {
                new (1000, 1000, 0), // TextProcessed, MemoryUsed, Time
                new (2000, 2000, 0),
                new (3000, 3000, 0),
                new (4000, 4000, 0),
                new (5000, 5000, 0)
            };

            var estimator = new BigOEstimator(output);
            estimator.EstimateComplexityMemory(data);

            // Assert the closest match is linear (e.g., check console output or adapt method for testing)
        }
        
        [Fact]
        public void EstimateComplexity_ShouldIdentifyLogarithmicComplexity()
        {
            var data = new List<BigOEstimator.ProcessingMetric>
            {
                new (10, (long)Math.Log2(10), 0),
                new (100, (long)Math.Log2(100), 0),
                new (1000, (long)Math.Log2(1000), 0),
                new (10000, (long)Math.Log2(10000), 0),
                new (100000, (long)Math.Log2(100000), 0)
            };

            var estimator = new BigOEstimator(output);
            estimator.EstimateComplexityMemory(data);

            // Assert the closest match is logarithmic
        }

        [Fact]
        public void EstimateComplexity_ShouldIdentifyNLogNComplexity()
        {
            var data = new List<BigOEstimator.ProcessingMetric>
            {
                new (10, (long)(10 * Math.Log2(10)), 0),
                new (100, (long)(100 * Math.Log2(100)), 0),
                new (1000, (long)(1000 * Math.Log2(1000)), 0),
                new (10000, (long)(10000 * Math.Log2(10000)), 0),
                new (100000, (long)(100000 * Math.Log2(100000)), 0)
            };

            var estimator = new BigOEstimator(output);
            estimator.EstimateComplexityMemory(data);

            // Assert the closest match is N Log N
        }

    }
}