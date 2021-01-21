using UnityEngine;

public class ObstacleCrack : Obstacle
{
    public float stun;
    private void OnEnable()
    {
        GetComponent<BoxCollider2D>().isTrigger = false;
    }
    public override void Applay(GameObject target)
    {
        GetComponent<AudioSource>().Play();
        effect = new Crack(target);
        (effect as Crack).duraction = stun;
        (effect as Crack).Stun();
        target.GetComponent<Life>().effect = effect;
        target.GetComponent<Life>().CurrentPoint = -1;

    }
}
