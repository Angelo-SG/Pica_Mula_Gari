using UnityEngine;
public class Crack : Effect
{
    public float duraction;
    private float count;
    public Crack(GameObject target)
    {
        this.target = target;
    }
    public void Stun()
    {
        target.GetComponent<Controller>().enabled = false;
        count = 0;
        able = true;
    }

    public override void Update()
    {
        if (able)
        {
            count += Time.deltaTime;
            if (count > duraction)
            {
                Reset();
            }
        }
    }
    private void Reset()
    {
        target.GetComponent<Controller>().enabled = true;
        able = false;
    }
}
