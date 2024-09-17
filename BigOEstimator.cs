using System.Text;
using Xunit.Abstractions;

namespace testproject;

using System;
using System.Collections.Generic;
using System.Linq;

public static class Ext
{
    public static string ToDisplayString<K,V>(this Dictionary<K, V> str)
    {
        var sb = new StringBuilder();
        sb.AppendLine();
        sb.AppendLine("----------");
        foreach (var entry in str.OrderBy(kv=>kv.Value))
        {
            sb.AppendLine($"\t{entry.Key}: {entry.Value}");
        }
        sb.AppendLine("----------");
        return sb.ToString();
    }
}
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
        public Dictionary<string, double> EstimateComplexityMemory(List<ProcessingMetric> empiricalData)
        {
            return EstimateComplexityCore(empiricalData.Select(d => (d.TextProcessed, (double)d.MemoryUsed)).ToList(), "MemoryUsed");
        }

        // Overload for time analysis
        public Dictionary<string, double> EstimateComplexityTime(List<ProcessingMetric> empiricalData)
        {
            return EstimateComplexityCore(empiricalData.Select(d => (d.TextProcessed, (double)d.Time)).ToList(), "Time");
        }

        private Dictionary<string, double> EstimateComplexityCore(List<(double TextProcessed, double MetricValue)> empiricalData, string metricName)
        {
            // Example input sizes
            var inputSizes = empiricalData.Select(d => d.TextProcessed).ToArray();
            var empirical = empiricalData.Select(d => d.MetricValue).ToArray();

            // Dictionary to store the differences for each complexity
            Dictionary<string, double> complexityDifferences = new Dictionary<string, double>();

            // Theoretical outcomes generators for different complexities
            var complexityFunctions = new Dictionary<string, Func<double, double>>
            {
                ["O(1)"] = n => 1,
                ["O(log n)"] = n => Math.Log(n),
                ["O(n)"] = n => n,
                ["O(n log n)"] = n => n * Math.Log(n),
                ["O(2^n)"] = n => Math.Pow(2, n),
                ["O(n^2)"] = n => Math.Pow(n, 2),
                ["O(n^3)"] = n => Math.Pow(n, 3),
                ["O(log n^2)"] = n => Math.Log(Math.Pow(n, 2)),
                ["O(n log n^2)"] = n => n * Math.Log(Math.Pow(n, 2)),
                ["O(2^n)"] = n => Math.Pow(2, n),
                // Add more complexities here as needed
            };

            // Normalize data
            var minEmpirical = empirical.Min();
            var maxEmpirical = empirical.Max();
            var normalizedEmpirical = empirical.Select(e => (e - minEmpirical) / (maxEmpirical - minEmpirical)).ToArray();

            foreach (var complexity in complexityFunctions)
            {
                var theoretical = inputSizes.Select(complexity.Value).ToArray();
                var diff = CalculateDifference(normalizedEmpirical, theoretical);
                complexityDifferences.Add(complexity.Key, Double.IsNaN(diff) ? Double.MaxValue : diff );
            }


            return new Dictionary<string, double>(complexityDifferences
                .Where(x=>Double.IsNormal(x.Value))
                .Where(x=>x.Value>0)
            );
        }

        private double CalculateDifference(double[] empirical, double[] theoretical)
        {
            if (empirical.Length != theoretical.Length)
            {
                throw new ArgumentException("Empirical and theoretical arrays must be of the same length.");
            }

            // Step 1: Normalize the empirical data to [0, 1]
            double empiricalMin = empirical.Min();
            double empiricalMax = empirical.Max();
            double empiricalRange = empiricalMax - empiricalMin;

            // Handle the case where all empirical values are the same
            if (empiricalRange == 0)
            {
                empiricalRange = 1; // Prevent division by zero
            }

            var normalizedEmpirical = empirical.Select(e => (e - empiricalMin) / empiricalRange + 1).ToArray();

            // Step 2: Rescale normalized empirical data to match theoretical data at the first data point
            double scalingFactor;
            if (normalizedEmpirical[0] == 0)
            {
                if (theoretical[0] == 0)
                {
                    scalingFactor = 1; // Both are zero, set scaling factor to 1
                }
                else
                {
                    return double.PositiveInfinity; // Cannot compute scaling factor, set difference to infinity
                }
            }
            else
            {
                scalingFactor = theoretical[0] / normalizedEmpirical[0];
            }

            var rescaledEmpirical = normalizedEmpirical.Select(e => e * scalingFactor).ToArray();

            // Calculate the average of squared differences
            var diff = rescaledEmpirical.Zip(theoretical, (e, t) => e - t).ToList();
            return diff.Average() * -1;
        }
        // Helper method to calculate standard deviation
        private double StandardDeviation(double[] data)
        {
            double mean = data.Average();
            double sumOfSquares = data.Sum(d => Math.Pow(d - mean, 2));
            return Math.Sqrt(sumOfSquares / data.Length);
        }
        
        private double PearsonCorrelation(double[] x, double[] y)
        {
            double xMean = x.Average();
            double yMean = y.Average();

            double numerator = x.Zip(y, (xi, yi) => (xi - xMean) * (yi - yMean)).Sum();
            double denominator = Math.Sqrt(x.Sum(xi => Math.Pow(xi - xMean, 2)) * y.Sum(yi => Math.Pow(yi - yMean, 2)));

            if (denominator == 0)
                return 0;

            return numerator / denominator;
        }

    }