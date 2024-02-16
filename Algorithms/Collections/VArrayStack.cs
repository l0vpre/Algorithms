using System.Collections;
using Algorithms.Interfaces;

namespace Algorithms.Collections;

public class VArrayStack<T> : IVStack<T>
{
    private IVList<T> _list;
    public VArrayStack()
    {
        _list = new VList<T>();
    }
    public int Count => _list.Count;

    public T? Top => _list[^1];

    public bool IsSynchronized => throw new NotImplementedException();
    public object SyncRoot => throw new NotImplementedException();

    public void Clear() => _list.Clear();
    public bool Contains(T item) => _list.Contains(item);

    public T? Pop()
    {
        if (Count == 0)
            return default;

        T last = _list[^1];
        _list.RemoveLast();
        return last;
    }

    public void Push(T item) => _list.Add(item);

    public IEnumerator<T> GetEnumerator() => _list.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => _list.GetEnumerator();

    public void CopyTo(Array array, int index) => _list.CopyTo((T[])array, index);
}
