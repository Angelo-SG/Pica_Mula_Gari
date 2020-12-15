using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : EffectNotification, IElementEffect
{
    public int life;
    public int Applay()
    {
        Emmit(life);
        return life;
    }
}
