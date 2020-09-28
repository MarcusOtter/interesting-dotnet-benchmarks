using Benchmarks.Running;

namespace ThoroughBenchmarkRunnerApp
{
    internal class Program
    {
        // For instructions on how to run, see Program.cs in StandardBenchmarkRunnerApp
        // This application will run the benchmarks on both .NET Core 3.1, .NET Core 2.1 and .NET Framework 4.8.
        // To only run on .NET Core 3.1, build StandardBenchmarkRunnerApp instead.

        private static void Main(string[] args)
            => InterestingDotnetBenchmarksRunner.RunBenchmarks(args, runAllMonikers: true);
    }
}
