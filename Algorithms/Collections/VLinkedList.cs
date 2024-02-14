using System.Collections;
using Algorithms.Interfaces;

namespace Algorithms.Collections;

public class VLinkedList<T> : IVLinkedList<T>
{
    private IVNode<T>? _tail;
    private IVNode<T>? _head;
    private int _count;
    public IVNode<T>? this[int index] => throw new NotImplementedException();

    public int Count => _count;

    public IVNode<T> Head => _head!;

    public IVNode<T> Tail => _tail!;

    public bool IsReadOnly => false;
    public VLinkedList()
    {
        _count = 0;
        _tail = null;
        _head = null;
    }

    public void AddHead(T item)
    {
        IVNode<T> node = new VNode<T>(item);
        if (_count == 0)
        {
            _tail = node;
            _head = node;
        }
        else
        {
            _head!.Next = node;
            _head = node;
        }
        _count++;
    }

    public void AddTail(T item)
    {
        IVNode<T> node = new VNode<T>(item);
        if (_count == 0)
        {
            _tail = node;
            _head = node;
        }
        else
        {
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
        IVNode<T> current = _tail!;
        while(current != null)
        {
            if(current.Data!.Equals(item))
            {
                return true;
            }
            current = current.Next!;
        }
        return false;
    }

    public int IndexOf(T item)
    {
        int index = 0;
        IVNode<T> current = _tail!;
        while(index < _count)
        {
            if(current.Data!.Equals(item))
            {
                return index;
            }
            index++;
            current = current.Next!;
        }
        return -1;
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
