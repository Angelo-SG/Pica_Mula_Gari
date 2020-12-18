using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    // ============================================
    // VARIÁVEIS
    // ============================================
    public Animator animator;



    // ============================================
    // MÉTODOS
    // ============================================

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Jump");
        }
    }
}
