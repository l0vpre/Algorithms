using Xunit.Sdk;

namespace Algorithms.Tests;

public static class ArraySorts
{
    static int[] _array;
    static int[] _sortedLinq;
    static int[] _sortedRangeLinq;
    public static IEnumerable<object[]> SortData { get; set; } = null!;
    public static IEnumerable<object[]> SortRangeData { get; set; } = null!;
    
    public static Func<int[], int[]> BubbleSortFunc => (int[] a) => a.BubbleSort();
    public static Func<int[], int[]> InsertionSortFunc => (int[] a) => a.InsertionSort();
    public static Func<int[], int[]> SelectionSortFunc => (int[] a) => a.SelectionSort();
    public static Func<int[], int[]> QuickSortFunc => (int[] a) => a.QuickSort();
    public static Func<int[], int[]> MergeSortFunc => (int[] a) => a.MergeSort();
    public static Func<int[], int[]> HeapSortFunc => (int[] a) => a.HeapSort();

    public static Func<int[], int, int, int[]> BubbleSortRangeFunc =>
       (int[] a, int start, int count) => a.BubbleSort(start, count);
    public static Func<int[], int, int, int[]> InsertionSortRangeFunc =>
       (int[] a, int start, int count) => a.InsertionSort(start, count);
    public static Func<int[], int, int, int[]> SelectionSortRangeFunc =>
       (int[] a, int start, int count) => a.SelectionSort(start, count);
    public static Func<int[], int, int, int[]> QuickSortRangeFunc =>
     (int[] a, int start, int count) => a.QuickSort(start, count);
    public static Func<int[], int, int, int[]> MergeSortRangeFunc =>
       (int[] a, int start, int count) => a.MergeSort(start, count);
    public static Func<int[], int, int, int[]> HeapSortRangeFunc =>
       (int[] a, int start, int count) => a.HeapSort(start, count);

    static ArraySorts()
    {
        _array = new int[3000];
        Random randNum = new Random(1000);
        for (int i = 0; i < _array.Length; i++)
        {
            _array[i] = randNum.Next(-1000, 1000);

        }
        int start = _array.Length / 3;
        int count = _array.Length / 3;
        _sortedLinq = _array.Order().ToArray();
        _sortedRangeLinq = OrderRange(_array, start, count).ToArray();

        SortData = new object[][]{
                new object[]{BubbleSortFunc,},
                new object[]{InsertionSortFunc,},
                new object[]{SelectionSortFunc,},
                new object[]{QuickSortFunc,},
                new object[]{MergeSortFunc,},
                new object[]{HeapSortFunc,},
        };

        SortRangeData = new object[][]{
            new object[]{BubbleSortRangeFunc,start,count,},
            new object[]{InsertionSortRangeFunc,start,count,},
            new object[]{SelectionSortRangeFunc,start,count,},
            new object[]{QuickSortRangeFunc,start,count,},
            new object[]{MergeSortRangeFunc,start,count,},
            new object[]{HeapSortRangeFunc,start,count,},
        };
    }

    private static IEnumerable<T> OrderRange<T>(IEnumerable<T> arr, int start, int count)
    {
        var left = arr.Take(start);
        var ordered = arr.Skip(start).Take(count).Order();
        var right = arr.Skip(start + count);
        return left.Concat(ordered).Concat(right);
    }

    [Theory]
    [MemberData(nameof(SortData))]
    public static void Sort(Func<int[], int[]> sort)
    {
        int[] array = sort(_array);
        Assert.Equal(_sortedLinq, array);

    }

    [Theory]
    [MemberData(nameof(SortRangeData))]
    public static void SortRange(Func<int[], int, int, int[]> sort, int start, int count)
    {
        int[] array = sort(_array, start, count);
        Assert.Equal(_sortedRangeLinq, array);

    }

};

