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
    private bool onFloor = true;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        startPosition = transform.position;
    }

    private void Update()
    {
        if (Life.situation != Life.state.ALIVE)
        {
            Debug.Log("dead");
            return;
        }
        direction = Input.GetAxisRaw("Vertical");

        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, startPosition.y + direction * distance, transform.position.z), time);

        if (onFloor)
        {
            count += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space) && count > delayToJump)
            {
                count = 0;
                onFloor = false;
                animator.Play("Jump");
                GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
    public void OnFloor()
    {
        onFloor = true;
        GetComponent<BoxCollider2D>().enabled = true;
    }
}
