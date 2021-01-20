using UnityEngine;

public class ObstacleHole : Obstacle
{
    public float duraction;
    private void OnEnable()
    {
        GetComponent<BoxCollider2D>().isTrigger = false;
    }
    public override void Applay(GameObject target)
    {
        effect = new Hole(target);
        RatsAttack.instance.Stop();
        Invoke("laziFall", 0.1f);
        target.GetComponent<Life>().effect = effect;
        target.GetComponent<Life>().CurrentPoint = -1;

    }

    private void laziFall()
    {
        Progress.instance.Stop();
        (effect as Hole).Fall();
    }
}
