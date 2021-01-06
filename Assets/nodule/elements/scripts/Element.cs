using System;
using UnityEngine;

public abstract class Element : MonoBehaviour
{
    public static event Action<int> Spray;
    public static event Action<GameObject> GoToPool;
    private void OnEnable()
    {
        GetComponent<SpriteRenderer>().enabled = true;
    }
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
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
