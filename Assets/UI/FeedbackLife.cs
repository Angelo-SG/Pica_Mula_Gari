using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedbackLife : MonoBehaviour
{
    private void OnEnable()
    {
        EffectNotification.Spray += SetText;
    }
    private void OnDisable()
    {
        EffectNotification.Spray -= SetText;
    }
    public void SetText(int life)
    {
        GetComponent<Text>().text = (Int32.Parse(GetComponent<Text>().text) + life).ToString();
    }
}
