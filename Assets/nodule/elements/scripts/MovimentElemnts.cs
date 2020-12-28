using UnityEngine;

public class MovimentElemnts : MonoBehaviour
{
    private readonly int sense = -1;
    private Vector3 spaceInitial;
    private float speed = 0;
    private float timeLife = 0;
    private void Start()
    {
        spaceInitial = transform.position;
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        if (gameObject.activeSelf)
        {
            timeLife += Time.deltaTime;
            transform.position = new Vector3((spaceInitial.x + sense * (speed * timeLife + Progress.instance.acceleration * Mathf.Pow(timeLife, 2)/2)), transform.position.y, spaceInitial.z);
        }
    }
    public void Boost()
    {
        timeLife = 0;
        speed = Progress.instance.Speed;
    }
}
