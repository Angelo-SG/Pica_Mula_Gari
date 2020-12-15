using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeNotification : MonoBehaviour
{
    private int count = 0;
    private int lastPoint = 0;
    private float time = 0;
    public int timeLimit = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Element")
        {
            count = other.gameObject.GetComponent<IElementEffect>().Applay();
        }
    }

    private void Update()
    {
        FeedbackLife();
    }

    public void FeedbackLife()
    {
        time += Time.deltaTime;
        if (count < lastPoint)
        {
            time = 0;
        }else{
            if( time > timeLimit){
                RatsToAway();
            }
        }
        lastPoint = count;
    }
    public void RatsToAway(){

    }
}
