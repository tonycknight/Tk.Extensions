using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using Newtonsoft.Json.Linq;
using Tk.Extensions.Linq;

namespace Tk.Extensions.Benchmarks.Benchmarks
{
    [MemoryDiagnoser]
    [RankColumn, MinColumn, MaxColumn, Q1Column, Q3Column, AllStatisticsColumn]
    [JsonExporterAttribute.Full]
    [GcServer(true)]
    public class SelectFlatBenchmark
    {
        private List<int>? _flatIntegers;

        [Params(1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096, 8192, 16384)]
        public int Size { get; set; }

        [IterationSetup]
        public void IterationSetup()
        {
            _flatIntegers = Enumerable.Range(1, Size).Select(i => Size - i).ToList();
        }

        [Benchmark]
        public void SelectFlat_RecursiveTree()
        {
            var result = _flatIntegers!.Select(x => Enumerable.Range(1, x).Count()).Count();
        }
    }
}
