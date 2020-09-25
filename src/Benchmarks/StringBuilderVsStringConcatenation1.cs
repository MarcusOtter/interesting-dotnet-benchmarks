using System;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace Benchmarks
{
    [MemoryDiagnoser]
    public class StringBuilderVsStringConcatenation1
    {
        [Params(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 100)]
        public int AmountOfConcatenations;

        private readonly string _initialString = Guid.NewGuid().ToString();
        private string[] _stringsToConcat = new string[0];

        [GlobalSetup]
        public void Setup()
        {
            _stringsToConcat = new string[AmountOfConcatenations - 1];
            for (var i = 0; i < _stringsToConcat.Length - 1; i++)
            {
                _stringsToConcat[i] = Guid.NewGuid().ToString();
            }
        }

        [Benchmark]
        public string StringConcatenation()
        {
            var output = _initialString;
            foreach (var str in _stringsToConcat)
            {
                output += str;
            }

            return output;
        }

        [Benchmark]
        public string StringBuilder()
        {
            var stringBuilder = new StringBuilder(_initialString);
            foreach (var str in _stringsToConcat)
            {
                stringBuilder.Append(str);
            }

            return stringBuilder.ToString();
        }
    }
}
