namespace Algorithms.Interfaces;

public interface IVQueue<T> : IEnumerable<T>
{
    int Count { get; }
    T? First { get; }

    void Clear();
    bool Contains(T item);
    T? Dequeue();
    void Enqueue(T item);
}

