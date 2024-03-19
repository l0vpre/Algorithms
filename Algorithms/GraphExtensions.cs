using Algorithms.Collections;
namespace Algorithms;


public static class GraphExtensions
{
    public static void WriteLine<T>(this Dictionary<T, HashSet<(T Vertex, double Length)>> graph)
        where T : notnull
    {
        foreach (var v in graph)
        {
            Console.Write($"{v.Key}: ");
            foreach (var p in v.Value)
            {
                Console.Write($"{{{p.Length}, {p.Vertex}}} ");
            }
            System.Console.WriteLine();
        }
    }

    public static IEnumerable<T> BFS<T>(Dictionary<T, HashSet<(T Vertex, double Length)>> graph, T root)
        where T : notnull
    {
        Dictionary<T, bool> visited = new();
        foreach (var p in graph.Keys)
        {
            visited[p] = false;
        }

        VArrayQueue<T> toVisit = new();
        toVisit.Enqueue(root);

        while (toVisit.Count != 0)
        {
            T v = toVisit.Dequeue()!;
            if (visited[v])
                continue;

            visited[v] = true;
            yield return v;
            foreach (var p in graph[v])
            {
                toVisit.Enqueue(p.Vertex);
            }
        }
    }

    public static IEnumerable<T> DFS<T>(Dictionary<T, HashSet<(T Vertex, double Length)>> graph, T root)
        where T : notnull
    {
        Dictionary<T, bool> visited = new();
        foreach (var p in graph.Keys)
        {
            visited[p] = false;
        }

        VArrayStack<T> toVisit = new();
        toVisit.Push(root);

        while (toVisit.Count != 0)
        {
            T v = toVisit.Pop()!;
            if (visited[v])
                continue;

            visited[v] = true;
            yield return v;
            foreach (var p in graph[v])
            {
                toVisit.Push(p.Vertex);
            }
        }
    }
}
