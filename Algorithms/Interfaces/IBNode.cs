namespace Algorithms.Interfaces;

public interface IBNode<T>
{
    public T Data { get; set; }
    public IBNode<T>? Right { get; set; }
    public IBNode<T>? Left { get; set; }
}
