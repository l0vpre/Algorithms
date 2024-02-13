using System.Collections;
using Algorithms.Interfaces;

namespace Algorithms.Collections;

public class VLinkedList<T> : IVLinkedList<T>
{
    public IVNode<T>? this[int index] => throw new NotImplementedException();

    public int Count => throw new NotImplementedException();

    public IVNode<T> Head => throw new NotImplementedException();

    public IVNode<T> Tail => throw new NotImplementedException();

    public bool IsReadOnly => throw new NotImplementedException();

    public void AddHead(T item)
    {
        throw new NotImplementedException();
    }

    public void AddTail(T item)
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(T item)
    {
        throw new NotImplementedException();
    }

    public int IndexOf(T item)
    {
        throw new NotImplementedException();
    }

    public bool Remove(T item)
    {
        throw new NotImplementedException();
    }

    public bool RemoveAt(int index)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public void Add(T item)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }
}
