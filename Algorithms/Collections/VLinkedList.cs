using System.Collections;
using System.Formats.Tar;
using Algorithms.Interfaces;

namespace Algorithms.Collections;

public class VLinkedList<T> : IVLinkedList<T>
{
    private IVNode<T>? _tail;
    private IVNode<T>? _head;
    private int _count;

    public int Count => _count;
    public IVNode<T>? Head => _head;
    public IVNode<T>? Tail => _tail;
    public bool IsReadOnly => false;

    public IVNode<T>? this[int index] => GetNodeAt(index);

    public VLinkedList()
    {
        _count = 0;
        _tail = null;
        _head = null;
    }

    public void AddHead(T item)
    {
        IVNode<T> node = new VNode<T>(item);
        if (_head is null)
        {
            _tail = node;
            _head = node;
        }
        else
        {
            node.Previous = _head;
            _head.Next = node;
            _head = node;
        }
        _count++;
    }

    public void AddTail(T item)
    {
        IVNode<T> node = new VNode<T>(item);
        if (_tail is null)
        {
            _tail = node;
            _head = node;
        }
        else
        {
            _tail.Previous = node;
            node.Next = _tail;
            _tail = node;
        }
        _count++;
    }

    public void Clear()
    {
        _tail = null;
        _head = null;
        _count = 0;
    }

    public bool Contains(T item)
    {
        IVNode<T>? current = _tail;
        while (current is not null)
        {
            T data = current.Data;
            if (data is not null && data.Equals(item))
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public IVNode<T> GetNodeAt(int index)
    {
        if (index > _count || index < 0)
            throw new IndexOutOfRangeException();

        IVNode<T>? current = _tail;
        for (int i = 0; i < index; i++)
        {
            if (current is null)
                throw new Exception(); // TODO: specify exception

            current = current.Next;
        }
        return current!;
    }

    public T PopHead()
    {
        if (_head is null)
            throw new Exception();

        T lastHeadData = _head.Data;

        if (_count == 1)
        {
            _head = null;
            _tail = null;
            _count--;
            return lastHeadData;
        }

        IVNode<T>? newHead = _head.Previous;
        if (newHead is null)
            throw new Exception();

        _head = newHead;
        newHead.Next = null;
        _count--;
        
        return lastHeadData;
    }

    public T PopTail()
    {
        if (_tail is null)
            throw new Exception();

        T lastTailData = _tail.Data;

        if (_count == 1)
        {
            _tail = null;
            _head = null;
            _count--;
            return lastTailData;
        }

        IVNode<T>? newTail = _tail.Next;
        if (newTail is null)
            throw new Exception();

        _tail = newTail;
        _count--;
        return lastTailData;
    }

    public int IndexOf(T item)
    {
        int index = 0;
        IVNode<T>? current = _tail;
        while (current is not null)
        {
            T data = current.Data;
            if (data is not null && data.Equals(item))
            {
                return index;
            }
            index++;
            current = current.Next;
        }
        return -1;
    }

    public bool Remove(T item)
    {
        if (_tail is null || _head is null)
        {
            return false;
        }

        if (_tail.Data is not null && _tail.Data.Equals(item))
        {
            PopTail();
            return true;
        }
        if (_head.Data is not null && _head.Data.Equals(item))
        {
            PopHead();
            return true;
        }
        IVNode<T>? current = _tail;

        while (current is not null)
        {
            T data = current.Data;
            if (data is not null && data.Equals(item))
            {
                current.Previous!.Next = current.Next;
                _count--;
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public void RemoveAt(int index)
    {
        if (index >= _count || index < 0)
        {
            throw new IndexOutOfRangeException();
        }
        if (index == 0)
        {
            PopTail();
            return;
        }
        if (index == _count - 1)
        {
            PopHead();
            return;
        }

        IVNode<T> toDelete = GetNodeAt(index);
        toDelete.Previous!.Next = toDelete.Next;
        _count--;
    }


    public void Add(T item) => AddHead(item);

    public void CopyTo(T[] array, int arrayIndex)
    {
        IVNode<T>? current = _tail;
        if (current is null)
        {
            return;
        }

        for (int i = arrayIndex; i < array.Length; i++)
        {
            array[i] = current.Data;
            if (current.Next is null)
            {
                return;
            }
            current = current.Next;
        }
    }

    public IEnumerator<T> GetEnumerator() => new Enumerator(_tail);

    IEnumerator IEnumerable.GetEnumerator() => new Enumerator(_tail);

    public class Enumerator : IEnumerator<T>
    {
        IVNode<T>? _current;
        IVNode<T>? _start;

        public Enumerator(IVNode<T>? tail)
        {
            _start = new VNode<T>(default!);
            _start.Next = tail;
            _current = _start;
        }

        public T Current
        {
            get

            {
                if (_current is null)
                {
                    throw new InvalidOperationException();
                }
                return _current.Data;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                if (Current is null)
                {
                    throw new InvalidOperationException();
                }
                return Current;
            }

        }

        public void Dispose() { }

        public bool MoveNext()
        {
            if (_current is null) return false;
            _current = _current.Next;
            return _current is not null;
        }
        public void Reset()
        {
            _current = _start;
        }
    }
}
