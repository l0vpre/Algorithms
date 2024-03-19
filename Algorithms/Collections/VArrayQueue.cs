using System.Collections;
using Algorithms.Interfaces;

namespace Algorithms.Collections;

// TODO: fix and add tests
public class VArrayQueue<T> : IVQueue<T>
{
    private T[] _array;
    private int _head;
    private int _count;
    const int InitialCapacity = 16;

    public VArrayQueue()
    {
        _array = new T[InitialCapacity];
        _head = 0;
        _count = 0;
    }

    public int Count => _count;

    public T? First => _count > 0 ? _array[_head] : default;

    public bool IsSynchronized => throw new NotImplementedException();

    public object SyncRoot => throw new NotImplementedException();

    public void Clear()
    {
        _head = 0;
        _count = 0;
    }

    public bool Contains(T item)
    {
        for (int i = _head; i < _head + _count; i++)
        {
            T it = _array[i];
            if (it is not null && it.Equals(item))
                return true;
        }
        return false;
    }

    public void CopyTo(Array array, int index) => Array.Copy(_array, _head, array, index, _count);

    private void Trim()
    {
        for (int i = 0; i < _count; i++)
        {
            _array[i] = _array[_head + i];
        }
        _head = 0;
    }

    public T? Dequeue()
    {
        if (_count == 0)
            return default;

        T item = _array[_head];
        _head++;
        _count--;

        if (_head >= _array.Length / 2)
            Trim();

        return item;
    }

    public void Enqueue(T item)
    {
        if (_head + _count == _array.Length)
            Expand();

        _array[_count] = item;
        _count++;
    }

    private void Expand()
    {
        T[] newArray = new T[_array.Length * 2];
        Array.Copy(_array, _head, newArray, 0, _count);
        _array = newArray;
        _head = 0;
    }

    public IEnumerator<T> GetEnumerator() => _array.Skip(_head).Take(_count).GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => _array.Skip(_head).Take(_count).GetEnumerator();
}
