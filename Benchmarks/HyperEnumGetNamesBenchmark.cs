using System;
using BenchmarkDotNet.Attributes;
using HyperEnum;

namespace Benchmarks
{
    [MemoryDiagnoser()]
    public class HyperEnumGetNamesBenchmark
    {
        [Benchmark]
        public void EnumGetNames() => Enum.GetNames<HumanStates>();
        [Benchmark]
        public void HyperEnumGetNames() => HyperEnumHelper.GetHumanStatesNames();
    }
}