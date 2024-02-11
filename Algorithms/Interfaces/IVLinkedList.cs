namespace Algorithms.Interfaces;

public interface IVLinkedList<T> : IEnumerable<T>
{
    int Count { get; }
    IVNode<T> Head { get; }
    IVNode<T> Tail { get; }

    public IVNode<T>? this[int index] { get; }

    void AddHead(T item);
    void AddTail(T item);
    void Clear();
    bool Contains(T item);
    int IndexOf(T item);
    bool Remove(T item);
    bool RemoveAt(int index);
}
