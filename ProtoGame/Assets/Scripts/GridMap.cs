using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridMap : Observable<GridView>
{
    private Dictionary<Vector2, GridNode> nodes = new Dictionary<Vector2, GridNode>();
    private GridView observer;

    public Vector2[] getGridNodes 
    { 
        get 
        {
            return (from node in nodes.Values
                    select node.Position).ToArray();
        } 
    }

    public GridMap(Vector2[] addedLocations, Vector2[] removedLocations)
    {
        var locations = from add in addedLocations
                        where !removedLocations.Contains(add)
                        select add;
        foreach (Vector2 location in locations)
        {
            this.addNode(location);
        }
        this.assignNeighbours(nodes.Values.ToArray());
    }

    public void addNode(Vector2 _position)
    {
        if (!nodes.ContainsKey(_position))
        {
            GridNode newNode = new GridNode(_position);
            nodes.Add(_position, newNode);
            this.assignNeighbours(new GridNode[] {newNode});
        }
        else
        {
            Debug.LogError("Map already has node at " + _position);
        }
    }

    public void removeNode(Vector2 _position)
    {
        if (nodes.ContainsKey(_position))
        {
            this.removeNeighbours(new GridNode[] { nodes[_position] });
            nodes.Remove(_position);
        }
        else
        {
            Debug.LogError("Map does not have node at" + _position);
        }
    }

    public void connectNodes(Vector2 _position1, Vector2 _position2)
    {
        GridNode node1 = nodes[_position1];
        GridNode node2 = nodes[_position2];
        node1.addNeighbour(node2);
        node2.addNeighbour(node1);
    }

    public void disconnectNodes(Vector2 _position1, Vector2 _position2)
    {
        GridNode node1 = nodes[_position1];
        GridNode node2 = nodes[_position2];
        node1.removeNeighbour(node2);
        node2.removeNeighbour(node1);
    }

    public void assignNeighbours(GridNode[] nodes)
    {
        foreach (GridNode node in nodes)
        {
            var neighbours = from _node in nodes
                             where _node.Position == node.Position + Vector2.up
                             || _node.Position == node.Position + Vector2.down
                             || _node.Position == node.Position + Vector2.right
                             || _node.Position == node.Position + Vector2.left
                             select _node;
            foreach (GridNode neighbour in neighbours)
            {
                node.addNeighbour(neighbour);
            }
        }
    }

    public void removeNeighbours(GridNode[] _nodes)
    {
        foreach (GridNode node in _nodes)
        {
            var neighbours = from _node in nodes.Values
                             where node.Neighbours.Contains(_node)
                             select _node;
            foreach (GridNode neighbour in neighbours)
            {
                neighbour.removeNeighbour(node);
            }
        }
    }

    public void placeEntity(Entity _entity, Vector2 _position)
    {
        nodes[_position].placeEntity(_entity);
    }

    public void removeEntity(Vector2 _position)
    {
        nodes[_position].removeEntity();
    }

    public void moveEntity(Entity _entity, Vector2 _position1, Vector2 _position2)
    {
        nodes[_position1].removeEntity();
        nodes[_position2].placeEntity(_entity);
    }

    public void addTrigger(Trigger _trigger, Vector2 _position)
    {
        nodes[_position].addTrigger(_trigger);
    }

    public void removeTrigger(Trigger _trigger, Vector2 _position)
    {
        nodes[_position].removeTrigger(_trigger);
    }

    public void moveTrigger(Trigger _trigger, Vector2 _position1, Vector2 _position2)
    {
        nodes[_position1].removeTrigger(_trigger);
        nodes[_position2].addTrigger(_trigger);
    }

    public void addTriggers(Trigger _trigger, Vector2[] _positions)
    {
        var valid = from node in nodes.Values
                    from p in _positions
                    where node.Position == p
                    select node;
        foreach (var node in valid)
        {
            node.addTrigger(_trigger);
        }
    }

    public void removeTriggers(Trigger _trigger, Vector2[] _positions)
    {
        var valid = from node in nodes.Values
                    from p in _positions
                    where node.Position == p
                    select node;
        foreach (var node in valid)
        {
            node.removeTrigger(_trigger);
        }
    }

    public void moveTriggers(Trigger _trigger, Vector2[] _positions, Vector2 offset)
    {
        var offsetPositions = from p in _positions
                              select p + offset;
        this.removeTriggers(_trigger, _positions);
        this.addTriggers(_trigger, offsetPositions.ToArray());
    }

    public void subscribe(GridView _view)
    {
        if (observer == null)
        {
            observer = _view;
        }
        else
        {
            Debug.LogError("There is already a view subscribed");
        }
    }

    public void unsubscribe(GridView _view)
    {
        if (observer == _view)
        {
            observer = null;
        }
        else
        {
            Debug.LogError("This view is not the subscribed view");
        }
    }
}

public class GridMapBuilder
{
    private List<Vector2> added, removed;
    //private List<Vector2> removed;

    public GridMapBuilder()
    {
        this.added = new List<Vector2>();
        this.removed = new List<Vector2>();
    }

    public GridMapBuilder addTilemap(Tilemap tilemap)
    {
        BoundsInt bounds = tilemap.cellBounds;
        foreach (Vector3Int pos in tilemap.cellBounds.allPositionsWithin)
        {
            Vector3Int tilepos = new Vector3Int(pos.x, pos.y, pos.z);
            if (tilemap.HasTile(tilepos))
            {
                this.added.Add(new Vector2(pos.x, pos.y));
            }
        }
        return this;
    }

    public GridMapBuilder removeTilemap(Tilemap tilemap)
    {
        BoundsInt bounds = tilemap.cellBounds;
        foreach (Vector3Int pos in tilemap.cellBounds.allPositionsWithin)
        {
            Vector3Int tilepos = new Vector3Int(pos.x, pos.y, pos.z);
            if (tilemap.HasTile(tilepos))
            {
                this.removed.Add(new Vector2(pos.x, pos.y));
            }
        }
        return this;
    }

    public GridMap create()
    {
        return new GridMap(this.added.ToArray(), this.removed.ToArray());
    }
}