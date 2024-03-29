using Algorithms.Collections;
namespace Algorithms.Interfaces;

public interface IVLinkedList<T> : ICollection<T>
{

    IVNode<T>? Head { get; }
    IVNode<T>? Tail { get; }

    public IVNode<T>? this[int index] { get; }

    void AddHead(T item);
    void AddTail(T item);
    int IndexOf(T item);
    void RemoveAt(int index);
    T PopHead();
    T PopTail();
}
