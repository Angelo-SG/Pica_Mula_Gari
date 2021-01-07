using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectabel : Element
{
    public int points;
    public override void Applay(GameObject target)
    {
        base.Applay();
        Notify(points);
    }

}
