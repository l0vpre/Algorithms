using Algorithms;
using Algorithms.Collections;


Dictionary<char, HashSet<(char v, double l)>> graph = new()
{
    ['A'] = new() { ('B', 45.43), ('C', 9.22145) },
    ['B'] = new() { ('D', 7.0087) },
    ['C'] = new() { ('F', 32.5), ('E', 8.2) },
    ['D'] = new() { ('E', 4.6) },
    ['E'] = new(),
    ['F'] = new()
};

graph.WriteLine();
var minPaths = graph.MinPaths('A');

foreach (var v in minPaths)
{
    Console.WriteLine($"{v.Key}: {string.Join("->", v.Value)} ");
}
