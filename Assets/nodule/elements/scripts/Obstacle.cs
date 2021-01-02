using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : Element
{
    private float timeLife;
    private PlayerMoviment control;

    public override void Applay(GameObject target)
    {
        control = target.GetComponent<PlayerMoviment>();
        timeLife = Time.time;
        control.enabled = false;
        Notify(points);
    }
    private void Update()
    {
        if (control != null)
            if (Time.time - timeLife >= 2.0f && !control.enabled)
            {
                control.enabled = true;
            }
    }

}
