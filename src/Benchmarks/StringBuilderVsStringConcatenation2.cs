using System;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace Benchmarks
{
    public class StringBuilderVsStringConcatenation2
    {
        [Params(1, 10, 100)]
        public int AmountOfConcatenations;

        [Params(1, 5, 10, 15, 30)]
        public int StringLength;

        private string _initialString = "";
        private string[] _stringsToConcat = new string[0];

        [GlobalSetup]
        public void Setup()
        {
            _initialString = Guid.NewGuid().ToString().Substring(0, StringLength);

            _stringsToConcat = new string[AmountOfConcatenations - 1];
            for (var i = 0; i < _stringsToConcat.Length - 1; i++)
            {
                _stringsToConcat[i] = Guid.NewGuid().ToString().Substring(0, StringLength);
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
