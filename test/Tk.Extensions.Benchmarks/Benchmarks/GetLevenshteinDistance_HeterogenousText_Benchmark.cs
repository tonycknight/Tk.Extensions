﻿using BenchmarkDotNet.Attributes;

namespace Tk.Extensions.Benchmarks.Benchmarks
{
    [MemoryDiagnoser]
    [RankColumn, MinColumn, MaxColumn, Q1Column, Q3Column, AllStatisticsColumn]
    [JsonExporterAttribute.Full]
    [GcServer(true)]
    public class GetLevenshteinDistance_HeterogenousText_Benchmark
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
        public void GetLevenshteinDistance_IgnoreCase()
        {
            var result = Value.GetLevenshteinDistance(Comparand, true);
        }

        [Benchmark]
        public void GetDamerauLevenshteinDistance()
        {
            var result = Value.GetDamerauLevenshteinDistance(Comparand);
        }

        [Benchmark]
        public void GetDamerauLevenshteinDistance_IgnoreCase()
        {
            var result = Value.GetDamerauLevenshteinDistance(Comparand, true);
        }
    }
}
