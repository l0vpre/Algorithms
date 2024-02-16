
using System.Collections;
using Algorithms.Interfaces;

namespace Algorithms.Collections;

public class VLinkedStack<T> : IVStack<T>
{
    private IVLinkedList<T> _list;

    public int Count => _list.Count;
    public VLinkedStack()
    {
        _list = new VLinkedList<T>();
    }

    public T? Top => _list.Head is null ? default : _list.Head.Data;

    public bool IsSynchronized => throw new NotImplementedException();
    public object SyncRoot => throw new NotImplementedException();

    public void Clear() => _list.Clear();
    public bool Contains(T item) => _list.Contains(item);
    public T? Pop() => _list.PopHead();
    public void Push(T item) => _list.AddHead(item);

    public IEnumerator<T> GetEnumerator() => _list.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => _list.GetEnumerator();

    public void CopyTo(Array array, int index) => _list.CopyTo((T[])array, index);
}
