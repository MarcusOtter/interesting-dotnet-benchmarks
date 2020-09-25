using System;
using System.Collections.Generic;
using BenchmarkDotNet.Running;

namespace Benchmarks
{
    public interface IRunner
    {
        Runner AddBenchmarkClass<T>() where T : class;

        /// <summary>
        /// Runs the benchmarks that have been added with <see cref="AddBenchmarkClass{T}"/>.
        /// </summary>
        void RunBenchmarks();
    }

    public class Runner : IRunner
    {
        private readonly List<Type> _classesToBenchmark;

        public Runner()
        {
            _classesToBenchmark = new List<Type>(2);
        }

        public Runner AddBenchmarkClass<T>() where T : class
        {
            _classesToBenchmark.Add(typeof(T));
            return this;
        }

        public void RunBenchmarks()
        {
            foreach (var benchmarkClass in _classesToBenchmark)
            {
                BenchmarkRunner.Run(benchmarkClass);
            }
        }
    }
}
