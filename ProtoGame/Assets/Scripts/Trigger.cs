using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trigger : Observer, Observable<BattleManager>
{
    public enum Timing { Before, After };
    private BattleManager manager;
    private Entity origin;
    private Timing timing;

    public Trigger(BattleManager _manager, Entity _origin, Timing _timing)
    {
        this.subscribe(_manager);
        this.origin = _origin;
        this.timing = _timing;
    }

    public virtual void subscribe(BattleManager _manager)
    {
        if (manager == null)
        {
            manager = _manager;
        }
        else
        {
            Debug.LogError("This trigger already has a battlemanager");
        }
    }

    public virtual void unsubscribe(BattleManager _manager)
    {
        if (manager != null)
        {
            manager = null;
        }
        else
        {
            Debug.LogError("This trigger doesn't have a battlemanager to begin with");
        }
    }

    public void observerUpdate()
    {

    }
}
