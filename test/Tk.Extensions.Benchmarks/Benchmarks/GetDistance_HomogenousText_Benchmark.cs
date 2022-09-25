using BenchmarkDotNet.Attributes;

namespace Tk.Extensions.Benchmarks.Benchmarks
{
    [MemoryDiagnoser]
    [RankColumn, MinColumn, MaxColumn, Q1Column, Q3Column, AllStatisticsColumn]
    [JsonExporterAttribute.Full]
    [GcServer(true)]
    public class GetDistance_HomogenousText_Benchmark
    {
        private string Value = null!;
        private string Comparand = null!;

        [Params(1, 10, 100, 1000)]
        public int Size { get; set; }

        [IterationSetup]
        public void IterationSetup()
        {
            Value = new string('a', Size);
            Comparand = new string('b', Size);
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
        public void GetDamerauLevenshteinDistance()
        {
            var result = Value.GetDamerauLevenshteinDistance(Comparand);
        }

        [Benchmark]
        public void GetDamerauLevenshteinDistance_Invariant_IgnoreCase()
        {
            var result = Value.GetDamerauLevenshteinDistance(Comparand, StringComparer.InvariantCultureIgnoreCase);
        }

        [Benchmark]
        public void GetDamerauLevenshteinDistance_Ordinal()
        {
            var result = Value.GetDamerauLevenshteinDistance(Comparand, StringComparer.Ordinal);
        }

        [Benchmark]
        public void GetDamerauLevenshteinDistance_Ordinal_IgnoreCase()
        {
            var result = Value.GetDamerauLevenshteinDistance(Comparand, StringComparer.OrdinalIgnoreCase);
        }
    }
}
