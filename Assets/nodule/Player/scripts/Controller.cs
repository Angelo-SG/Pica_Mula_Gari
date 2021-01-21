using UnityEngine;

public class Controller : MonoBehaviour
{
    public float time;
    public float distance;
    private float direction;
    private Vector3 startPosition;
    private Animator animator;
    private float count = 0;
    public float delayToJump;
    private AudioSource audio;
    private bool onFloor = true;
    public static Controller instance;
    private bool stopped = false;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        animator = gameObject.GetComponent<Animator>();
        startPosition = transform.position;
        animator.Play("Run");
    }

    private void Update()
    {
        if (!stopped)
        {
            if (Life.situation != Life.state.ALIVE)
            {
                return;
            }
            direction = Input.GetAxisRaw("Vertical");

            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, startPosition.y + direction * distance, transform.position.z), time);

            if (onFloor)
            {
                count += Time.deltaTime;
                if (Input.GetKeyDown(KeyCode.Space) && count > delayToJump)
                {
                    audio.Play();
                    count = 0;
                    onFloor = false;
                    animator.Play("Jump");
                    GetComponent<BoxCollider2D>().enabled = false;
                }
            }
        }
    }
    public void OnFloor()
    {
        onFloor = true;
        GetComponent<BoxCollider2D>().enabled = true;
    }
    public void Stop()
    {
        stopped = true;
        animator.speed = 0;
    }
    public void Release(){
        stopped = false;
        animator.speed = 1;
    }
}
