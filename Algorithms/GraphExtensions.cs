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

        VLinkedQueue<T> toVisit = new();
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

    public static Dictionary<T, double> MinPathLengths<T>(this Dictionary<T, HashSet<(T Vertex, double Length)>> graph, T root)
    where T : notnull
    {
        Dictionary<T, double> paths = new();
        Dictionary<T, bool> visited = new();
        foreach (var v in graph.Keys)
        {
            paths[v] = double.PositiveInfinity;
            visited[v] = false;
        }
        paths[root] = 0;

        while (true)
        {
            var notVisited = paths.Where(p => !visited[p.Key]);
            if (notVisited.Count() == 0)
                break;

            var minVertex = notVisited.MinBy(p => p.Value);
            visited[minVertex.Key] = true;
            foreach (var v in graph[minVertex.Key].Where(p => !visited[p.Vertex]))
            {
                double len = v.Length + minVertex.Value;
                if (len < paths[v.Vertex])
                {
                    paths[v.Vertex] = len;
                }
            }

        }
        return paths;
    }
    public static Dictionary<T, IEnumerable<T>> MinPaths<T>(this Dictionary<T, HashSet<(T Vertex, double Length)>> graph, T root)
        where T : notnull
    {
        var paths = MinPathLengths(graph, root);
        Dictionary<T, IEnumerable<T>> result = new();
        foreach (var v in graph.Keys)
        {
            IEnumerable<T> MinPath()
            {
                double len = paths[v];
                var currentVertex = v;
                while (!currentVertex.Equals(root))
                {
                    yield return currentVertex;
                    var p = graph
                        .Where(p => p.Value.Any(v => v.Vertex.Equals(currentVertex)))
                        .Select(p => (p.Key, p.Value.First(v => v.Vertex.Equals(currentVertex))))
                        .First(p => Math.Abs(len - paths[p.Key] - p.Item2.Length) < 1e-10);

                    currentVertex = p.Key;
                    len -= p.Item2.Length;
                }
                yield return root;

            }
            result[v] = MinPath().Reverse();
        }
        return result;
    }




}
