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
            public void NormalToString() => HumanStates.Idle.ToString();

            [Benchmark]
            public void HyperEnumGetName() => HumanStates.Idle.GetName();
        }
    }
}