using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class GenPriorityQueueTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void InsertTest()
        {
            GenericPriorityQueue<string> queue = new GenericPriorityQueue<string>();
            queue.Insert(5,"Fifth");
            queue.Insert(3,"Third");
            queue.Insert(1,"First");
            queue.Insert(2,"Second");
            queue.Insert(4,"Forth");
            string[] expected = { "First", "Second", "Third", "Fifth", "Forth" };
            Assert.AreEqual(queue.Queue, expected);
        }

        [Test]
        public void PopTest()
        {
            GenericPriorityQueue<string> queue = new GenericPriorityQueue<string>();
            queue.Insert(5, "Fifth");
            queue.Insert(3, "Third");
            queue.Insert(1, "First");
            queue.Insert(2, "Second");
            queue.Insert(4, "Forth");
            string result = queue.Pop();
            Assert.AreEqual(result, "First");
            string[] expected = { "Second", "Forth", "Third", "Fifth"};
            Assert.AreEqual(queue.Queue, expected);
            result = queue.Pop();
            Assert.AreEqual(result, "Second");
            expected = new string[] { "Third", "Forth", "Fifth" };
            Assert.AreEqual(queue.Queue, expected);
        }

        [Test]
        public void UpdateIndexTest()
        {
            GenericPriorityQueue<string> queue = new GenericPriorityQueue<string>();
            queue.Insert(1, "First");
            queue.Insert(2, "Second");
            queue.Insert(3, "Third");
            queue.Insert(4, "Forth");
            queue.Insert(5, "Fifth");
            queue.Update(1, 6);
            string[] expected = { "First", "Forth", "Third", "Second", "Fifth" };
            Assert.AreEqual(queue.Queue, expected);
            queue.Update(4, 0);
            expected = new string[] { "Fifth", "First", "Third", "Second", "Forth" };
            Assert.AreEqual(queue.Queue, expected);
        }

        [Test]
        public void UpdateDataTest()
        {
            GenericPriorityQueue<string> queue = new GenericPriorityQueue<string>();
            queue.Insert(1, "First");
            queue.Insert(2, "Second");
            queue.Insert(3, "Third");
            queue.Insert(4, "Forth");
            queue.Insert(5, "Fifth");
            queue.Update("Second", 6);
            string[] expected = { "First", "Forth", "Third", "Second", "Fifth" };
            Assert.AreEqual(queue.Queue, expected);
            queue.Update("Fifth", 0);
            expected = new string[] { "Fifth", "First", "Third", "Second", "Forth" };
            Assert.AreEqual(queue.Queue, expected);
        }
    }
}
