using System.Collections.Generic;
using UnityEngine;

public class DialogueQueue<T>
{
    private List<T> queue = new List<T>();

    public void Enqueue(T item)
    {
        queue.Add(item);
    }

    public T Dequeue()
    {
        if (queue.Count == 0)
        {
            Debug.LogWarning("Queue is empty!");
            return default;
        }
        T item = queue[0];
        queue.RemoveAt(0);
        return item;
    }

    public int Count()
    {
        return queue.Count;
    }

    public bool IsEmpty()
    {
        return queue.Count == 0;
    }
}
