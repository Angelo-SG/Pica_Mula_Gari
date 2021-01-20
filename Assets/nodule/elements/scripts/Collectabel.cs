using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectabel : Element
{
    public int points;
    private GameObject target;
    private void Awake()
    {
        instance = this;
    }
    public override void Applay(GameObject target)
    {
        this.target = target;
        base.Applay();
        Notify(points);

        target.GetComponent<Life>().CurrentPoint = target.GetComponent<Player>().Avaliable(points);
    }
}
