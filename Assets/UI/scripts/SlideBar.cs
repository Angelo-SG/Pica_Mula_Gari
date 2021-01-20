
using UnityEngine;
using UnityEngine.UI;

public class SlideBar : MonoBehaviour
{
    private Image fill;
    private const float FPS = 60;
    private float current = 0;
    public float time;
    public float decay;
    private float buffTime;
    private float next = 0;

    public static bool active;
    public float factor;
    private bool stopped = false;
    private int direction = 1;
    public int Direction
    {
        set { direction = value; }
        get
        {
            if (current >= 0.975f)
            {
                direction = -1;
            }
            if (current <= 0.025f)
            {
                time = buffTime;
                direction = 1;
            }
            return direction;
        }
    }

    public float Value
    {
        set { }
        get { return this.current; }
    }

    private void Start()
    {
        buffTime = time;
        fill = GetComponent<Image>();
    }
    void Update()
    {
        if (!stopped)
        {
            this.current = Mathf.Lerp(this.current, this.next, FPS * time * Time.deltaTime);
            fill.rectTransform.localScale = new Vector2(1, this.current);
        }
    }
    public void SetValue(int value)
    {
        this.next = Mathf.Clamp(this.current + value * factor, 0.0f, 1.0f);
    }
    public void Rest()
    {
        time = decay/100;
        this.next = 0;
        active = true;
    }
    public void Stop()
    {
        stopped = true;
    }
    public void Release()
    {
        stopped = false;
    }
}
