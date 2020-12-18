using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectabel : EffectNotification, IElementEffect
{
    public static event Action<GameObject> GoToPool;
    public int life;
    public int Applay()
    {
        Notify(life);
        return life;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (GoToPool != null)
            {
                GoToPool(gameObject);
            }
        }
    }
    private void OnBecameInvisible()
    {
        if (GoToPool != null)
        {
            GoToPool(gameObject);
        }
    }
}
