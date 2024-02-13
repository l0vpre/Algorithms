using System.Collections;
using Algorithms.Interfaces;

namespace Algorithms.Collections;

public class VList<T> : IVList<T>
{
    private const int InitialCapacity = 16;

    private T[] _array;
    private int _count;

    public int Count => _count;
    public bool IsReadOnly => false;

    public VList()
    {
        _array = new T[InitialCapacity];
        _count = 0;
    }

    public T this[int index]
    {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
    }

    public void Add(T item)
    {
        if (_count == _array.Length)
        {
            throw new NotImplementedException();
        }

        _array[_count] = item;
        _count++;
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(T item)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public int IndexOf(T item)
    {
        throw new NotImplementedException();
    }

    public void Insert(int index, T item)
    {
        throw new NotImplementedException();
    }

    public bool Remove(T item)
    {
        throw new NotImplementedException();
    }

    public void RemoveAt(int index)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<T> GetEnumerator()
        => new Enumerator(_array, _count);

    IEnumerator IEnumerable.GetEnumerator()
        => new Enumerator(_array, _count);

    public class Enumerator : IEnumerator<T>
    {
        private T[] _array;
        private int _count;
        private int _current;

        public Enumerator(T[] array, int count)
        {
            _array = array;
            _count = count;
            _current = -1;
        }

        public T Current => _array[_current];

        object IEnumerator.Current => Current!;

        public void Dispose() { }

        public bool MoveNext()
        {
            _current++;
            return _current < _count;
        }

        public void Reset()
        {
            _current = -1;
        }
    }
}
