using BenchmarkDotNet.Attributes;
using Tk.Extensions.Search;

namespace Tk.Extensions.Benchmarks.Benchmarks
{
    [MemoryDiagnoser]
    [RankColumn, MinColumn, MaxColumn, Q1Column, Q3Column, AllStatisticsColumn]
    [JsonExporterAttribute.Full]
    [GcServer(true)]
    public class LevenshteinDistance_HomogenousText_Benchmark
    {
        private string Value = null!;
        private string Comparand = null!;

        [Params(1, 10, 100, 1000)]
        public int Size { get; set; }

        [IterationSetup]
        public void IterationSetup()
        {
            Value = new string('a', Size);
            Comparand = new string('a', Size);
        }

        [Benchmark]
        public void LevenshteinDistance()
        {
            var result = Value.LevenshteinDistance(Comparand);
        }
    }
}
