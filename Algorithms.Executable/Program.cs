using Algorithms;
using Algorithms.Collections;

VList<int> list = new() { 1, 2, 3 };

var newList = list.Select(n => n * n).ToList();

foreach (var item in newList)
{
    System.Console.WriteLine(item);
}

