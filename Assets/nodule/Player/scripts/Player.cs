using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int force;

    public int Avaliable(int points)
    {
        if (points - force > 0)
        {
            return -1;
        }
        return 1;
    }
}
