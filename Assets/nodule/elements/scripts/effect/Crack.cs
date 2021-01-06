using UnityEngine;
using System;
public class Crack : Effect
{
    private GameObject target;
    public float stunTime;
    private float count;
    private Effect effect;
    private bool able = false;
    private float buff;
    public Crack(GameObject target)
    {
        this.target = target;
    }
    public void Stun()
    {
        target.GetComponent<Controller>().enabled = false;
        buff = Time.time;
        count = 0;
        able = true;
    }

    public override void Update()
    {
        if (able)
        {
            count += Time.deltaTime;
            if (count > stunTime)
            {
                Reset();
            }
        }
    }
    private void Reset()
    {
        target.GetComponent<Controller>().enabled = true;
        able = false;
    }
}
