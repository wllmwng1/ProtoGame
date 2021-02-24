using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridNode : Observable<Trigger>
{
    private Vector2 position;
    private List<GridNode> neighbours;
    private Entity entity;
    private List<Trigger> triggers;

    public GridNode(Vector2 _position)
    {
        position = _position;
        neighbours = new List<GridNode>();
        entity = null;
        triggers = new List<Trigger>();
    }

    public Vector2 Position { get { return position; } }
    public GridNode[] Neighbours { get { return neighbours.ToArray(); } }

    public void addNeighbour(GridNode _neighbour)
    {
        if (!neighbours.Contains(_neighbour))
        {
            neighbours.Add(_neighbour);
        }
        else
        {
            Debug.LogError("GridNode at " + position + "already has neighbour at" + _neighbour.position);
        }
    }

    public void removeNeighbour(GridNode _neighbour)
    {
        if (neighbours.Contains(_neighbour))
        {
            neighbours.Remove(_neighbour);
        }
        else
        {
            Debug.LogError("GridNode at " + position + "does not have neighbour at" + _neighbour.position);
        }
    }

    public void placeEntity(Entity _entity)
    {
        if (entity == null)
        {
            entity = _entity;
        }
        else
        {
            Debug.LogError("GridNode at " + position + "already has entity " + entity);
        }
    }

    public void removeEntity()
    {
        if (entity != null)
        {
            entity = null;
        }
        else
        {
            Debug.LogError("GridNode at " + position + "does not have an entity");
        }
    }

    public void addTrigger(Trigger _trigger)
    {
        this.subscribe(_trigger);
    }

    public void removeTrigger(Trigger _trigger)
    {
        this.unsubscribe(_trigger);
    }

    public void subscribe(Trigger _trigger)
    {
        if (!triggers.Contains(_trigger))
        {
            triggers.Add(_trigger);
        }
        else
        {
            Debug.LogError(_trigger + " is already subscribed");
        }
    }

    public void unsubscribe(Trigger _trigger)
    {
        if (triggers.Contains(_trigger))
        {
            triggers.Remove(_trigger);
        }
        else
        {
            Debug.LogError(_trigger + " is already not subscribed");
        }
    }
}
