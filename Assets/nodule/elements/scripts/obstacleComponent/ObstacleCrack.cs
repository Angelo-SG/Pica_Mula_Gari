using UnityEngine;

public class ObstacleCrack : Obstacle
{
    private Effect effect;
    public float stun;
    public override void Applay(GameObject target)
    {
        effect = new Crack(target);
        (effect as Crack).stunTime = stun;
        (effect as Crack).Stun();
        target.GetComponent<Life>().effect = effect;
    }
}
