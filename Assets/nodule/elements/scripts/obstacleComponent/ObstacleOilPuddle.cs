using UnityEngine;

public class ObstacleOilPuddle : Obstacle
{
    public float speed = 0;
    public float checkpointY1 = 0;
    public float checkpointY2 = 0;
    public override void Applay(GameObject target)
    {
        effect = new OilPuddle(target, speed, checkpointY1, checkpointY2);
        (effect as OilPuddle).Slip();
        target.GetComponent<Life>().effect = effect;
        target.GetComponent<Life>().CurrentPoint = -1;

    }
}

