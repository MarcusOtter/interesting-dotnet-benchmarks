using Benchmarks.Running;

namespace ConsoleApplication
{
    internal class Program
    {
        // To run benchmarks:
        //     1. Set the build configuration to "Release"
        //     2. If you are running benchmarks for a new article, set `runAllMonikers` to `true` below.
        //     3. Build the solution (default Visual Studio shortcut is CTRL + SHIFT + B)
        //     4. Run src/ConsoleApplication/bin/Release/netcoreapp3.1/ConsoleApplication.exe
        //     5. Follow the instructions in the terminal to select which benchmarks to run
        
        private static void Main(string[] args) 
            => InterestingDotnetBenchmarksRunner.RunBenchmarks(args, runAllMonikers: false);
    }
}
