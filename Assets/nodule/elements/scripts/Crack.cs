using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crack : Obstacle
{
    private GameObject target;
    public float stunTime;
    private float count;
    private bool active = false;
    public override void Applay(GameObject t)
    {
        target = t;
        Stun();
    }

    private void Stun()
    {
        count = 0;
        target.GetComponent<Controller>().enabled = false;
        active = true;
    }

    private void Update()
    {
        count += Time.deltaTime;
        if (active)
        {
            if (count >= stunTime)
            {
                target.GetComponent<Controller>().enabled = true;
                active = false;
            }
        }
    }
}
