using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeNotification : MonoBehaviour
{
    private int count = 0;
    private int lastPoint = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Element")
        {
            Debug.Log("foi");
            count = other.gameObject.GetComponent<IElementEffect>().Applay();
        }
    }

    private void Update()
    {
        FeedbackLife();
    }

    public void FeedbackLife()
    {
        if (count < lastPoint)
        {
            // rats feedback
        }
        lastPoint = count;
    }
}
