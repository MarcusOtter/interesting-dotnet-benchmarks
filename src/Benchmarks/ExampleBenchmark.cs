using System;
using BenchmarkDotNet.Attributes;

namespace Benchmarks
{
    public class ExampleBenchmark
    {
        [Benchmark(Description = "Custom name")]
        public string Example()
        {
            return Guid.NewGuid().ToString() + Guid.NewGuid().ToString();
        }
    }
}
