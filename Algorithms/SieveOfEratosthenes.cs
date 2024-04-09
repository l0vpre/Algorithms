using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms;

class Sieve
{
    bool[] arr;
    public Sieve()
    {
        arr = new bool[16];
        FillSieve();
    }

    public bool IsPrime(long num)
    {
        if (num >= arr.Length)
            Expand(num);

        return arr[num];
    }

    private void Expand(long size)
    {
        long capacity = arr.Length;
        while (capacity <= size)
        {
            capacity += capacity;
        }

        arr = new bool[capacity];
        FillSieve();
    }

    public long CountPrimes(long from, long to)
    {
        long count = 0;
        if (to >= arr.Length)
            Expand(to);

        for (long i = from; i < to; i++)
        {
            if (arr[i])
                count++;

        }
        return count;
    }

    private void FillSieve()
    {
        int sqrtNum = (int)Math.Sqrt(arr.Length);
        Array.Fill(arr, true);
        arr[0] = false;
        arr[1] = false;

        for (long i = 2; i <= sqrtNum; i++)
        {
            if (!arr[i])
                continue;

            if (arr[i])
            {
                for (long k = i * 2; k < arr.Length; k += i)
                {
                    arr[k] = false;
                }
            }
        }
    }
}
