using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using HyperEnum;

namespace Benchmarks
{
    public class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<EnumGetNameBenchmark>();
        }

        [MemoryDiagnoser()]
        public class EnumGetNameBenchmark
        {
            [Benchmark]
            public void NormalToString()
            {
                var _ = HumanStates.Idle.GetName();
            }

            [Benchmark]
            public void HyperEnumAsString()
            {
                var _ = HumanStates.Idle.GetName();
            }
        }
    }
}