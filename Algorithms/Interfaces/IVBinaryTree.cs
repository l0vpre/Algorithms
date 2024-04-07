namespace Algorithms.Interfaces;

public interface IVBinaryTree<T> : IEnumerable<T>, ICollection<T>
where T : notnull, IComparable
{
    IBNode<T>? Root { get; }
    void Balance();
}
