using System.Linq;
using BenchmarkDotNet.Running;

namespace Benchmarks
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<HyperEnumGetNameBenchmark>();
            // BenchmarkRunner.Run<HyperEnumGetNamesBenchmark>();
        }
     
    }
}