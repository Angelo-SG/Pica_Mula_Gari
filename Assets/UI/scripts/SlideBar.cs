using UnityEngine;
using UnityEngine.UI;
public class SlideBar : MonoBehaviour
{
    public Image fill;
    [Range(0, 1)]public float value = 0;

    void Update()
    {
        fill.rectTransform.localScale = new Vector2(1 ,value);
    }
}
