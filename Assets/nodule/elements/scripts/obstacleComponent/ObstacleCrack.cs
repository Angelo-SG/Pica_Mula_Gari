using UnityEngine;

public class ObstacleCrack : Obstacle
{
    public float stun;
    public override void Applay(GameObject target)
    {
        effect = new Crack(target);
        (effect as Crack).duraction = stun;
        (effect as Crack).Stun();
        target.GetComponent<Life>().effect = effect;
        target.GetComponent<Life>().CurrentPoint = -1;
    }
}
