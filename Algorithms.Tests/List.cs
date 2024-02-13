using Algorithms.Interfaces;
using Algorithms.Collections;
using System.Reflection;

namespace Algorithms.Tests;

public static class List
{
    [Fact]
    public static void ListAdd()
    {
        IVList<int> list = new VList<int>() { 6, 93, -3, 0, 23, 12, 9 };
        Assert.Equal([6, 93, -3, 0, 23, 12, 9], list);

    }

    [Fact]
    public static void ListAddCompare()
    {
        IVList<int> vlist = new VList<int>();
        List<int> list = new List<int>();
        for (int i = 0; i < 1000; i++)
        {
            vlist.Add(i * 5);
            list.Add(i * 5);
        }
        Assert.Equal(list, vlist);

    }

    [Fact]
    public static void ListClear()
    {
        IVList<int> list = new VList<int> { 5, 35, 20, -32, 244 };
        list.Clear();
        Assert.Empty(list);
    }
    [Fact]
    public static void ListCount()
    {
        IVList<char> vlist = new VList<char> { 'l', '0', 'v', 'p', 'r', 'e' };
        Assert.Equal(6, vlist.Count);
    }

    [Fact]
    public static void ListContains()
    {
        IVList<string> list = new VList<string> { "omg", "Hello words!", "l0vpre" };
        Assert.True(list.Contains("l0vpre"));
    }
    [Fact]
    public static void ListCopyTo()
    {
        IVList<char> vlist = new VList<char> { 'l', '0', 'v', 'p', 'r', 'e' };
        char[] arr = ['x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x'];
        vlist.CopyTo(arr, 2);
        Assert.Equal(['x', 'x', 'l', '0', 'v', 'p', 'r', 'e', 'x', 'x'], arr);
    }
    [Fact]
    public static void ListInsert()
    {
        IVList<int> vlist = new VList<int>() { 0, 1, 2, 3, 5, 6, 7 };
        vlist.Insert(4, 4);
        Assert.Equal([0, 1, 2, 3, 4, 5, 6, 7], vlist);

    }
    [Fact]
    public static void ListIndexOf()
    {
        IVList<string> list = new VList<string> { "lol", "kek", "chikibamboni", "USA" };
        Assert.Equal(2, list.IndexOf("chikibamboni"));
    }
    [Fact]
    public static void ListRemove()
    {

        IVList<int> vlist = new VList<int>() { 0, 1, 2, 3, 4, 5, 5, 6, 7 };
        vlist.Remove(5);
        Assert.Equal([0, 1, 2, 3, 4, 5, 6, 7], vlist);

    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-142)]
    [InlineData(638745836)]
    public static void ListGetShouldThrow(int index)
    {
        IVList<char> vlist = new VList<char> { 'l', '0', 'v', 'p', 'r', 'e' };
        Assert.Throws<IndexOutOfRangeException>(() => { char item = vlist[index];});
    }
}