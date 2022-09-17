using BenchmarkDotNet.Attributes;

namespace Tk.Extensions.Benchmarks.Benchmarks
{
    [MemoryDiagnoser]
    [RankColumn, MinColumn, MaxColumn, Q1Column, Q3Column, AllStatisticsColumn]
    [JsonExporterAttribute.Full]
    [GcServer(true)]
    public class LevenshteinDistance_HeterogenousText_Benchmark
    {
        private string Value = null!;
        private string Comparand = null!;

        [Params(1, 10, 100, 1000)]
        public int Size { get; set; }

        [IterationSetup]
        public void IterationSetup()
        {            
            Value = "ab".Repeat(Size);
            Comparand = "ba".Repeat(Size);
        }

        [Benchmark]
        public void LevenshteinDistance()
        {
            var result = Value.LevenshteinDistance(Comparand);
        }
    }
}
