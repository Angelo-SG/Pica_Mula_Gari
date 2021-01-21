using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoreData
{
    public int[] value;
    public ScoreData(int[] score)
    {
       value = score;
    }
}
