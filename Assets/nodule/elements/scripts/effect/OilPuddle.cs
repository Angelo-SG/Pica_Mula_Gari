using UnityEngine;

public class OilPuddle : Effect
{
    private int index = 0;
    private float[] order = new float[3];
    private float speed = 0;
    private float topLineY = -1.11f;
    private float bottomLineY = -4.11f;
    private float checkpointY1 = 0;
    private float checkpointY2 = 0;
    public OilPuddle(GameObject target, float speed, float checkpointY1, float checkpointY2)
    {
        this.target = target;
        this.speed = speed;
        this.checkpointY1 = checkpointY1;
        this.checkpointY2 = checkpointY2;
    }
    public void Slip()
    {
        target.GetComponent<Controller>().enabled = false;

        float[] checkedList = new float[2];

        int select = Random.Range(0, 2);
        float lastPosY = target.GetComponent<Transform>().position.y;

        checkedList[0] = Mathf.Clamp(checkpointY1 + lastPosY, bottomLineY, topLineY);
        checkedList[1] = Mathf.Clamp(checkpointY2 + lastPosY, bottomLineY, topLineY);

        order[0] = (float)System.Math.Round(checkedList[select], 2);
        order[1] = (float)System.Math.Round(checkedList[(select + 1) % 2], 2);
        order[2] = (float)System.Math.Round(lastPosY, 2);

        index = 0;
        able = true;
    }
    public override void Update()
    {
        if (able)
        {
            Transform t = target.GetComponent<Transform>();
            Vector3 pos = t.position;

            t.position = Vector3.Lerp(pos, new Vector3(pos.x, order[index], pos.z), speed * Time.deltaTime);
            if (Mathf.Abs(pos.y - order[index]) <= 0.2f)
            {
                index++;
            }
            Reset();
        }
    }
    private void Reset()
    {
        if (index == order.Length)
        {
            Transform t = target.GetComponent<Transform>();
            Vector3 pos = t.position;

            target.GetComponent<Controller>().enabled = true;
            t.position = new Vector3(pos.x, order[2], pos.z);
            able = false;
        }
    }
}
