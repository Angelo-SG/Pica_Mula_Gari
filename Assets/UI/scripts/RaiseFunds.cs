using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RaiseFunds : MonoBehaviour
{
    private void OnEnable()
    {
        Element.Spray += SetText;
    }
    private void OnDisable()
    {
        Element.Spray -= SetText;
    }
    public void SetText(int life)
    {
        GetComponent<TextMeshProUGUI>().text = (Int32.Parse(GetComponent<TextMeshProUGUI>().text) + life).ToString();
    }
}
