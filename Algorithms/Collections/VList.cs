using System.Collections;
using Algorithms.Interfaces;

namespace Algorithms.Collections;

public class VList<T> : IVList<T>
{
    private const int InitialCapacity = 16;

    private T[] _array;
    private int _count;
    private int _capacity;

    public int Count => _count;
    public bool IsReadOnly => false;

    public VList()
    {
        _array = new T[InitialCapacity];
        _capacity = InitialCapacity;
        _count = 0;
    }

    public T this[int index]
    {
        get
        {
            if (index > _count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            return _array[index];
        }
        set
        {
            if (index > _count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            _array[index] = value;
        }
    }

    public void Add(T item)
    {
        if (_count == _array.Length - 2)
        {
            Expand();
        }

        _array[_count] = item;
        _count++;
    }

    public void Expand()
    {
        _capacity = _capacity * 2;
        T[] array = new T[_capacity];
        _array.CopyTo(array, 0);
        _array = array;
    }

    public void Clear()
    {
        _count = 0;
    }

    public bool Contains(T item)
    {
        for (int i = 0; i < _count; i++)
        {
            if (_array[i]!.Equals(item))
            {
                return true;
            }
        }
        return false;
    }

    public void CopyTo(T[] array, int arrayIndex) => Array.Copy(_array, 0, array, arrayIndex, _count);
    public int IndexOf(T item)
    {
        for (int index = 0; index < _count; index++)
        {
            if (_array[index]!.Equals(item))
            {
                return index;
            }
        }
        return -1;
    }

    public void Insert(int index, T item)
    {
        if (_count == _array.Length)
        {
            Expand();
        }
        
        _count++;
        for (int i = _count; i > index; i--)
        {
            _array[i] = _array[i - 1];
        }
        _array[index] = item;
    }

    public bool Remove(T item)
    {
        int index = IndexOf(item);
        if (index == -1) return false;
        RemoveAt(index);
        return true;
    }

    public void RemoveAt(int index)
    {
        if (index < _count)
        {
            for (int i = index; i < _count; i++)
            {
                _array[i] = _array[i + 1];
            }
            _count--;
        }
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
