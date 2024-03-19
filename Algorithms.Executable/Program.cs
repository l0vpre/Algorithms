using Algorithms;
using Algorithms.Collections;


Dictionary<char, HashSet<(char v, double l)>> graph = new()
{
    ['A'] = new() { ('B', 45), ('C', 9) },
    ['B'] = new() { ('D', 7) },
    ['C'] = new() { ('F', 32), ('E', 8) },
    ['D'] = new() { ('E', 4) },
    ['E'] = new(),
    ['F'] = new()
};

graph.WriteLine();
var bfs = GraphExtensions.BFS(graph, 'A');
foreach (var l in bfs)
{
    Console.Write($"{l} ");
}
Console.WriteLine();
