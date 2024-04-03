using Algorithms;
using Algorithms.Collections;


VBinaryTree<int> tree = new VBinaryTree<int>();
tree.Add(8);
tree.Add(7);
tree.Add(10);
tree.Add(2);
tree.Add(-45);
tree.Add(234);
tree.Add(435);
tree.Add(23);
tree.Add(5);
tree.Add(57);
tree.Add(0);
tree.Add(72);
tree.Add(1);
tree.Add(23);
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
