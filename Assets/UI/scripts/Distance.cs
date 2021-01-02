using System;
using UnityEngine;
using TMPro;

public class Distance : MonoBehaviour
{
    public int factor = 10;
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = Math.Truncate(Progress.instance.Distance / factor).ToString();
    }
}
