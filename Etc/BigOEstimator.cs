using Xunit.Abstractions;

namespace testproject;

using System;
using System.Collections.Generic;
using System.Linq;
public class BigOEstimator
    {
        private readonly ITestOutputHelper _output;

        public BigOEstimator(ITestOutputHelper output)
        {
            _output = output;
        }

        public struct ProcessingMetric(double textProcessed, double memoryUsed, double time)
        {
            public double TextProcessed = textProcessed;
            public double MemoryUsed = memoryUsed;
            public double Time = time;
        }
        
        // Overload for memory usage analysis
        public string EstimateComplexityMemory(List<ProcessingMetric> empiricalData)
        {
            return EstimateComplexityCore(empiricalData.Select(d => (d.TextProcessed, (double)d.MemoryUsed)).ToList(), "MemoryUsed");
        }

        // Overload for time analysis
        public string EstimateComplexityTime(List<ProcessingMetric> empiricalData)
        {
            return EstimateComplexityCore(empiricalData.Select(d => (d.TextProcessed, (double)d.Time)).ToList(), "Time");
        }

        private string EstimateComplexityCore(List<(double TextProcessed, double MetricValue)> empiricalData, string metricName)
        {
            // Example input sizes
            var inputSizes = empiricalData.Select(d => d.TextProcessed).ToArray();

            // Dictionary to store the differences for each complexity
            Dictionary<string, double> complexityDifferences = new Dictionary<string, double>();

            // Theoretical outcomes generators for different complexities
            var complexityFunctions = new Dictionary<string, Func<double, double>>
            {
                ["O(n)"] = n => n,
                ["O(n^2)"] = n => Math.Pow(n, 2),
                ["O(n^3)"] = n => Math.Pow(n, 3),
                ["O(2^n)"] = n => Math.Pow(2, n),
                ["O(log n)"] = n => Math.Log(n),
                ["O(log n^2)"] = n => Math.Log(Math.Pow(n, 2)),
                ["O(n log n^2)"] = n => n * Math.Log(Math.Pow(n, 2)),
                ["O(n log n)"] = n => n * Math.Log(n),
                ["O(2^n)"] = n => Math.Pow(2, n),
                // Add more complexities here as needed
            };

            // Using the selected metric for comparison
            var empirical = empiricalData.Select(d => d.MetricValue).ToArray();

            // Loop through each complexity case
            foreach (var complexity in complexityFunctions)
            {
                var theoretical = inputSizes.Select(complexity.Value).ToArray();
                var diff = CalculateDifference(empirical, theoretical);
                complexityDifferences.Add(complexity.Key, diff);
            }

            // Infer the closest Big O notation by finding the minimum difference
            var bestFit = complexityDifferences.OrderBy(x => x.Value).First();
        
            // Outputting all differences for review
            // foreach (var complexityDiff in complexityDifferences)
            // {
            //     _output.WriteLine($"{metricName} - {complexityDiff.Key}: {complexityDiff.Value}");
            // }

            // Indicate the best matching complexity
            //_output.WriteLine($"Best matching complexity for {metricName}: {bestFit.Key} with difference: {bestFit.Value}");
            return bestFit.Key;
        }

        private double CalculateDifference(double[] empirical, double[] theoretical)
        {
            if (empirical.Length != theoretical.Length)
            {
                throw new ArgumentException("Empirical and theoretical arrays must be of the same length.");
            }

            return empirical.Zip(theoretical, (e, t) => Math.Pow(e - t, 2)).Sum();
        }
    }