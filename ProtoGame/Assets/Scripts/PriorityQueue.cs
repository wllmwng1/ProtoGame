using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriorityQueue
{
    private int currSize = 0;
    private List<int> heap = new List<int>();

    public int[] Heap { get { return heap.ToArray(); } }

    public int CurrSize { get { return currSize;  } }

    public void setSize(int i)
    {
        currSize = i;
    }

    public void Add(int x)
    {
        heap.Add(x);
    }

    public void Insert(int x)
    {
        heap.Add(x);
        currSize += 1;
        sortUp(currSize-1);
    }

    public int Pop()
    {
        int result = heap[0];
        heap[currSize-1] = heap[0];
        currSize -= 1;
        heap.Remove(heap[currSize-1]);
        sortDown(0);
        return result;
    }

    public void Update(int i, int x)
    {
        heap[i] = x;
        if (heap[(i-1)/2] > x)
        {
            sortUp(i);
        }
        else
        {
            sortDown(i);
        }
    }

    public void Remove(int x)
    {
        heap.Remove(x);
    }

    public void Swap(int x, int y)
    {
        var tmp = heap[x];
        heap[x] = heap[y];
        heap[y] = tmp;
    }

    public void sortUp(int i)
    {
        while ((i+1)/2 > 0)
        {
            if (heap[i] < heap[(i - 1) / 2])
            {
                Swap(i, (i - 1) / 2);
            }
            i = (i - 1) / 2;
        }
    }

    public void sortDown(int i)
    {
        while (i*2+1 <= currSize)
        {
            int mc = minChild(i);
            if (heap[i] > heap[mc])
            {
                Swap(i, mc);
            }
            i = mc;
        }
    }

    public int minChild(int i)
    {
        if (i*2 + 2 > currSize-1)
        {
            return i * 2 + 1;
        }
        else
        {
            if (heap[i*2+1] < heap[i*2+2])
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