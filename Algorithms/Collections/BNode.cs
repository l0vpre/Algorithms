using Algorithms.Interfaces;

namespace Algorithms.Collections;

public class BNode<T> : IBNode<T>
{
    public T Data { get; set; }
    public IBNode<T>? Right { get; set; }
    public IBNode<T>? Left { get; set; }
    public BNode(T item)
    {
        Data = item;
        Right = null;
        Left = null;
    }
}

