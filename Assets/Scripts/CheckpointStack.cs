using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointStack<T> : MonoBehaviour
{
    private LinkedList<T> stackList = new LinkedList<T>();

    public void Push(T item)
    {
        stackList.AddLast(item);
    }

    public T Pop()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Stack is empty!");

        T lastItem = stackList.Last.Value;
        stackList.RemoveLast();
        return lastItem;
    }

    public T Peek()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Stack is empty!");

        return stackList.Last.Value;
    }

    public bool IsEmpty()
    {
        return stackList.Count == 0;
    }

    public int Count()
    {
        return stackList.Count;
    }
}
