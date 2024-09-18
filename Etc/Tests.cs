using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
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
        public void _01_HelloWorld_ReturnsCorrectString()
        {
            Assert.Equal("Hello World!", Warmup.HelloWorld());
        }

        // Verifies the sum function with multiple pairs of inputs.
        [Theory]
        [InlineData(0, 10, 10)]
        [InlineData(2, 8, 10)]
        [InlineData(6, 4, 10)]
        [InlineData(5, 5, 10)]
        public void _02_Sum_CorrectlyAddsTwoNumbers(int a, int b, int expected)
        {
            Assert.Equal(expected, Warmup.sum(a, b));
        }

        // Tests the product function with different inputs.
        [Theory]
        [InlineData(1, 100, 100)]
        [InlineData(2, 50, 100)]
        [InlineData(4, 25, 100)]
        [InlineData(5, 20, 100)]
        public void _03_Product_CorrectlyMultipliesTwoNumbers(int a, int b, int expected)
        {
            Assert.Equal(expected, Warmup.product(a, b));
        }

        // Verifies the square function against known squares.
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 4)]
        [InlineData(4, 16)]
        [InlineData(5, 25)]
        public void _04_Square_ReturnsCorrectSquareOfNumber(int number, int expectedSquare)
        {
            Assert.Equal(expectedSquare, Warmup.square(number));
        }

        // Tests the cube function with known cubes.
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 8)]
        [InlineData(3, 27)]
        [InlineData(4, 64)]
        public void _05_Cube_ReturnsCorrectCubeOfNumber(int number, int expectedCube)
        {
            Assert.Equal(expectedCube, Warmup.cube(number));
        }

        // Verifies isPerfectSquare with both perfect squares and non-squares.
        [Theory]
        [InlineData(1, true)]
        [InlineData(4, true)]
        [InlineData(16, true)]
        [InlineData(25, true)]
        [InlineData(2, false)]
        [InlineData(-25, false)]
        public void _08_IsPerfectSquare_CorrectlyIdentifiesPerfectSquares(int number, bool expectedResult)
        {
            Assert.Equal(expectedResult, Warmup.isPerfectSquare(number));
        }

        // Tests quotient calculation with various dividends and divisors.
        [Theory]
        [InlineData(101, 50, 2)]
        [InlineData(102, 25, 4)]
        [InlineData(103, 20, 5)]
        [InlineData(104, 10, 10)]
        public void _06_Quotient_CorrectlyCalculatesQuotient(int dividend, int divisor, int expectedQuotient)
        {
            Assert.Equal(expectedQuotient, Warmup.quotient(dividend, divisor));
        }

        // Verifies the remainder function with multiple test cases.
        [Theory]
        [InlineData(101, 50, 1)]
        [InlineData(102, 25, 2)]
        [InlineData(103, 20, 3)]
        [InlineData(104, 10, 4)]
        public void _07_Remainder_CorrectlyCalculatesRemainder(int dividend, int divisor, int expectedRemainder)
        {
            Assert.Equal(expectedRemainder, Warmup.remainder(dividend, divisor));
        }

        [Fact]
        public void _09_SquareAll_ReturnsSquaredValuesOfList()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };
            var expectedResult = new List<int> { 1, 4, 9, 16, 25 };
            var result = Warmup.squareAll(numbers);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void _10_CubeAll_ReturnsCubedValuesOfList()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };
            var expectedResult = new List<int> { 1, 8, 27, 64, 125 };
            var result = Warmup.cubeAll(numbers);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void _11_SumAll_ReturnsSumOfAllNumbersInList()
        {
            var numbers = new List<int> { 1, 9, 2, 8, 3, 7, 4, 6, 5, 5, 50 };
            var expectedResult = 100;
            var result = Warmup.sumAll(numbers);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void _12_ReverseList_ReturnsReversedOrderOfElements()
        {
            // Arrange
            var inputList = new List<int> { 3, 1, 9, 1, 2, 1, 5, 1 };
            var expectedList = new List<int> { 1, 5, 1, 2, 1, 9, 1, 3 };

            // Act
            var result = Warmup.reverse(inputList);

            // Assert
            Assert.Equal(expectedList, result);
        }

        [Theory]
        [InlineData(0, 9999, 10000)]
        [InlineData(10000, 10255, 256)]
        public void _13_CountFrom_GeneratesCorrectSequence(int start, int expectedMax, int expectedCount)
        {
            // Act
            var result = Warmup.countFrom(start).Take(expectedCount);

            // Assert
            Assert.Equal(expectedCount, result.Count());
            Assert.Equal(expectedMax, result.Max());
        }

        [Theory]
        [InlineData(0, 99980001, 10000)]
        [InlineData(10000, 110229001, 500)]
        public void _14_SquaresFrom_GeneratesCorrectSequenceOfSquares(int start, int expectedMaxSquare, int count)
        {
            // Act
            var result = Warmup.squaresFrom(start).Take(count);

            // Assert
            Assert.Equal(count, result.Count());
            Assert.Equal(expectedMaxSquare, result.Max());
        }

        [Fact]
        public void _15_ProductOfStreams_ReturnsCorrectProductSequence()
        {
            // Arrange
            var source1 = Warmup.countFrom(0).Take(100);
            var source2 = Warmup.countFrom(10).Take(100);

            // Act
            var result = Warmup.productOfStreams(source1, source2).ToList();

            // Assert
            Assert.Equal(0, result.First()); // First element check
            Assert.Equal(10791, result.Last()); // Last element check
            Assert.Equal(100, result.Count); // Count check
        }

        [Fact]
        public void _16_AllFib_GeneratesCorrectFibonacciSequence()
        {
            // Arrange
            var expectedSequence = "0,1,1,2,3,5,8,13,21,34,55,89,144,233,377,610,987,1597,2584,4181";

            // Act
            var result = string.Join(",", CodeEval1.allFib(0, 1).Take(20));

            // Assert
            Assert.Equal(expectedSequence, result);
        }

        [Theory]
        [InlineData(3, "0,1,1")]
        [InlineData(6, "0,1,1,2,3,5")]
        [InlineData(9, "0,1,1,2,3,5,8,13,21")]
        public void _17_FirstNFibonacciNumbers_GeneratesCorrectSequence(int n, string expectedSequence)
        {
            // Arrange
            var expected = expectedSequence.Split(',').Select(int.Parse);

            // Act
            var result = CodeEval1.firstNFibonacciNumbers(n);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, true)]
        [InlineData(1, true)]
        [InlineData(4, false)]
        [InlineData(8, true)]
        public void _18_IsFibNumber_IdentifiesFibonacciNumbersCorrectly(int n, bool expected)
        {
            // Act
            var result = CodeEval1.isFibNumber(n);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, 10, 20)]
        [InlineData(10, 20, 13)]
        [InlineData(30, 100, 178)]
        public void _19_SumSomeFib_SumsFibonacciNumbersWithinRangeCorrectly(int lower, int upper, int expectedSum)
        {
            // Act
            var result = CodeEval1.sumSomeFib(lower, upper);

            // Assert
            Assert.Equal(expectedSum, result);
        }

        [Fact]
        public void _20_ParallelSum_CalculatesSumOfRangeCorrectly()
        {
            // Arrange
            var source = Enumerable.Range(10, 10000);
            var expected = 50095000;

            // Act
            var result = CodeEval1.parallelSum(source);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void _22_IsTextInStream_FindsSubstringAcrossChunksCorrectly()
        {
            // Arrange
            var text = "This is a test string to validate the IsTextInStream method.";
            var chunkSize = 10;

            // Act & Assert
            Assert.True(CodeEval1.isTextInStream(StringToStream(text, chunkSize), "validate the IsTextIn"));
            Assert.False(CodeEval1.isTextInStream(StringToStream(text, chunkSize), "nonexistent substring"));
        }

        [Fact]
        public void _21_KeepFirstNegNumber_FiltersSequenceCorrectly()
        {
            // Arrange
            var inputSequence = new List<int> { 5, 2, -3, -4, 9, 10, -11 };
            var expectedSequence = new List<int> { 5, 2, -3, 9, 10 };

            // Act
            var result = CodeEval1.FilterOutNegativeExceptFirst(inputSequence);

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
        [InlineData(524288)]    // ~0.5 MB
        [InlineData(5242880)]   // ~5 MB
        [InlineData(52428800)]  // ~50 MB
        public void IsTextInStream_FindsSubstringAcrossChunksCorrectly_WithMemoryChecks(int totalLength)
        {
            memoryUsageCheckpoints.Clear();
            var chunkSize = 10240; // 10 KB chunks
            var pattern = "validate the IsTextIn";
            var checkpointSize = 10240; // 100 KB checkpoints

            var sw = Stopwatch.StartNew();

            var textStream = GenerateTextStreamWithMemoryCheckpoints(
                totalLength, chunkSize, checkpointSize, pattern, Random.Shared.Next(10, totalLength/chunkSize),
                (long ofX) =>
                {

                    memoryUsageCheckpoints.Add(new(ofX, GetCurrentMemoryUsage(), sw.ElapsedMilliseconds));
                    
                });

            // Act
            var found = CodeEval1.isTextInStream(textStream, pattern);
            sw.Stop();
            var bigO = new BigOEstimator(output);
            var bigOMemory = bigO.EstimateComplexityMemory(memoryUsageCheckpoints);
            var bigOMemoryMatch = bigOMemory.MinBy(x=>x.Value);
            var bigOTime = bigO.EstimateComplexityTime(memoryUsageCheckpoints);
            var bigOTimeMatch = bigOTime.MinBy(x=>x.Value);

            // Assert
            Assert.True(found, "The pattern should be found in the generated text stream.");

            bigOMemory.ToDisplayString();
            // Log the results
            output.WriteLine($"Est Memory Complexity: {bigOMemoryMatch.Key}");
            output.WriteLine($"Est Time Complexity: {bigOTimeMatch.Key}");
            output.WriteLine($"Maximum memory usage during test: {memoryUsageCheckpoints.Max(x => x.MemoryUsed)} bytes");
            output.WriteLine($"Time taken: {sw.ElapsedMilliseconds} ms");
            output.WriteLine($"Memory Complexity ranking: {bigOMemory.ToDisplayString()}");
            output.WriteLine($"Time Complexity ranking: {bigOTime.ToDisplayString()}");
            

            
            memoryUsageCheckpoints.Clear();
        }


        public static IEnumerable<string> GenerateTextStreamWithMemoryCheckpoints(
            int totalLength, int chunkSize, int checkpointSize, string pattern, int patternInsertionChunkIndex = 2, 
            Action<long> memoryCheckpointAction = null)
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
            int chunkIndex = 0;

            while (totalProduced < totalLength)
            {
                var currentChunkSize = Math.Min(chunkSize, totalLength - totalProduced);
                var chunk = new char[currentChunkSize];
                var effectiveChunkSize = currentChunkSize; // Adjusted for pattern insertion

                // Generate the chunk content
                for (int i = 0; i < effectiveChunkSize; i++)
                {
                    chunk[i] = alphabet[(totalProduced + i) % alphabet.Length];
                }

                // Insert the pattern at the middle of the specified chunk
                if (chunkIndex == patternInsertionChunkIndex)
                {
                    var midPoint = effectiveChunkSize / 2;
                    var spaceForPattern = Math.Min(patternLength, effectiveChunkSize - midPoint);
                    Array.Copy(chunk, midPoint, chunk, midPoint + spaceForPattern, effectiveChunkSize - midPoint - spaceForPattern);
                    Array.Copy(pattern.ToCharArray(), 0, chunk, midPoint, spaceForPattern);
                }

                var chunkString = new string(chunk);
                // Memory checkpoint logic
                if ((totalProduced - currentCheckpoint) >= checkpointSize)
                {
                    currentCheckpoint = totalProduced;
                    memoryCheckpointAction?.Invoke(currentCheckpoint);
                }
                yield return chunkString;
                totalProduced += chunk.Length;
                chunkIndex++;

                // Memory checkpoint logic
                if ((totalProduced - currentCheckpoint) >= checkpointSize)
                {
                    currentCheckpoint = totalProduced;
                    memoryCheckpointAction?.Invoke(currentCheckpoint);
                }
            }
        }




        private long GetCurrentMemoryUsage()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
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
            var ranking = estimator.EstimateComplexityMemory(data);
            output.WriteLine(ranking.ToDisplayString());
            Assert.Equal("O(n)", ranking.First().Key);
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
            var ranking = estimator.EstimateComplexityMemory(data);
            output.WriteLine(ranking.ToDisplayString());
            Assert.Equal("O(log n)", ranking.First().Key);

            // Assert the closest match is logarithmic
        }

        [Fact]
        public void EstimateComplexity_ShouldIdentifyO1()
        {
            var data = new List<BigOEstimator.ProcessingMetric>
            {
                new (10, (long)17433, 0),
                new (100, (long)17432, 0),
                new (1000, (long)17433, 0),
                new (10000, (long)17432, 0),
                new (100000, (long)17433, 0)
            };

            var estimator = new BigOEstimator(output);
            var ranking = estimator.EstimateComplexityMemory(data);
            output.WriteLine(ranking.ToDisplayString());
            Assert.Equal("O(1)", ranking.First().Key);

            // Assert the closest match is N Log N
        }

    }
}