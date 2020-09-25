using Benchmarks;

namespace ConsoleApplication
{
    internal class Program
    {
        // To run benchmarks:
        // 1. Set the build configuration to "Release"
        // 2. Select which benchmark classes to run below with .AddBenchmarkClass<BenchmarkClassName>();
        // 3. Start without debugging (CTRL + F5)
        //   OR
        // 3. Build the solution and run the output .exe (/src/ConsoleApplication/bin/Release/netcoreapp3.1/ConsoleApplication.exe)

        private static void Main()
        {
            var runner = new Runner()
                .AddBenchmarkClass<StringBuilderVsStringConcatenation1>()
                .AddBenchmarkClass<StringBuilderVsStringConcatenation2>();


            runner.RunBenchmarks();
        }
    }
}
