using UnityEngine;

public class OilPuddle : Obstacle
{
    private GameObject target;
    private bool active = false;
    public float speed = 0;
    private float topLineY = -1.11f;
    private float bottomLineY = -4.11f;
    public float checkpointY1 = 0;
    public float checkpointY2 = 0;
    private int index = 0;
    private float[] order = new float[3];
    public override void Applay(GameObject target)
    {
        Init(target);
    }

    private void Init(GameObject t)
    {
        target = t;
        target.GetComponent<Controller>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;

        float[] checkedList = new float[2];

        int select = Random.Range(0, 1);
        float lastPosY = target.GetComponent<Transform>().position.y;

        checkedList[0] = Mathf.Clamp(checkpointY1 + lastPosY, bottomLineY, topLineY);
        checkedList[1] = Mathf.Clamp(checkpointY2 + lastPosY, bottomLineY, topLineY);

        order[0] = (float)System.Math.Round(checkedList[select], 2);
        order[1] = (float)System.Math.Round(checkedList[(select + 1) % 2], 2);
        order[2] = (float)System.Math.Round(lastPosY, 2);

        index = 0;
        active = true;
    }
    private void Update()
    {
        if (active)
        {
            Slip();
            Reset();
            Debug.Log(index);
        }
    }
    private void Slip()
    {
        Transform t = target.GetComponent<Transform>();
        Vector3 pos = t.position;

        t.position = Vector3.Lerp(pos, new Vector3(pos.x, order[index], pos.z), speed * Time.deltaTime);
        if (Mathf.Abs(pos.y - order[index]) <= 0.2f)
        {
            index++;
        }
    }
    private void Reset()
    {
        if (index == order.Length)
        {
            Transform t = target.GetComponent<Transform>();
            Vector3 pos = t.position;

            target.GetComponent<Controller>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = true;
            t.position = new Vector3(pos.x, order[2], pos.z);
            active = false;
        }
    }
}

