using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Text;

namespace Algorithms.Benchmarks;

class Program
{
    public static void Main(string[] args)
    {
        BenchmarkRunner.Run<ArraySorts>();
    }
}