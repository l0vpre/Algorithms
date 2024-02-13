using Algorithms;
using Algorithms.Collections;

VList<int> list = new();

var newList = list.Select(n => n * n).ToList();
for (int i = 0; i < 20; i++)
{
    list.Add(i + 1);
}
list.Add(6652);
System.Console.WriteLine($"{list.IndexOf(14)}  {list.Remove(6652)}");
System.Console.WriteLine(string.Join(" ", list));