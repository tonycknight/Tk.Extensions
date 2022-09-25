using BenchmarkDotNet.Attributes;

namespace Tk.Extensions.Benchmarks.Benchmarks
{
    [MemoryDiagnoser]
    [RankColumn, MinColumn, MaxColumn, Q1Column, Q3Column, AllStatisticsColumn]
    [JsonExporterAttribute.Full]
    [GcServer(true)]
    public class GetDistance_HeterogenousText_Benchmark
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
        public void GetLevenshteinDistance()
        {
            var result = Value.GetLevenshteinDistance(Comparand);
        }

        [Benchmark]
        public void GetLevenshteinDistance_Invariant_IgnoreCase()
        {
            var result = Value.GetLevenshteinDistance(Comparand, StringComparer.InvariantCultureIgnoreCase);
        }

        [Benchmark]
        public void GetLevenshteinDistance_Ordinal()
        {
            var result = Value.GetLevenshteinDistance(Comparand, StringComparer.Ordinal);
        }

        [Benchmark]
        public void GetLevenshteinDistance_Ordinal_IgnoreCase()
        {
            var result = Value.GetLevenshteinDistance(Comparand, StringComparer.OrdinalIgnoreCase);
        }
        
        [Benchmark]
        public void GetDamareuLevenshteinDistance()
        {
            var result = Value.GetDamareuLevenshteinDistance(Comparand);
        }

        [Benchmark]
        public void GetDamareuLevenshteinDistance_Invariant_IgnoreCase()
        {
            var result = Value.GetDamareuLevenshteinDistance(Comparand, StringComparer.InvariantCultureIgnoreCase);
        }

        [Benchmark]
        public void GetDamareuLevenshteinDistance_Ordinal()
        {
            var result = Value.GetDamareuLevenshteinDistance(Comparand, StringComparer.Ordinal);
        }

        [Benchmark]
        public void GetDamareuLevenshteinDistance_Ordinal_IgnoreCase()
        {
            var result = Value.GetDamareuLevenshteinDistance(Comparand, StringComparer.OrdinalIgnoreCase);
        }
    }
}
