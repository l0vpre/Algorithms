using System.Collections;

namespace Algorithms.Interfaces;

public interface IVStack<T> : ICollection
{
    T? Top { get; }

    void Clear();
    bool Contains(T item);
    T? Pop();
    void Push(T item);
}
