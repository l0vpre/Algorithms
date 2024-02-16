namespace Algorithms.Interfaces;

public interface IVNode<T>
{
    public T Data { get; set; }
    public IVNode<T>? Next { get; set; }
    public IVNode<T>? Previous { get; set; }
}

