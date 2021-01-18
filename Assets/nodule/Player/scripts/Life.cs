using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Life : MonoBehaviour
{
    private int currentPoint = 0;
    private float countTime = 0;
    private Animator animator;
    public int timeLimit = 0;
    private int currentLife = 1;
    public enum state {DEAD, ALIVE}
    public static state situation;
    public Effect effect = new ObjNullEffect();
    public static event Action<int> ratsDistance;


    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        situation = state.ALIVE;
    }
    public int CurrentPoint
    {
        get { return currentPoint; }
        set { currentPoint = value; }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Element")
        {
            other.gameObject.GetComponent<Element>().Applay(gameObject);
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
            if (currentLife == 0)
            {
                dead();
            }
            ratsDistance(currentLife);
        }
    }
    private void dead()
    {
        Invoke("laziDead",.5f);
        
        RatsAttack.instance.Stop();
        effect = new ObjNullEffect();
        situation = state.DEAD;
        animator.Play("Dead");
    }
    private void laziDead(){
        Progress.instance.Stop();
    }
}
