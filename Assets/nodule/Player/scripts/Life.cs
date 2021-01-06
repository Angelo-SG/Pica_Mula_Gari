using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Life : MonoBehaviour
{
    private int currentPoint = 0;
    private float countTime = 0;
    public int timeLimit = 0;
    private int currentLife = 1;
    public Effect effect = new ObjNullEffect();
    public static event Action<int> ratsDistance;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Element")
        {
            other.gameObject.GetComponent<Element>().Applay(gameObject);
            // if pontos incompativel com o character ou obstáculos MoveRats()
        }
    }
 
    private void Update()
    {
        effect.Update();
        FeedbackLife();
    }
    public void FeedbackLife()
    {
        countTime += Time.deltaTime;
        if (currentPoint < 0 && currentLife > 0)
        {
            countTime = 0;
            currentLife--;
            MoveRats();
            currentPoint = 1;
        }
        else
        {
            if (countTime > timeLimit && currentLife < 2)
            {
                countTime = 0;
                currentLife++;
                MoveRats();
            }
        }
    }
    public void MoveRats()
    {
        if (ratsDistance != null)
        {
            ratsDistance(currentLife);
        }
    }
}
