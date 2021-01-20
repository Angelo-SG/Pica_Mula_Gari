using System;
using UnityEngine;

public abstract class Element : MonoBehaviour
{
    public static event Action<int> Spray;
    public static event Action<GameObject> GoToPool;
    public static Element instance;
    public bool active;
   
    private void OnEnable()
    {
        active = true;
        GetComponent<SpriteRenderer>().enabled = true;
    }
    private void OnBecameInvisible()
    {
        if (GoToPool != null)
        {
            GoToPool(gameObject);
        }
    }
    protected void Notify(int value = 0)
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
