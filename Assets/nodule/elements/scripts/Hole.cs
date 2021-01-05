using UnityEngine;

public class Hole : Obstacle
{
    private GameObject[] GOL;

    private void Start()
    {
        GOL = GameObject.FindGameObjectsWithTag("ratsPS");
    }
    public override void Applay(GameObject target)
    {
        Fall(target);
        Progress.instance.Stop();
        foreach (GameObject item in GOL)
        {
            item.GetComponent<ParticleSystem>().Stop();
        }
    }
    public void Fall(GameObject target)
    {
        target.SetActive(false);
    }
}
