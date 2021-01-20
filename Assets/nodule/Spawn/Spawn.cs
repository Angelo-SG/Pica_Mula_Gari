using System.ComponentModel;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public static Spawn intance;
    public int line = 3;
    public float distanceY = 0;
    public float distanceX = 0;
    public int concecutiveInLine = 0;
    private Pool pool;
    private GameObject last;
    public SpriteRenderer playerSprite;

    private int concecutive = 0;
    private int lastLineSelect = 0;

    public void Awake()
    {
        intance = this;
    }
    private void Start()
    {
        pool = GetComponent<Pool>();
        for (int i = 0; i < pool.list.Length; i++)
        {
            pool.list[i] = Instantiate(pool.list[i], transform);
            pool.Put(i);
        }
        ToSow();
    }
    private void Update()
    {
        ToSow();
    }
    private void OnEnable()
    {
        Collectabel.GoToPool += GiveBack;
        Obstacle.GoToPool += GiveBack;
    }
    private void OnDisable()
    {
        Collectabel.GoToPool -= GiveBack;
        Obstacle.GoToPool -= GiveBack;
    }
    public void SpawnPosition(int index)
    {
        int lineRandSelect = Random.Range(0, line);
        if (lastLineSelect == lineRandSelect)
        {
            if (concecutive == concecutiveInLine - 1)
            {
                lineRandSelect = (lineRandSelect + 1) % line;
                lastLineSelect = lineRandSelect;
                concecutive = 0;
            }
            concecutive++;
        }
        else
        {
            lastLineSelect = lineRandSelect;
            concecutive = 0;
        }
        pool.list[index].transform.position = new Vector3(transform.position.x, transform.position.y - (lineRandSelect % line) * distanceY, 0);
    }
    private void ToSow()
    {
        float error = 1.0f / 5.0f;
        int index = Random.Range(0, pool.list.Length);

        if (last)
        {
            if (last.transform.position.x + distanceX + playerSprite.size.x + last.GetComponent<SpriteRenderer>().size.x + error < transform.position.x)
            {
                index = pool.Remove(index);
                if (index < 0)
                {
                    return;
                }
                last = pool.list[index];
                if (last)
                {
                    last.GetComponent<MovimentElemnts>().Boost();
                    SpawnPosition(index);
                }
            }
        }
        else
        {
            index = pool.Remove(index);
            last = pool.list[index];
            if (last)
            {
                last.GetComponent<MovimentElemnts>().Boost();
                SpawnPosition(index);
            }
        }
    }
    public void GiveBack(GameObject target)
    {
        int index = 0;
        while (index < pool.list.Length)
        {
            if (pool.list[index].Equals(target))
            {
                pool.Put(index);
            }
            index++;
        }
    }

    public void Refresh()
    {
        foreach (GameObject item in pool.list)
        {
            item.GetComponent<MovimentElemnts>().Speed = Progress.instance.Speed;
        }
    }
}