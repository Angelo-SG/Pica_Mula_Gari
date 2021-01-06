using UnityEngine;

public class Hole : Effect
{
    public Hole(GameObject target)
    {
        this.target = target;
        able = true;
    }
    public void Fall()
    {
        target.SetActive(false);
    }
    public void Reset()
    {
        able = false;
        target.SetActive(true);
        RatsAttack.instance.Play();
        Progress.instance.Play();
    }
}
