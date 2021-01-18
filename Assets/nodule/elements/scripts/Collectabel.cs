using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectabel : Element
{
    public int points;
    private UnityEngine.GameObject target;
    public override void Applay(UnityEngine.GameObject target)
    {
        this.target = target;
        base.Applay();
        Notify(points);

        target.GetComponent<Life>().CurrentPoint = target.GetComponent<Player>().Avaliable(points);
    }
}
