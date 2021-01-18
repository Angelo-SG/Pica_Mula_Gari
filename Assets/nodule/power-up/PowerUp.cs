using UnityEngine.UI;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public SlideBar green;
    public SlideBar red;

    void Update()
    {
        swap();
    }
    private void swap()
    {
        if(!green.IsFill()){
            green.IsEmpty();
        }
    }
}
