using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Text;

namespace Algorithms.Benchmarks;

public class ArraySorts
{
    public int[] Array { get; set; } = null!;

    [Params(6, 600, 60000)]
    public int Length { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        Random random = new Random(500);
        Array = new int[Length];
        for (int i = 0; i < Length; i++)
        {
            Array[i] = random.Next();
        }
    }

    [Benchmark]
    public int[] BubbleSort() => Array.BubbleSort();
    [Benchmark]
    public int[] InsertionSort() => Array.InsertionSort();
    [Benchmark]
    public int[] SelectionSort() => Array.SelectionSort();
    [Benchmark]
    public int[] QuickSort() => Array.QuickSort();
    [Benchmark]
    public int[] MergeSort() => Array.MergeSort();
    [Benchmark]
    public int[] HeapSort() => Array.HeapSort();
    [Benchmark]
    public int[] LinqSort() => Array.Order().ToArray();
}