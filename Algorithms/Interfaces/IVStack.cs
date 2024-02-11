namespace Algorithms.Interfaces;

public interface IVStack<T> : IEnumerable<T>
{
    int Count { get; }
    T? Top { get; }

    void Clear();
    bool Contains(T item);
    T? Pop();
    void Push(T item);
}
