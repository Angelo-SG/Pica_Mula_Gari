using UnityEngine;

public class ObstacleHole : Obstacle
{
    public float duraction;
    public override void Applay(GameObject target)
    {
        effect = new Hole(target);
        Progress.instance.Stop();
        RatsAttack.instance.Stop();
        (effect as Hole).Fall();
        target.GetComponent<Life>().effect = effect;
        target.GetComponent<Life>().CurrentPoint = -1;
    }
}
