using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatsAttack : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 nextRatsPos;
    private bool lerp = false;
    public float speedAtack = 0.2f;
    private void Start()
    {
        startPos = transform.position;
    }
    private void OnEnable()
    {
        PlayerLifeNotification.ratsDistance += Approach;
    }
    private void OnDisable()
    {
        PlayerLifeNotification.ratsDistance += Approach;
    }
    private void Approach(int distance)
    {
        nextRatsPos = new Vector3(-3f * distance, 0, 0) + startPos;
        lerp = true;
    }
    private void Update()
    {
        if (lerp)
        {
            transform.position = Vector3.Lerp(transform.position, nextRatsPos, speedAtack);
            if (Vector3.Distance(transform.position, nextRatsPos) < 0.1f)
            {
                lerp = false;
            }
        }
    }
}
