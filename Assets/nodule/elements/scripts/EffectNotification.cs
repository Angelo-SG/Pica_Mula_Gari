using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class EffectNotification : MonoBehaviour
{
    public static event Action<int> Spray;

    protected void Notify(int value){
        if(Spray != null){
            Spray(value);
        }
    }
}
