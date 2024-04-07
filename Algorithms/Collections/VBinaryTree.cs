using System.Collections;
using Algorithms.Interfaces;

namespace Algorithms.Collections;

public class VBinaryTree<T> : IVBinaryTree<T>
where T : notnull, IComparable
{
    private int _count;
    public IBNode<T>? Root { get; set; }
    public int Count => _count;
    public bool IsReadOnly => false;

    public virtual void Add(T item)
    {
        if (Root is null)
        {
            Root = new BNode<T>(item);
            _count++;
        }
        else
        {
            var current = Root;
            while (true)
            {
                switch (current.Data.CompareTo(item))
                {
                    case 0:
                        return;
                    case > 0:
                        if (current.Left is null)
                        {
                            current.Left = new BNode<T>(item);
                            _count++;
                            return;
                        }
                        current = current.Left;
                        break;
                    case < 0:
                        if (current.Right is null)
                        {
                            current.Right = new BNode<T>(item);
                            _count++;
                            return;
                        }
                        current = current.Right;
                        break;
                }
            }
        }
    }

    public void Clear()
    {
        Root = null;
        _count = 0;
    }

    public virtual bool Contains(T item)
    {
        if (Root is null)
            return false;
        else
        {
            var current = Root;
            while (true)
            {
                switch (current.Data.CompareTo(item))
                {
                    case 0:
                        return true;
                    case > 0:
                        if (current.Left is not null && current.Left.Data.Equals(item))
                        {
                            return true;
                        }
                        if (current.Left is null)
                            return false;
                        current = current.Left;
                        break;
                    case < 0:
                        if (current.Right is not null && current.Right.Data.Equals(item))
                        {
                            return true;
                        }
                        if (current.Right is null)
                            return false;
                        current = current.Right;
                        break;
                }
            }
        }
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        var enumerator = GetEnumerator();
        for (int i = arrayIndex; i < array.Length && enumerator.MoveNext(); i++)
        {
            array[i] = enumerator.Current;
        }
    }

    public virtual bool Remove(T item)
    {
        Root = Remove(Root, item,out bool removed);
        if(removed)
            _count--;
        return removed;
    }

    public static IBNode<T>? Remove(IBNode<T>? root, T item, out bool removed)
    {
        if (root is null)
        {
            removed = false;
            return root;
        }

        switch (item.CompareTo(root.Data))
        {
            case > 0:
                root.Right = Remove(root.Right, item, out removed);
                return root;
            case < 0:
                root.Left = Remove(root.Left, item, out removed);
                return root;
            case 0:
                // one children or no children
                if (root.Left is null)
                {
                    removed = true;
                    return root.Right;
                }
                else if (root.Right is null)
                {
                    removed = true;
                    return root.Left;
                }
                // two children
                root.Data = MinValue(root.Right);
                root.Right = Remove(root.Right, root.Data, out _);
                removed = true;
                return root;
        }
    }

    private static T MinValue(IBNode<T> node)
    {
        T minv = node.Data;

        while (node.Left is not null)
        {
            minv = node.Left.Data;
            node = node.Left;
        }

        return minv;
    }

    IEnumerator IEnumerable.GetEnumerator() => Enumerate(Root);

    public IEnumerator<T> GetEnumerator() => Enumerate(Root);

    public static IEnumerator<T> Enumerate(IBNode<T>? root)
    {
        if (root is null)
            yield break;

        IEnumerator<T> left = Enumerate(root.Left);
        while (left.MoveNext())
        {
            yield return left.Current;
        }

        yield return root.Data;

        IEnumerator<T> right = Enumerate(root.Right);
        while (right.MoveNext())
        {
            yield return right.Current;
        }
    }

    public void Balance()
    {
        List<T> elements = this.ToList();
        Clear();
        Balance(0, elements.Count - 1, elements);
    }

    private void Balance(int left, int right, List<T> elements)
    {
        if(right < left)
        {
            return;
        }

        int middle = (left + right) / 2;
        Add(elements[middle]);
        Balance(left,middle -1, elements);
        Balance(middle+1,right, elements);
    }

}
