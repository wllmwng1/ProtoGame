using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericPriorityQueue<T>
{
    private class GenericPriorityQueueNode
    {
        public float priority;
        public T data;

        public GenericPriorityQueueNode(float prio, T data)
        {
            this.priority = prio;
            this.data = data;
        }
    }

    private List<GenericPriorityQueueNode> heap = new List<GenericPriorityQueueNode>();

    public T[] Queue
    {
        get
        {
            List<T> result = new List<T>();
            foreach (GenericPriorityQueueNode node in heap)
            {
                result.Add(node.data);
            }
            return result.ToArray();
        }
    }

    public bool Contains(T data)
    {
        foreach (GenericPriorityQueueNode node in heap)
        {
            if (EqualityComparer<T>.Default.Equals(node.data, data))
            {
                return true;
            }
        }
        return false;
    }

    public void Insert(float prio, T data)
    {
        GenericPriorityQueueNode node = new GenericPriorityQueueNode(prio, data);
        heap.Add(node);
        this.sortUp(heap.Count - 1);
    }

    public T Pop()
    {
        T result = heap[0].data;
        heap[0] = heap[heap.Count - 1];
        heap.RemoveAt(heap.Count - 1);
        sortDown(0);
        return result;
    }

    public void Update(int i, float prio)
    {
        heap[i].priority = prio;
        if (heap[(i - 1) / 2].priority > prio)
        {
            sortUp(i);
        }
        else
        {
            sortDown(i);
        }
    }

    public void Update(T data, float prio)
    {
        int index = 0;
        for (int i = 0; i < heap.Count; i++)
        {
            if (EqualityComparer<T>.Default.Equals(heap[i].data, data))
            {
                heap[i].priority = prio;
                index = i;
                break;
            }
        }
        if (heap[(index - 1) / 2].priority > prio)
        {
            sortUp(index);
        }
        else
        {
            sortDown(index);
        }
    }

    private void Swap(int i, int j)
    {
        GenericPriorityQueueNode tmp = heap[i];
        heap[i] = heap[j];
        heap[j] = tmp;
    }

    private void sortUp(int i)
    {
        while ((i + 1) / 2 > 0)
        {
            if (heap[i].priority < heap[(i - 1) / 2].priority)
            {
                Swap(i, (i - 1) / 2);
            }
            i = (i - 1) / 2;
        }
    }

    private void sortDown(int i)
    {
        while (i * 2 + 1 < heap.Count)
        {
            int mc = minChild(i);
            if (heap[i].priority > heap[mc].priority)
            {
                Swap(i, mc);
            }
            i = mc;
        }
    }

    private int minChild(int i)
    {
        if (i * 2 + 2 > heap.Count - 1)
        {
            return i * 2 + 1;
        }
        else
        {
            if (heap[i * 2 + 1].priority < heap[i * 2 + 2].priority)
            {
                return i * 2 + 1;
            }
            else
            {
                return i * 2 + 2;
            }
        }
    }
}

