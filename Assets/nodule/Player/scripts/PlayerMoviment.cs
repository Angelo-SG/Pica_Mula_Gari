using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

public class PlayerMoviment : MonoBehaviour
{
    public float time;
    public float distance;
    private float direction;
    private Vector3 startPosition;
    private bool ableAnimation;


    private void Start() {
        startPosition = transform.position;
    } 

    private void Update()
    {
        direction = Input.GetAxisRaw("Vertical");
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x,startPosition.y + direction * distance, transform.position.z), time);

    }
}
