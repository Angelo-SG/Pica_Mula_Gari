using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeNotification : MonoBehaviour
{
    private int currentPoint = 0;
    private float countTime = 0;
    public int timeLimit = 0;
    private int currentLife = 1;
    public static event Action<int> ratsDistance;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Element")
        {
            currentPoint = other.gameObject.GetComponent<IElementEffect>().Applay();
        }
    }

    private void Start()
    {
        if (ratsDistance != null)
        {
            ratsDistance(currentLife);
        }
    }
    private void Update()
    {
        FeedbackLife();
    }

    public void FeedbackLife()
    {
        countTime += Time.deltaTime;
        if (currentPoint < 0 && currentLife > 0)
        {
            countTime = 0;
            currentLife--;
            MuveRats();
            currentPoint = 1;
        }
        else
        {
            if (countTime > timeLimit && currentLife < 2)
            {
                countTime = 0;
                currentLife++;
                MuveRats();
            }
        }
    }
    public void MuveRats()
    {
        if (ratsDistance != null)
        {
            ratsDistance(currentLife);
        }
    }
}
