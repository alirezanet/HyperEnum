using System;
using BenchmarkDotNet.Attributes;
using HyperEnum;

namespace Benchmarks
{
    [MemoryDiagnoser()]
    public class EnumGetNameBenchmark
    {
        [Benchmark]
        public void NormalToString() => HumanStates.Idle.ToString();

        [Benchmark]
        public void EnumGetName() => Enum.GetName(typeof(HumanStates), HumanStates.Idle);

        [Benchmark]
        public void HyperEnumGetName() => HumanStates.Idle.GetName();
    }
}