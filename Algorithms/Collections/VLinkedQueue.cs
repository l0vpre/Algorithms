
using System.Collections;
using Algorithms.Interfaces;

namespace Algorithms.Collections;

public class VLinkedQueue<T> : IVQueue<T>
{
    public int Count => throw new NotImplementedException();

    public T? First => throw new NotImplementedException();

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(T item)
    {
        throw new NotImplementedException();
    }

    public T? Dequeue()
    {
        throw new NotImplementedException();
    }

    public void Enqueue(T item)
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
}
