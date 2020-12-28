using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : EffectNotification
{
    public int life;
    public static event Action<GameObject> GoToPool;
    public override int Applay()
    {
        Notify(life);
        return life;
    }
    private void OnBecameInvisible()
    {
        if (GoToPool != null)
        {
            GoToPool(gameObject);
        }
    }
}
