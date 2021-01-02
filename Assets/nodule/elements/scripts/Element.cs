using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class Element : MonoBehaviour
{
    public static event Action<int> Spray;
    public static event Action<GameObject> GoToPool;
    public int points;

    private void OnBecameInvisible()
    {
        if (GoToPool != null)
        {
            GoToPool(gameObject);
        }
    }
    protected void Notify(int value)
    {
        if (Spray != null)
        {
            Spray(value);
        }
    }
    public virtual void Applay(GameObject target = null)
    {
         if (GoToPool != null)
        {
            GoToPool(gameObject);
        }
    }
}
