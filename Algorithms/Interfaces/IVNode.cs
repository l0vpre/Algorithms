namespace Algorithms.Interfaces;

public interface IVNode<T>
{
    T Data { get; set; }
    IVNode<T> Next { get; set; }
}

