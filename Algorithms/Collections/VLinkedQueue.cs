
using System.Collections;
using Algorithms.Interfaces;

namespace Algorithms.Collections;

public class VLinkedQueue<T> : IVQueue<T>
{
    private IVLinkedList<T> _list;
    public VLinkedQueue()
    {
        _list = new VLinkedList<T>();
    }
    public int Count => _list.Count;

    public T? First => _list.Head is null ? default : _list.Head.Data;

    public bool IsSynchronized => throw new NotImplementedException();
    public object SyncRoot => throw new NotImplementedException();

    public void Clear() => _list.Clear();
    public bool Contains(T item) => _list.Contains(item);
    public T? Dequeue() => _list.PopHead();
    public void Enqueue(T item) => _list.AddTail(item);

    public IEnumerator<T> GetEnumerator() => _list.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => _list.GetEnumerator();

    public void CopyTo(Array array, int index) => _list.CopyTo((T[])array, index);
}
