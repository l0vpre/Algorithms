using Algorithms;
using Algorithms.Collections;

var queue = new VArrayQueue<int>();
for(int i = 0; i < 1000; i++)
{
    queue.Enqueue(i);
}

for(int i = 0; i < 980; i++)
{
    queue.Dequeue();
}

foreach(var item in queue)
{
    System.Console.WriteLine(item);
}

