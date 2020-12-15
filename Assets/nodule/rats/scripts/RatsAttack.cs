using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatsAttack : MonoBehaviour
{
    private Vector3 startPos;
    private void Start() {
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
        Debug.Log(distance);
        transform.position = new Vector3(-5f,0f,0f) * distance + startPos;
    }
}
