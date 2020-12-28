using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class EffectNotification : MonoBehaviour , IElementEffect
{
    public static event Action<int> Spray;

    protected void Notify(int value)
    {
        if (Spray != null)
        {
            Spray(value);
        }
    }
    public virtual int Applay(){
        return 0;
    }
}
