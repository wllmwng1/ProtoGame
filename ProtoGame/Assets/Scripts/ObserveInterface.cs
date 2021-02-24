using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Observable<T>
{
    void subscribe(T observer);

    void unsubscribe(T observer);
}

public interface Observer
{
    void observerUpdate();
}