using UnityEngine;
using System;

public class PowerUp : MonoBehaviour
{
    public static event Action superPowerOn;
    public static event Action hiperPowerOn;
    public static event Action PowerOff;
    public SlideBar[] slides;
    private int index = 0;

    private void OnEnable()
    {
        Element.Spray += Inject;
    }
    private void OnDisable()
    {
        Element.Spray -= Inject;
    }
    private void Inject(int value)
    {
        if (slides[0].Direction < 0)
        {
            Element.instance.active = false;
            index = 1;
            slides[0].Rest();
            slides[1].Release();
            SuperOn();
        }
        else
        {
            Element.instance.active = true;
            index = 0;
            slides[1].Stop();
            POff();
        }
        if (slides[1].Direction < 0)
        {
            slides[1].Rest();
            index = 0;
            HiperOn();
        }
        else if (slides[1].Direction < 0)
        {
            Element.instance.active = false;
            POff();
        }

        slides[index].SetValue(value);
    }

    private void SuperOn()
    {
        if (superPowerOn != null)
        {
            superPowerOn();
        }
    }
    private void POff()
    {
        if (PowerOff != null)
        {
            PowerOff();
        }
    }
    private void HiperOn()
    {
        if (hiperPowerOn != null)
        {
            hiperPowerOn();
        }
    }
}
