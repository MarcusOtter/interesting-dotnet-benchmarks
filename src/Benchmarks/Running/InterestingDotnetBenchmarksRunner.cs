using System;
using System.Reflection;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;

namespace Benchmarks.Running
{
    public static class InterestingDotnetBenchmarksRunner
    {
        public static void RunBenchmarks(string[] args, bool runAllMonikers)
        {
            var config = GetConfig(runAllMonikers);
            BenchmarkSwitcher.FromAssembly(Assembly.GetExecutingAssembly()).Run(args, config);

            WriteClosingMessage();
            Console.ReadKey();
        }

        private static IConfig GetConfig(bool runAllMonikers)
        {
            var config = ManualConfig.CreateEmpty()
                .AddDiagnoser(MemoryDiagnoser.Default)
                .AddLogger(ConsoleLogger.Default)
                .AddColumnProvider(DefaultColumnProviders.Instance)
                .AddExporter(DefaultExporters.Csv, DefaultExporters.JsonBrief, DefaultExporters.Markdown);

            return runAllMonikers
                ? config
                    //.AddJob(Job.Default.WithRuntime(CoreRuntime.Core50)) // Disabled until full release
                    .AddJob(Job.Default.WithRuntime(CoreRuntime.Core31))
                    .AddJob(Job.Default.WithRuntime(CoreRuntime.Core21))
                    .AddJob(Job.Default.WithRuntime(ClrRuntime.Net48))
                : config;
        }

        private static void WriteClosingMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Your interesting benchmarks have finished running.");
            Console.WriteLine("Make sure to open a pull request with your results! :)");
            Console.WriteLine("Press any key to terminate the program.");
        }
    }
}
