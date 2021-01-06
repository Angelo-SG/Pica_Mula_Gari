using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.Analytics;

public class Hole : Effect
{
    private GameObject[] rats;
    private GameObject target;
    private float duraction;
    private float count = 0;
    private bool enable = false;
    public Hole(GameObject[] rats, float duraction, GameObject target)
    {
        this.rats = rats;
        this.duraction = duraction;
        this.target = target.transform.parent.gameObject;

    }
    public override void Update()
    {
        count += Time.deltaTime;
        if (enable)
            if (count >= duraction)
            {
                Reset();
            }
    }
    public void Fall()
    {
        target.SetActive(false);
    }
    public void Reset()
    {
        count = 0;
        enable = false;
        target.SetActive(true);
        RatsAttack.instance.Play();
        Progress.instance.Play();
    }
}
