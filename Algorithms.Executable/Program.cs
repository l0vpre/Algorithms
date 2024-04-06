using Algorithms;
using Algorithms.Collections;


VBinaryTree<int> tree =
[
    8,
    7,
    10,
    2,
    -45,
    234,
    435,
    23,
    5,
    57,
    0,
    72,
    1,
    23,
];
System.Console.WriteLine($"my: {tree.Count}  ling: {tree.Count()}");
foreach (var d in tree)
{
    System.Console.Write($"{d} ");
}
System.Console.WriteLine();
System.Console.WriteLine($"10  -{tree.Remove(10)}");
System.Console.WriteLine($"435 -{tree.Remove(435)}");
System.Console.WriteLine($"0   -{tree.Remove(0)}");
System.Console.WriteLine($"72  -{tree.Remove(72)}");
System.Console.WriteLine($"22  -{tree.Remove(22)}");
System.Console.WriteLine($"my: {tree.Count}  ling: {tree.Count()}");
foreach (var d in tree)
{
    System.Console.Write($"{d} ");
}
System.Console.WriteLine();
