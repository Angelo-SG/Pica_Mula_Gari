using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Player : MonoBehaviour
{
    public int force;
    private float super;

    private void OnEnable()
    {
        PowerUp.superPowerOn += SPowerEffect;
        PowerUp.hiperPowerOn += HPowerEffect;
        PowerUp.PowerOff += POff;
    }
    private void OnDisable()
    {
        PowerUp.superPowerOn -= SPowerEffect;
        PowerUp.hiperPowerOn -= HPowerEffect;
        PowerUp.PowerOff -= POff;
    }
    public int Avaliable(int points)
    {
        if (points - (force +  super) > 0)
        {
            return -1;
        }
        return 1;
    }

    private void SPowerEffect()
    {
        super = 10;
        GetComponent<Life>().effect = new PowerUpEffect(gameObject);
        (GetComponent<Life>().effect as PowerUpEffect).SuperPower();
    }private void HPowerEffect()
    {
        super = 30;
        GetComponent<Life>().effect = new PowerUpEffect(gameObject);
        (GetComponent<Life>().effect as PowerUpEffect).HiperPower();
    }
    private void POff()
    {
        super = 0;
        GetComponent<Life>().effect =  new PowerUpEffect(gameObject);
        (GetComponent<Life>().effect as PowerUpEffect).Reset();
        GetComponent<Life>().effect = new ObjNullEffect();
    } 
}
