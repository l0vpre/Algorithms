using Algorithms.Interfaces;
using Algorithms.Collections;
using System.Reflection;

namespace Algorithms.Tests;

public static class LinkedList
{
    [Fact]
    public static void LinkedListAddHead()
    {
        IVLinkedList<int> list = new VLinkedList<int>() { 456 };
        list.AddHead(98);
        Assert.Equal([456, 98], list);

    }
    [Fact]
    public static void LinkedListAddTail()
    {
        IVLinkedList<string> list = new VLinkedList<string>() { "Vika", "USSSR", "HSR" };
        list.AddTail("GNOME");
        Assert.Equal(["GNOME", "Vika", "USSSR", "HSR"], list);

    }

    [Fact]
    public static void LinkedListAddCompare()
    {
        IVLinkedList<int> vlist = new VLinkedList<int>();
        LinkedList<int> list = new LinkedList<int>();
        for (int i = 0; i < 1000; i++)
        {
            vlist.Add(i * 5);
            list.AddLast(i * 5);
        }
        Assert.Equal(list, vlist);

    }

    [Fact]
    public static void LinkedListClear()
    {
        IVLinkedList<int> list = new VLinkedList<int> { 5, 35, 20, -32, 244 };
        list.Clear();
        Assert.Empty(list);
    }
    [Fact]
    public static void LinkedListCount()
    {
        IVLinkedList<char> vlist = new VLinkedList<char> { 'l', '0', 'v', 'p', 'r', 'e' };
        Assert.Equal(6, vlist.Count);
    }

    [Fact]
    public static void LinkedListContains()
    {
        IVLinkedList<string> list = new VLinkedList<string> { "omg", "Hello words!", "l0vpre" };
        Assert.True(list.Contains("l0vpre"));
    }
    [Fact]
    public static void LinkedListCopyTo()
    {
        IVLinkedList<char> vlist = new VLinkedList<char> { 'l', '0', 'v', 'p', 'r', 'e' };
        char[] arr = ['x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x'];
        vlist.CopyTo(arr, 2);
        Assert.Equal(['x', 'x', 'l', '0', 'v', 'p', 'r', 'e', 'x', 'x'], arr);
    }

    [Fact]
    public static void LinkedListIndexOf()
    {
        IVLinkedList<string> list = new VLinkedList<string> { "lol", "kek", "chikibamboni", "USA" };
        Assert.Equal(2, list.IndexOf("chikibamboni"));

    }

    [Theory]
    [InlineData(56)]
    [InlineData(-23)]
    [InlineData(112)]
    public static void LinkedListRemove(int item)
    {
        IVLinkedList<int> vlist = new VLinkedList<int>() { 56, 78, -23, 0, 112 };
        List<int> list = new(){ 56, 78, -23, 0, 112 };
        vlist.Remove(item);
        list.Remove(item);
        Assert.Equal(list, vlist);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(4)]
    [InlineData(2)]
    public static void LinkedListRemoveAt(int index)
    {
        IVLinkedList<int> vlist = new VLinkedList<int>() { 56, 78, -23, 0, 112 };
        List<int> list = new(){ 56, 78, -23, 0, 112 };
        vlist.RemoveAt(index);
        list.RemoveAt(index);
        Assert.Equal(list, vlist);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-142)]
    [InlineData(638745836)]
    public static void LinkedListGetShouldThrow(int index)
    {
        IVLinkedList<char> vlist = new VLinkedList<char> { 'l', '0', 'v', 'p', 'r', 'e' };
        Assert.Throws<IndexOutOfRangeException>(() => { char item = vlist[index]!.Data; });
    }
}
