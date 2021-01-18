using System.Diagnostics;
using System.Net;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class SlideBar : MonoBehaviour
{
    private Image fill;
    public float factor = .01f;
    private const float FPS = 60;
    private float current = 0;
    public bool active = false;
    private float lerpFactor = 1;
    public float time;
    private float next = 0;
    public bool decrement = false;
    private float valueControll;
    private void OnEnable()
    {
        Element.Spray += SetValue;
    }
    private void OnDisable()
    {
        Element.Spray -= SetValue;
    }
    private void Start()
    {
        fill = GetComponent<Image>();
    }
    void Update()
    {
        this.current = Mathf.Lerp(this.current, this.next, FPS * lerpFactor * time * Time.deltaTime);
        fill.rectTransform.localScale = new Vector2(1, this.current);
    }
    public void SetValue(int value)
    {
        if (active)
        {
            this.next = Mathf.Clamp(this.current + value * factor, 0.0f, 1.0f);

        }
        else
        {
            this.next = 0;
        }
    }
    public bool IsFill()
    {
        if (current >= .985f)
        {
            active = false;
            lerpFactor = 1;
            return true;
        }
        return false;
    }
    public bool IsEmpty()
    {
        if (current <= 0.015f)
        {
            active = true;
            lerpFactor = 0.01f;
            return true;
        }
        return false;
    }
}
