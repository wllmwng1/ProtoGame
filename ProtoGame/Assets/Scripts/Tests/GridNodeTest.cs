/*using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class GridNodeTestScript
    {

        [Test]
        public void newGridNode()
        {
            Vector2 pos = new Vector2(4, 5);
            GridNode obj = new GridNode(pos);
            Assert.IsTrue(obj is GridNode);
            Assert.AreEqual(obj.Position, pos);
        }

        [Test]
        public void gridNodeNeighbours()
        {
            Vector2 pos = new Vector2(4, 6);
            Vector2 neighbourPos = new Vector2(4, 5);
            GridNode obj = new GridNode(pos);
            GridNode neighbour = new GridNode(neighbourPos);
            obj.addNeighbour(neighbour);
            Assert.IsTrue(obj.Neighbours.Length == 1);
            Assert.AreEqual(obj.Neighbours[0], neighbour);
            obj.addNeighbour(neighbour);
            Assert.IsTrue(obj.Neighbours.Length == 1);
            obj.removeNeighbour(neighbour);
            Assert.IsTrue(obj.Neighbours.Length == 0);
            obj.removeNeighbour(neighbour);
            Assert.IsTrue(obj.Neighbours.Length == 0);
        }
    }
}
*/