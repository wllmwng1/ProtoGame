using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PriorityQueueTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void SwapTest()
        {
            // Use the Assert class to test conditions
            PriorityQueue queue = new PriorityQueue();
            queue.Add(1);
            queue.Add(2);
            queue.Swap(0, 1);
            Assert.IsTrue(queue.Heap[0] == 2);
            Assert.IsTrue(queue.Heap[1] == 1);
        }

        [Test]
        public void sortUpTest()
        {
            PriorityQueue queue = new PriorityQueue();
            queue.Add(2);
            queue.Add(1);
            queue.sortUp(1);
            Assert.IsTrue(queue.Heap[0] == 1);
            Assert.IsTrue(queue.Heap[1] == 2);
            queue.Add(0);
            queue.sortUp(2);
            Assert.IsTrue(queue.Heap[0] == 0);
            queue.Add(3);
            queue.sortUp(3);
            Assert.IsTrue(queue.Heap[3] == 3);
            queue.Add(-1);
            queue.sortUp(4);
            Assert.IsTrue(queue.Heap[0] == -1);
        }

        [Test]
        public void InsertTest()
        {
            PriorityQueue queue = new PriorityQueue();
            queue.Insert(5);
            queue.Insert(3);
            queue.Insert(1);
            queue.Insert(2);
            queue.Insert(4);
            Assert.AreEqual(queue.CurrSize, 5);
            for (int i = 0; i < 5; i++)
            {
                Assert.IsTrue(queue.Heap[i] >= queue.Heap[(i-1)/2]);
            }
        }

        [Test]
        public void minChildTest()
        {
            PriorityQueue queue = new PriorityQueue();
            queue.Insert(5);
            queue.Insert(3);
            queue.Insert(1);
            queue.Insert(2);
            queue.Insert(4);
            queue.Insert(6);
            Assert.AreEqual(queue.minChild(0), 1);
            Assert.AreEqual(queue.minChild(1), 4);
            Assert.AreEqual(queue.minChild(2), 5);
        }

        [Test]
        public void sortDownTest()
        {
            PriorityQueue queue = new PriorityQueue();
            queue.Add(6);
            queue.Add(1);
            queue.Add(2);
            queue.Add(3);
            queue.Add(4);
            queue.Add(5);
            queue.setSize(6);
            queue.sortDown(0);
            Assert.AreEqual(queue.Heap[0], 1);
            Assert.AreEqual(queue.Heap[1], 3);
            Assert.AreEqual(queue.Heap[3], 6);
        }

        [Test]
        public void PopTest()
        {
            PriorityQueue queue = new PriorityQueue();
            queue.Insert(5);
            queue.Insert(3);
            queue.Insert(1);
            queue.Insert(2);
            queue.Insert(4);
            queue.Insert(6);
            int result = queue.Pop();
            Assert.AreEqual(result, 1);
            Assert.AreEqual(queue.Heap.Length, 5);
        }

        [Test]
        public void UpdateTest()
        {
            PriorityQueue queue = new PriorityQueue();
            queue.Insert(1);
            queue.Insert(2);
            queue.Insert(3);
            queue.Insert(4);
            queue.Insert(5);
            queue.Insert(6);
            queue.Update(1, 7);
            Assert.AreEqual(queue.Heap[3], 7);
            Assert.AreEqual(queue.Heap[1], 4);
            queue.Update(5, 0);
            Assert.AreEqual(queue.Heap[0], 0);
            Assert.AreEqual(queue.Heap[2], 1);
            Assert.AreEqual(queue.Heap[5], 3);
        }
    }
}
