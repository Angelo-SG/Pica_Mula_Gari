using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpEffect : Effect
{
    private float speedBuff = Progress.instance.InitialSpeed;
    public PowerUpEffect(GameObject target)
    {
        this.target = target;
    }
    public void SuperPower()
    {
        target.GetComponentInChildren<SpriteRenderer>().color = Color.red;
        Progress.instance.Boost(2);
    }
    public void HiperPower(){
        target.GetComponentInChildren<SpriteRenderer>().color = Color.blue;
        Progress.instance.Boost(3);
    }
    public void Reset()
    {
        target.GetComponentInChildren<SpriteRenderer>().color = Color.white;
        Progress.instance.Rest();
    }
}
