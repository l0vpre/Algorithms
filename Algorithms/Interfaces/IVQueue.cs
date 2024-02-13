using System.Collections;

namespace Algorithms.Interfaces;

public interface IVQueue<T> : ICollection
{
    T? First { get; }

    void Clear();
    bool Contains(T item);
    T? Dequeue();
    void Enqueue(T item);
}

