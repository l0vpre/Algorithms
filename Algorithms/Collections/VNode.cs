using System.Collections;
using Algorithms.Interfaces;

namespace Algorithms.Collections;

public class VNode<T> : IVNode<T>
{
    public T Data { get; set; }
    public IVNode<T>? Next { get; set; }
    public IVNode<T>? Previous { get; set; }

    public VNode(T item)
    {
        Data = item;
        Next = null;
        Previous = null;
    }
}