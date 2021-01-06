using UnityEngine;

public class RatsAttack : MonoBehaviour
{
    public static RatsAttack instance;
    private Vector3 startPos;
    private Vector3 nextRatsPos;
    private bool ableMove = false;
    public float speedAtack = 0.2f;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        startPos = transform.position;
        Approach(1);
    }
    private void OnEnable()
    {
        Life.ratsDistance += Approach;
    }
    private void OnDisable()
    {
        Life.ratsDistance += Approach;
    }
    private void Approach(int distance)
    {
        nextRatsPos = new Vector3(-3f * distance, 0, 0) + startPos;
        ableMove = true;
    }
    private void Update()
    {
        if (ableMove)
        {
            transform.position = Vector3.Lerp(transform.position, nextRatsPos, speedAtack);
            if (Vector3.Distance(transform.position, nextRatsPos) < 0.1f)
            {
                ableMove = false;
            }
        }
    }
    public void Stop()
    {
        foreach (ParticleSystem item in gameObject.GetComponentsInChildren<ParticleSystem>())
        {
            item.Stop();
        }
    }

    public void Play()
    {
        foreach (ParticleSystem item in gameObject.GetComponentsInChildren<ParticleSystem>())
        {
            item.Play();
        }
    }
}
