namespace Algorithms;

public static class ArraySortExtentions
{
    private static T[] MakeCopy<T>(this T[] array)
    {
        T[] copy = new T[array.Length];
        array.CopyTo(copy, 0);
        return copy;
    }
    public static T[] BubbleSort<T>(this T[] array)
    where T : IComparable
    {
        return array.BubbleSort(0, array.Length);

    }
    public static T[] BubbleSort<T>(this T[] array, int start, int count)
   where T : IComparable
    {
        var sorted = array.MakeCopy();
        sorted.BubbleSortInplace(start, count);
        return sorted;

    }
    private static void BubbleSortInplace<T>(this T[] array, int start, int count)
    where T : IComparable
    {
        for (int i = start; i < start + count; i++)
        {
            for (int j = start; j < start + count - 1; j++)
            {
                if (array[j].CompareTo(array[j + 1]) > 0)
                {
                    (array[j], array[j + 1]) = (array[j + 1], array[j]);
                }
            }
        }

    }
    public static T[] InsertionSort<T>(this T[] array)
    where T : IComparable
    {
        return array.InsertionSort(0, array.Length);
    }
    public static T[] InsertionSort<T>(this T[] array, int start, int count)
    where T : IComparable
    {
        var sorded = array.MakeCopy();
        sorded.InsertionSortInplace(start, count);
        return sorded;
    }
    private static void InsertionSortInplace<T>(this T[] array, int start, int count)
    where T : IComparable
    {
        for (int i = start; i < start + count; i++)
        {
            int j = i;
            while (j > start && array[j].CompareTo(array[j - 1]) < 0)
            {
                (array[j], array[j - 1]) = (array[j - 1], array[j]);
                j--;
            }
        }
    }

    public static T[] SelectionSort<T>(this T[] array)
    where T : IComparable
    {
        return array.SelectionSort(0, array.Length);
    }
    public static T[] SelectionSort<T>(this T[] array, int start, int count)
    where T : IComparable
    {
        var sorted = array.MakeCopy();
        sorted.SelectionSortInplace(start, count);
        return sorted;
    }
    private static void SelectionSortInplace<T>(this T[] array, int start, int count)
    where T : IComparable
    {
        for (int i = start; i < start + count; i++)
        {
            int minIndex = i;
            for (int j = i; j < start + count; j++)
            {
                if (array[j].CompareTo(array[minIndex]) < 0)
                {
                    minIndex = j;
                }
            }
            (array[i], array[minIndex]) = (array[minIndex], array[i]);
        }
    }

    public static T[] QuickSort<T>(this T[] array)
    where T : IComparable
    {
        return array.QuickSort(0, array.Length);
    }
    public static T[] QuickSort<T>(this T[] array, int start, int count)
    where T : IComparable
    {
        var sorted = array.MakeCopy();
        sorted.QuickSortInplace(start, count);
        return sorted;
    }
    private static void QuickSortInplace<T>(this T[] array, int start, int count)
    where T : IComparable
    {
        if (count <= 1)
        {
            return;
        }

        T pivot = array[start + count / 2];
        int pivotIndex = start;
        int currentIndex = start + 1;
        (array[start + count / 2], array[start]) = (array[start], array[start + count / 2]);

        while (currentIndex < start + count)
        {
            if (array[currentIndex].CompareTo(pivot) < 0)
            {
                pivotIndex++;
                (array[currentIndex], array[pivotIndex]) = (array[pivotIndex], array[currentIndex]);
            }
            currentIndex++;
        }

        (array[start], array[pivotIndex]) = (array[pivotIndex], array[start]);
        array.QuickSortInplace(start, pivotIndex - start);
        array.QuickSortInplace(pivotIndex + 1, start + count - pivotIndex - 1);
    }

    public static T[] MergeSort<T>(this T[] array)
    where T : IComparable
    {
        return array.MergeSort(0, array.Length);
    }
    public static T[] MergeSort<T>(this T[] array, int start, int count)
    where T : IComparable
    {
        var sorted = array.MakeCopy();
        sorted.MergeSortInplace(start, count);
        return sorted;
    }
    private static void MergeSortInplace<T>(this T[] array, int start, int count)
    where T : IComparable
    {
        if (start + count <= 1)
        {
            return;
        }
        int leftCount = count / 2;
        int rightCount = count - leftCount;
        T[] leftArray = new T[leftCount];
        T[] rightArray = new T[rightCount];
        int arrIdx = start;
        for (int leftIdx = 0; leftIdx < leftCount; leftIdx++, arrIdx++)
        {
            leftArray[leftIdx] = array[arrIdx];
        }
        for (int rightIdx = 0; rightIdx < rightCount; rightIdx++, arrIdx++)
        {
            rightArray[rightIdx] = array[arrIdx];
        }
        leftArray.MergeSortInplace(0, leftArray.Length);
        rightArray.MergeSortInplace(0, rightArray.Length);

        int rightIndex = 0;
        int leftIndex = 0;
        int arrayIndex = start;

        while (leftIndex < leftCount)
        {
            if (rightIndex < rightCount && leftArray[leftIndex].CompareTo(rightArray[rightIndex]) > 0)
            {
                array[arrayIndex] = rightArray[rightIndex];
                rightIndex++;
            }
            else
            {
                array[arrayIndex] = leftArray[leftIndex];
                leftIndex++;
            }
            arrayIndex++;
        }
        while (rightIndex < rightCount)
        {
            array[arrayIndex] = rightArray[rightIndex];
            rightIndex++;
            arrayIndex++;
        }
    }


    public static T[] HeapSort<T>(this T[] array)
    where T : IComparable
    {
        return array.HeapSort(0, array.Length);
    }
    public static T[] HeapSort<T>(this T[] array, int start, int count)
    where T : IComparable
    {
        var sorted = array.MakeCopy();
        sorted.HeapSortInplace(start, count);
        return sorted;
    }
    private static void HeapSortInplace<T>(this T[] array, int start, int count)
    where T : IComparable
    {
        for (int rootIndex = count / 2 - 1; rootIndex >= 0; rootIndex--)
        {
            array.DownHeap(rootIndex, count, start);
        }
        for (int current = count - 1; current > 0; current--)
        {
            (array[0 + start], array[current + start]) = (array[current + start], array[0 + start]);
            array.DownHeap(0, current, start);
        }
    }

    private static void DownHeap<T>(this T[] array, int rootIndex, int count, int start)
    where T : IComparable
    {
        int leftIndex = rootIndex * 2 + 1;
        int rightIndex = rootIndex * 2 + 2;
        int largestIndex = rootIndex;

        if (leftIndex < count && array[largestIndex + start].CompareTo(array[leftIndex + start]) < 0)
        {
            largestIndex = leftIndex;
        }
        if (rightIndex < count && array[largestIndex + start].CompareTo(array[rightIndex + start]) < 0)
        {
            largestIndex = rightIndex;
        }
        if (largestIndex != rootIndex)
        {
            (array[largestIndex + start], array[rootIndex + start]) = (array[rootIndex + start], array[largestIndex + start]);
            array.DownHeap(largestIndex, count, start);
        }
    }
}



