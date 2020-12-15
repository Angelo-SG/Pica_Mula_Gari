using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllementEvent : MonoBehaviour
{
    public static event Action<GameObject> GoToPool;
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
