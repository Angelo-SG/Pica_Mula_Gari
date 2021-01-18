using UnityEngine;

public class ObstacleOilPuddle : Obstacle
{
    public float speed = 0;
    public float checkpointY1 = 0;
    public float checkpointY2 = 0;
    private void OnEnable() {
        GetComponent<BoxCollider2D>().enabled = true;
    }
    public override void Applay(GameObject target)
    {
        GetComponent<BoxCollider2D>().enabled = false;
        effect = new OilPuddle(target, speed, checkpointY1, checkpointY2);
        (effect as OilPuddle).Slip();
        target.GetComponent<Life>().effect = effect;
        target.GetComponent<Life>().CurrentPoint = -1;

    }
}

