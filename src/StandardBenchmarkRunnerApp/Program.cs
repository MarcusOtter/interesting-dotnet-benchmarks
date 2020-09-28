using Benchmarks.Running;

namespace StandardBenchmarkRunnerApp
{
    internal class Program
    {
        // To run benchmarks:
        //     1. Set the build configuration to "Release"
        //     2. Build the solution (default Visual Studio shortcut is CTRL + SHIFT + B)
        //     3. Run src/StandardBenchmarkRunnerApp/bin/Release/netcoreapp3.1/StandardBenchmarkRunnerApp.exe
        //     4. Follow the instructions in the terminal to select which benchmarks to run

        private static void Main(string[] args) 
            => InterestingDotnetBenchmarksRunner.RunBenchmarks(args);
    }
}
